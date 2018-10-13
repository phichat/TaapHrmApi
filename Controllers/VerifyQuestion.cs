﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaapHrmApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaapHrmApi.Controllers
{
    [Route("api/VerifyQuestion")]
    public class VerifyQuestion : Controller
    {
        private readonly db_taapHrmContext ctx;

        public VerifyQuestion(db_taapHrmContext context)
        {
            ctx = context;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost("CreateVerifyQuestion")]
        public IActionResult CreateVerifyQuestion([FromBody]HrmTestVerifyQuestion value)
        {
            using (var trans = ctx.Database.BeginTransaction())
            {

                try
                {
                    var questions = value.Questions;

                    // 1 ตรวจแบบทดสอบ
                    var resultDetail = new List<HrmTestResultDetail>();
                    var pass = 0;
                    var fail = 0;
                    var totalQuestion = 0;
                    foreach (var item in questions)
                    {
                        // คำถาม
                        var qq = ctx.HrmTestQuestions.SingleOrDefault(x => x.Id == item.QuestionId);

                        // คำตอบที่ ผู้ทดสอบเลือก 
                        var testedAnswer = ctx.HrmTestChoices.SingleOrDefault(x => x.QuestionId == item.QuestionId && x.AnswerChoice == item.Answer);

                        // คำตอบที่ถูกต้อง
                        var answer = ctx.HrmTestChoices.SingleOrDefault(x => x.QuestionId == qq.Id && x.AnswerChoice == qq.Answer);

                        var rd = new HrmTestResultDetail
                        {
                            QuestionId = qq.Id,
                            TestedQuestion = qq.Question,
                            TestedAnswer = testedAnswer != null ? testedAnswer.Choice : "",
                            Answer = answer.Choice,
                            Result = (qq.Answer == item.Answer) ? true : false
                        };
                        resultDetail.Add(rd);

                        totalQuestion += 1;
                        if (qq.Answer == item.Answer)
                        {
                            // Pass
                            pass += 1;
                        }
                        else
                        {
                            // Fail
                            fail += 1;
                        }
                    }

                    // 2 บันทึกแบบทดสอบ
                    // 2.1 เช็คว่ามีบันทึกแบบทดสอบ แล้วหรือไม่
                    var checkResult = ctx.HrmTestResults.SingleOrDefault(x => x.UserId == value.UserId && x.QuestionSetId == value.QuestionSetId);

                    // 2.2 ถ้ามีให้อัพเดท
                    // 2.3 ถ้าไม่มีให้บันทึก
                    if (checkResult != null)
                    {
                        checkResult.UserId = value.UserId;
                        checkResult.QuestionSetId = value.QuestionSetId;
                        checkResult.TimeOut = value.TimeOut;
                        checkResult.TimeUse = value.TimeUse;
                        checkResult.Pass = pass;
                        checkResult.Fail = fail;
                        checkResult.Total = totalQuestion;

                        ctx.HrmTestResults.Update(checkResult);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        checkResult = new HrmTestResult
                        {
                            UserId = value.UserId,
                            QuestionSetId = value.QuestionSetId,
                            TimeOut = value.TimeOut,
                            TimeUse = value.TimeUse,
                            Pass = pass,
                            Fail = fail,
                            Total = totalQuestion
                        };

                        ctx.HrmTestResults.Add(checkResult);
                        ctx.SaveChanges();
                    }

                    // 3 ตรวจสอบว่า กรายละเอียดการทำแบบทดสอบ แล้วหรือไม่
                    var checkResultDetail = ctx.HrmTestResultDetails.Where(x => x.TestResultId == checkResult.Id).ToList();

                    // 3.1 ถ้ามีแล้ว ลบของเดิมทิ้ง
                    if (checkResultDetail != null)
                    {
                        ctx.HrmTestResultDetails.RemoveRange(checkResultDetail);
                        ctx.SaveChanges();
                    }

                    // 3.2 บันทึกรายละเอียดการทำแบบทดสอบใหม่เข้าไป
                    resultDetail.ForEach(x =>
                    {
                        x.TestResultId = checkResult.Id;
                    });
                    ctx.HrmTestResultDetails.AddRange(resultDetail);
                    ctx.SaveChanges();

                    trans.Commit();

                    return Ok();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return StatusCode(500, ex.Message);
                }
            }

        }

        [HttpGet("GetQuestionResult")]
        public IActionResult GetQuestionResult(int questionSetId, int userId) {
            try {

                var result = (from r in ctx.HrmTestResults
                              join u in ctx.HrmUsers on r.UserId equals u.Id
                              join q in ctx.HrmTestQuestionSets on r.QuestionSetId equals q.Id

                              select new HrmTestVerifyQuestionResponse
                              {
                                  Id = r.Id,
                                  QuestionSetId = r.QuestionSetId,
                                  QuestionSet = q.QuestionSet,
                                  TimeOut = r.TimeOut,
                                  TimeUse = r.TimeUse,
                                  UserId = r.UserId,
                                  FullName = u.FullName,
                                  Pass = r.Pass,
                                  Fail = r.Fail,
                                  Total = r.Total
                              })
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault(x => x.QuestionSetId == questionSetId && x.UserId == userId);

                if (result == null) return NotFound();

                var resultDetail = ctx.HrmTestResultDetails.Where(x => x.TestResultId == result.Id).ToList();

                result.ResultDetail = resultDetail.ToArray();

                return Ok(result);

            } catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}