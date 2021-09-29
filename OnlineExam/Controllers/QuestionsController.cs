using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        OnlineExamContext db;
        public QuestionsController(OnlineExamContext context)
        {
            db = context;
        }
        [HttpGet("Level1")]
        public IActionResult GetForl1(string sub)
        {
            var qns = (from q in db.Questions
                     where q.Subject.Subjectname == sub
                     where q.Level==1
                     join s in db.Subjects on q.Subjectid equals s.Subjectid

                     select new
                     {
                         q.Question,
                         q.Option1,
                         q.Option2,
                         q.Option3,
                         q.Option4
                     }).ToList();
            return Ok(qns);
        }
        [HttpGet("Level2")]
        public IActionResult GetForl2(string sub)
        {
            var qns = (from q in db.Questions
                       where q.Subject.Subjectname == sub
                       where q.Level == 2
                       join s in db.Subjects on q.Subjectid equals s.Subjectid

                       select new
                       {
                           q.Question,
                           q.Option1,
                           q.Option2,
                           q.Option3,
                           q.Option4
                       }).ToList();
            return Ok(qns);
        }
        [HttpGet("Level3")]
        public IActionResult GetForl3(string sub)
        {
            var qns = (from q in db.Questions
                       where q.Subject.Subjectname == sub
                       where q.Level == 3
                       join s in db.Subjects on q.Subjectid equals s.Subjectid

                       select new
                       {
                           q.Question,
                           q.Option1,
                           q.Option2,
                           q.Option3,
                           q.Option4
                       }).ToList();
            return Ok(qns);
        }
    }
}
