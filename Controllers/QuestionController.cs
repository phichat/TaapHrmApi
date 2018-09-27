using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaapHrmApi.Model;

namespace TaapHrmApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly db_taapHrmContext ctx;

        public QuestionController(db_taapHrmContext context) {
            ctx = context; 
        }

        // GET: api/Question
        [HttpGet("GetQuestionSet")]
        public IActionResult GetQuestionSet(int id)
        {
            var qs = ctx.HrmTestQuestionSets.Where(x => x.Id == id)
                        .Select(x => new HrmTestQuestionSetResponse
                        {
                            QuestionSetId = x.Id,
                            QuestionSet = x.QuestionSet,
                            TimeOut = x.TimeOut,
                            QuestionList = null
                        }).FirstOrDefault();

            var ql = (from db in ctx.HrmTestQuestions
                      where db.QuestionSetId == id
                      select new HrmTestQuestionList
                      {
                          Id = db.Id,
                          Question = db.Question,
                          ImgName = db.ImgName,
                          IsActive = db.IsActive
                      }).ToList();

            qs.QuestionList = ql.ToArray();

            return Ok(qs);
        }

        [HttpGet("GetQuestionRandom")]
        public async Task<IActionResult> GetQuestionRandom() {
            try
            {

                var q = await (from tq in ctx.HrmTestQuestions

                               join qs in ctx.HrmTestQuestionSets on tq.QuestionSetId equals qs.Id into a1
                               from question in a1.DefaultIfEmpty()

                               select new HrmTestQuestionFormBody
                               {
                                   Id = tq.Id,
                                   QuestionSet = question.QuestionSet,
                                   Question = tq.Question,
                                   Img = tq.Img,
                                   ImgName = tq.ImgName,
                                   Answer = null,
                                   UpdateUserPosi = tq.UpdateUserPosi
                               })
                    .OrderBy(x => Guid.NewGuid())
                    .Take(20)
                    .ToListAsync();

                foreach(var qt in q) {
                    qt.Choice = ctx.HrmTestChoices.Where(x => x.QuestionId == qt.Id).ToArray();
                }

                return Ok(q);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return StatusCode(500);
            }

        }

        // GET: api/Question/5
        [HttpGet("GetQuestion")]
        public IActionResult GetQuestion(int id)
        {
            try {
                var q = (from tq in ctx.HrmTestQuestions

                         join qs in ctx.HrmTestQuestionSets on tq.QuestionSetId equals qs.Id into a1
                         from question in a1.DefaultIfEmpty()

                         where tq.Id == id
                         select new HrmTestQuestionFormBody
                         {
                             Id = tq.Id,
                             QuestionSetId = question.Id,
                             QuestionSet = question.QuestionSet,
                             TimeOut = question.TimeOut,
                             Question = tq.Question,
                             Img = tq.Img,
                             ImgName = tq.ImgName,
                             Answer = tq.Answer,
                             UpdateUserPosi = tq.UpdateUserPosi
                         }).FirstOrDefault();

                var choice = ctx.HrmTestChoices.Where(x => x.QuestionId == id).ToList();

                q.Choice = choice.ToArray();

                return Ok(q);

            } catch(Exception ex) {
                Console.Write(ex.Message);
                return StatusCode(500);
            }

        }

        // POST: api/Question
        [HttpPost("CreateQuestion")]
        public IActionResult CreateQuestion([FromBody] HrmTestQuestionFormBody q)
        {

            using (var transaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    // Question set
                    var questionSet = new HrmTestQuestionSet();

                    if (q.QuestionSetId == 0) {
                        questionSet.QuestionSet = q.QuestionSet;
                        questionSet.UpdateUserPosi = q.UpdateUserPosi;
                        questionSet.TimeOut = q.TimeOut;
                        questionSet.UpdateDatePosi = DateTime.Now;
                        ctx.Add(questionSet);
                        ctx.SaveChanges();
                    } else {
                        questionSet = ctx.HrmTestQuestionSets.SingleOrDefault(x => x.Id == q.QuestionSetId);

                        if (questionSet.QuestionSet != q.QuestionSet) {
                            questionSet.QuestionSet = q.QuestionSet;
                            questionSet.TimeOut = q.TimeOut;
                            questionSet.UpdateUserPosi = q.UpdateUserPosi;
                            questionSet.UpdateDatePosi = DateTime.Now;
                            ctx.Update(questionSet);
                            ctx.SaveChanges();
                        }
                    }

                    // Question
                    var question = new HrmTestQuestion();

                    question.QuestionSetId = questionSet.Id;
                    question.Question = q.Question;
                    question.Img = q.Img;
                    question.ImgName = q.ImgName;
                    question.Answer = (int)q.Answer;
                    question.UpdateDatePosi = DateTime.Now;
                    question.UpdateUserPosi = q.UpdateUserPosi;

                    ctx.Add(question);
                    ctx.SaveChanges();

                    // Choice
                    foreach (var c in q.Choice)
                    {
                        var choice = new HrmTestChoice();
                        choice.Choice = c.Choice;
                        choice.Img = c.Img;
                        choice.ImgName = c.ImgName;
                        choice.QuestionId = question.Id;
                        choice.UpdateUserPosi = c.UpdateUserPosi;
                        choice.UpdateDatePosi = DateTime.Now;
                        ctx.Add(choice);
                    }   
                    ctx.SaveChanges();

                    transaction.Commit();

                    return Ok(questionSet);

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    transaction.Rollback();
                    return StatusCode(500);
                }
            }

        }

        // PUT: api/Question/5
        [HttpPut("UpdateQuestion")]
        public IActionResult UpdateQuestion([FromBody] HrmTestQuestionFormBody q)
        {
            using(var transaction = ctx.Database.BeginTransaction()) {
                try {
                    var qs = ctx.HrmTestQuestionSets.SingleOrDefault(x => x.Id == q.QuestionSetId);
                    qs.QuestionSet = q.QuestionSet;
                    qs.TimeOut = q.TimeOut;
                    qs.UpdateUserPosi = q.UpdateUserPosi;
                    qs.UpdateDatePosi = DateTime.Now;
                    ctx.Update(qs);
                    ctx.SaveChanges();


                    // q.Id = QuestionId;
                    var question = ctx.HrmTestQuestions.SingleOrDefault(x => x.Id == q.Id);
                    question.Question = q.Question;
                    question.Img = q.Img;
                    question.ImgName = q.ImgName;
                    question.Answer = (int)q.Answer;
                    question.UpdateDatePosi = DateTime.Now;
                    question.UpdateUserPosi = q.UpdateUserPosi;
                    ctx.Update(question);
                    ctx.SaveChanges();

                    foreach (var c in q.Choice)
                    {
                        // c.Id = ChoiceId;

                        if (c.Id == 0) {
                            var choice = new HrmTestChoice();
                            choice.Choice = c.Choice;
                            choice.Img = c.Img;
                            choice.ImgName = c.ImgName;
                            choice.QuestionId = question.Id;
                            choice.UpdateUserPosi = c.UpdateUserPosi;
                            choice.UpdateDatePosi = DateTime.Now;
                            ctx.Add(choice);

                        } else {
                            var ct = ctx.HrmTestChoices.SingleOrDefault(x => x.Id == c.Id);
                            ct.Choice = c.Choice;
                            ct.Img = c.Img;
                            ct.ImgName = c.ImgName;
                            ct.QuestionId = question.Id;
                            ct.UpdateUserPosi = c.UpdateUserPosi;
                            ct.UpdateDatePosi = DateTime.Now;
                            ctx.Update(ct);
                        }
                    }
                    ctx.SaveChanges();

                    transaction.Commit();

                    return Ok(qs);

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    transaction.Rollback();
                    return StatusCode(500);
                }
            }
        }

        [HttpPut("UpdateQuestionSet")]
        public IActionResult UpdateQuestionSet([FromBody] HrmTestQuestionSet from) {
            try {

                var qs = ctx.HrmTestQuestionSets.SingleOrDefault(x => x.Id == from.Id);

                if (qs == null)
                    // NotModified
                    return StatusCode(304);

                qs.QuestionSet = from.QuestionSet;
                qs.TimeOut = from.TimeOut;
                qs.UpdateUserPosi = from.UpdateUserPosi;
                qs.UpdateDatePosi = DateTime.Now;
                ctx.Update(qs);
                ctx.SaveChanges();
                    
                return Ok();

            } catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("ActiveQuestionSet")]
        public IActionResult ActiveQuestionSet([FromBody] ActiveFromBody from)
        {
            try
            {
                //return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.)
                var q = ctx.HrmTestQuestionSets.SingleOrDefault(x => x.Id == from.Id);

                if (q == null)
                    // NotModified
                    return StatusCode(304);

                q.IsActive = from.IsActive;
                q.UpdateUserPosi = from.UpdateUserPosi;
                q.UpdateDatePosi = DateTime.Now;
                ctx.SaveChanges();

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("ActiveQuestion")]
        public IActionResult ActiveQuestion([FromBody] ActiveFromBody from)
        {
            try{
                //return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.)
                var q = ctx.HrmTestQuestions.SingleOrDefault(x => x.Id == from.Id);

                if (q == null)
                    // NotModified
                    return StatusCode(304);

                q.IsActive = from.IsActive;
                q.UpdateUserPosi = from.UpdateUserPosi;
                q.UpdateDatePosi = DateTime.Now;
                ctx.SaveChanges();

                return Ok();

            } catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteChoice")]
        public IActionResult DelChoice(int id) {
            try{
                var c = ctx.HrmTestChoices.SingleOrDefault(x => x.Id == id);

                if (c == null)
                    // NotModified
                    return StatusCode(304);

                c.IsActive = 0;
                ctx.SaveChanges();

                return Ok();

            } catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }


        public class ActiveFromBody {
            public int Id { get; set; }
            public int IsActive { get; set; }
            public int UpdateUserPosi { get; set; }
        }
    }
}
