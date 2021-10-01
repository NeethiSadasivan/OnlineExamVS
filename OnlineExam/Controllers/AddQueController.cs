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
    public class AddQueController : ControllerBase
    {
        OnlineExamContext db;
        public AddQueController(OnlineExamContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Questions);
        }


        [HttpPost("add")]
        public IActionResult AddQuestion(Questions questions)
        {
            db.Questions.Add(questions);
            db.SaveChanges();
            return Ok();
        }
    }
}
