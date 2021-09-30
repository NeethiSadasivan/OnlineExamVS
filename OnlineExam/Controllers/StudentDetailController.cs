using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Models;

namespace OnlineExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailController : ControllerBase
    {
        OnlineExamContext db;

        public StudentDetailController(OnlineExamContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult getStudentResultsByState(int? Subjectid, string State)
        {
            //Result r = new Result();
            var p = (from u in db.Users
                     join r in db.Result on u.Userid equals r.Userid
                     where r.Subjectid == Subjectid && u.State == State
                     select new
                     {
                         u.Userid,
                         u.Username,
                         u.Email,
                         u.Mobile,
                         u.Dob,
                         u.City,
                         u.State,
                         r.Subjectid,
                         r.Level1marks,
                         r.Level2marks,
                         r.Level3marks
                     }).ToList();
            return Ok(p);
        }
    }
}
