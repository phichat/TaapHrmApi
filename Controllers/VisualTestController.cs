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
    [Route("api/[controller]")]
    [ApiController]
    public class VisualTestController : ControllerBase
    {
        private readonly db_taapHrmContext ctx;

        public VisualTestController(db_taapHrmContext context)
        {
            ctx = context;
        }

        // GET: api/VisualTest
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestionList()
        {
            try
            {
                var questionlist = await (
                    from db in ctx.VtQuestion
                    where db.IsActive == true
                    select new VtQuestion
                    {
                        Id = db.Id,
                        Question = db.Question,
                        ImgName = db.ImgName
                    }).ToListAsync();
                return Ok(questionlist);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionByCon(int Id)
        {
            try
            {
                var question = await (from db in ctx.VtQuestion
                                      where db.IsActive == true
                                      select new ViewQuestion
                                      {
                                          Id = db.Id,
                                          Question = db.Question,
                                          ImgName = db.ImgName,
                                          ImgSource = db.ImgSource,
                                          Choice = GetChoiceByQuestion(Id)
                                      }).FirstOrDefaultAsync();

                if (question == null)
                    return NoContent();

                return Ok(question);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private List<ViewChoice> GetChoiceByQuestion(int qId)
        {
            var choices = (from db in ctx.VtChoice
                           where db.IsActive == true && db.IdQuestion == qId
                           select new ViewChoice
                           {
                               Id = db.Id,
                               IdQuestion = (int)db.IdQuestion,
                               ImgName = db.ImgName,
                               ImgSource = db.ImgSource
                           }).ToList();
            return choices;
        }


        [HttpGet("{userId}", Name = "GetScoreByCon")]
        public IActionResult GetScoreByCon(int userId)
        {
            var score = ctx.VtScore.SingleOrDefault(p => p.Id == userId);
            if (score == null)
                return NoContent();

            return Ok(score);
        }

        [HttpPost]
        public async Task<IActionResult> InsQuestion([FromBody] ViewQuestion value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var transaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    var question = new VtQuestion
                    {
                        Id = value.Id,
                        Question = value.Question,
                        ImgName = value.ImgName,
                        ImgSource = value.ImgSource,
                        Answer = value.Answer,
                        CreateBy = value.CreateBy,
                        CreateDate = DateTime.Now
                    };

                    ctx.VtQuestion.Add(question);
                    await ctx.SaveChangesAsync();

                    var choices = value.Choice;

                    choices.ForEach(item =>
                    {
                        var c = new VtChoice
                        {
                            Id = item.Id,
                            Choice = item.Choice,
                            IdQuestion = question.Id,
                            ImgName = item.ImgName,
                            ImgSource = item.ImgSource,
                            CreateBy = question.CreateBy,
                            CreateDate = DateTime.Now
                        };
                        ctx.VtChoice.Add(c);
                    });
                    await ctx.SaveChangesAsync();

                    transaction.Commit();

                    return StatusCode(201);
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                    return StatusCode(500);
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult<VtScore>> ValidExamination([FromBody] QuestionTest value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var examination = value.Examination;
            var past = 0;
            var notPast = 0;
            var totalQuestion = 0;
            examination.ForEach(item =>
            {
                totalQuestion += 1;
                var answer = ctx.VtQuestion.FirstOrDefault(p => p.Id == item.QuestionId && p.Answer == item.Answer);
                if (answer != null)
                {
                    past += 1;
                }
                else
                {
                    notPast += 1;
                }
            });

            var score = new VtScore
            {
                Past = past,
                NotPast = notPast,
                TotalQuestion = totalQuestion,
                UserId = examination.First().UserId,
                UserName = examination.First().UserName,
                CareerType = examination.First().CareerType
            };

            ctx.VtScore.Add(score);
            await ctx.SaveChangesAsync();

            var _userId = 1;
            return CreatedAtAction(nameof(GetScoreByCon), new { userId = _userId }, score);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ViewQuestion>> UpdQuestion(int id, [FromBody] ViewQuestion value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var transaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    var question = new VtQuestion
                    {
                        Id = value.Id,
                        Question = value.Question,
                        ImgName = value.ImgName,
                        ImgSource = value.ImgSource,
                        Answer = value.Answer,
                        CreateBy = value.CreateBy,
                        CreateDate = DateTime.Now
                    };

                    ctx.VtQuestion.Update(question);
                    await ctx.SaveChangesAsync();

                    var choices = value.Choice;

                    choices.ForEach(item =>
                    {
                        var c = new VtChoice
                        {
                            Id = item.Id,
                            Choice = item.Choice,
                            IdQuestion = question.Id,
                            ImgName = item.ImgName,
                            ImgSource = item.ImgSource,
                            CreateBy = question.CreateBy,
                            CreateDate = DateTime.Now
                        };
                        ctx.VtChoice.Update(c);
                    });
                    await ctx.SaveChangesAsync();

                    transaction.Commit();

                    return CreatedAtAction(nameof(GetQuestionByCon), new { id = value.Id }, value);
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                    return StatusCode(500);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelQuestion(int id)
        {
          using (var transaction = ctx.Database.BeginTransaction())
          {
             try
                {
                    var question = ctx.VtQuestion.First(item => item.Id == id);
                    question.IsActive = false;

                    var choice = ctx.VtChoice.Where(item => item.IdQuestion == id).ToList();
                    choice.ForEach(item => {
                      item.IsActive = false;
                    });

                    await ctx.SaveChangesAsync();

                    transaction.Commit();

                    return Ok();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                    return StatusCode(500);
                }
          }
        }
    }
}