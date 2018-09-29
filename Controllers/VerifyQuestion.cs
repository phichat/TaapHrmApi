using System;
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
            try {
                var questions = value.Questions;

                var q = ctx.HrmTestQuestions.Where(x => x.QuestionSetId == value.QuestionSetId).ToList();

                var pass = 0;
                var fail = 0;
                var totalQuestion = 0;
                foreach (var item in questions)
                {

                    var qq = q.SingleOrDefault(x => x.Id == item.QuestionId);

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

                var result = new HrmTestResult
                {
                    UserId = value.UserId,
                    QuestionSetId = value.QuestionSetId,
                    TimeOut = value.TimeOut,
                    TimeUse = value.TimeUse,
                    Pass = pass,
                    Fail = fail,
                    Total = totalQuestion
                };
                ctx.HrmTestResults.Add(result);
                ctx.SaveChanges();

                return Ok();
            } catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("GetQuestionResult")]
        public IActionResult GetQuestionResult(int questionSetId, int userId) {

            var result = ctx.HrmTestResults.SingleOrDefault(x => x.QuestionSetId == questionSetId && x.UserId == userId);

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
