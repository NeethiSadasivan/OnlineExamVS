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
    public class UsersController : ControllerBase
    {
        OnlineExamContext db;
        public UsersController(OnlineExamContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Users);
        }

        [HttpPost("Register")]
        public IActionResult Register(Users users)
        {
            var res = db.Users.Where(x => x.Email == users.Email).FirstOrDefault();
            if (res == null)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return Ok(new { status = "registered" });
            }
            else
            {
                return Ok(new { status = "already exist" });
            }

        }

        [HttpPost("Login")]
        public IActionResult Login(Users users)
        {
            var existUser = db.Users.Where(userOb => (userOb.Email == users.Email) && (userOb.Password == users.Password)).FirstOrDefault();

            if (existUser != null)
            {
                return Ok(new { status = "successful" });
            }
            return Ok(new { status = "unsuccessful" });

        }
        [HttpGet("ReportCard")]
        public IActionResult Getbyuser(string username)
        {
            
            var q = (from r in db.Result
                     where r.User.Username == username
                     join s in db.Subjects on r.Subjectid equals s.Subjectid
                     join u in db.Users on r.Userid equals u.Userid

                     select new
                     {
                         u.Username,
                         s.Subjectname,
                         r.Level1marks,
                         r.Level2marks,
                         r.Level3marks
                     }).ToList();
            return Ok(q);
        }

    }
}
