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

        private string GetQuestionTypeDesc(int key) {
            string strReturn = "";
            switch (key) {
                case 1:
                    strReturn = "IQ test";
                    break;
                case 2:
                    strReturn = "Career test";
                    break;
            }
            return strReturn;
        }

        private string GetIsActiveDesc(int key) {
            string strReturn = "";
            switch (key) {
                case 0:
                    strReturn = "Deactivate";
                    break;
                case 1:
                    strReturn = "Active";
                    break;
            }
            return strReturn;
        }

        // GET: api/Question
        [HttpGet("QuestionList")]
        public IActionResult QuestionList()
        {
            var questionList = (from db in ctx.HrmTestQuestions
                                select new HrmTestQuestionList
                                {
                                    Id = db.Id,
                                    QuestionType = db.QuestionType,
                                    QuestionTypeDesc = GetQuestionTypeDesc(db.QuestionType),
                                    Question = db.Question,
                                    ImgName = db.ImgName,
                                    IsActive = db.IsActive,
                                    IsActiveDesc = GetIsActiveDesc(db.IsActive)
                                }).ToList();

            return Ok(questionList);
        }

        [HttpGet("QuestionRandom")]
        public async Task<IActionResult> QuestionRandom() {
            try
            {

                var q = await (from tq in ctx.HrmTestQuestions
                               select new HrmTestQuestionFormBody
                               {
                                   Id = tq.Id,
                                   QuestionType = tq.QuestionType,
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
        [HttpGet(Name = "Get")]
        public IActionResult Get(int id)
        {
            try {
                var q = (from tq in ctx.HrmTestQuestions
                         where tq.Id == id
                         select new HrmTestQuestionFormBody
                         {
                             Id = tq.Id,
                             QuestionType = tq.QuestionType,
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
        [HttpPost]
        public IActionResult Post([FromBody] HrmTestQuestionFormBody q)
        {

            using (var transaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    var question = new HrmTestQuestion();

                    question.QuestionType = q.QuestionType;
                    question.Question = q.Question;
                    question.Img = q.Img;
                    question.ImgName = q.ImgName;
                    question.Answer = (int)q.Answer;
                    question.UpdateDatePosi = DateTime.Now;
                    question.UpdateUserPosi = q.UpdateUserPosi;

                    ctx.Add(question);
                    ctx.SaveChanges();

                    //var choice = q.Choice;

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

                    return Ok();

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
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HrmTestQuestionFormBody q)
        {
            using(var transaction = ctx.Database.BeginTransaction()) {
                try {
                    var question = ctx.HrmTestQuestions.SingleOrDefault(x => x.Id == id);

                    question.QuestionType = q.QuestionType;
                    question.Question = q.Question;
                    question.Img = q.Img;
                    question.ImgName = q.ImgName;
                    question.Answer = (int)q.Answer;
                    question.UpdateDatePosi = DateTime.Now;
                    question.UpdateUserPosi = q.UpdateUserPosi;

                    ctx.Update(question);
                    ctx.SaveChanges();

                    //var choice = q.Choice;

                    foreach (var c in q.Choice)
                    {
                        var ct = ctx.HrmTestChoices.SingleOrDefault(x => x.Id == c.Id);

                        if (ct == null) {
                            var choice = new HrmTestChoice();
                            choice.Choice = c.Choice;
                            choice.Img = c.Img;
                            choice.ImgName = c.ImgName;
                            choice.QuestionId = question.Id;
                            choice.UpdateUserPosi = c.UpdateUserPosi;
                            choice.UpdateDatePosi = DateTime.Now;
                            ctx.Add(choice);

                        } else {
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

                    return Ok();

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    transaction.Rollback();
                    return StatusCode(500);
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
