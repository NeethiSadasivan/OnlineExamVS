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
        [HttpGet]
        public IActionResult GetForl1(string sub,int level)
        {
            var qns = (from q in db.Questions
                     where q.Subject.Subjectname == sub
                     where q.Level==level
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
