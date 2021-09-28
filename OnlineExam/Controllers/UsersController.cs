﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

        protected string Generate_otp()
        {
            char[] charArr = "0123456789".ToCharArray();
            string strrandom = string.Empty;
            Random ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                int pos = ran.Next(1, charArr.Length);
                if (!strrandom.Contains(charArr.GetValue(pos).ToString()))
                    strrandom += charArr.GetValue(pos);
                else
                    i--;
            }

            return strrandom;

        }
        [NonAction]
        public void SendMail(string from, string To, string Subject, string Body)
        {
            MailMessage mail = new MailMessage(from, To);
            mail.Subject = Subject;
            mail.Body = Body;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "",
                Password = ""
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mail);
        }

        [HttpPost("EmailExists")]
        public IActionResult EmailExists(Users users)
        {
            Users _users = db.Users.Where(x => x.Email == users.Email).FirstOrDefault();
            Dictionary<string, bool> status = new Dictionary<string, bool>();
            if (_users != null)
            {
                status.Add("EmailExists", true);
                string OTP = Generate_otp();
                _users.Otp = OTP;
                db.SaveChanges();
                SendMail("", _users.Email, "OTP for resetting the password -Online", "OTP for resetting the password is" + OTP);
                return Ok(status);
            }

            else
            {
                status.Add("EmailExists", false);
                return Ok(status);
            }
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(Users users)
        {
            Users _users = db.Users.Where(x => x.Email == users.Email).FirstOrDefault();
            Dictionary<string, bool> status = new Dictionary<string, bool>();
            if (_users != null)
            {
                if (_users.Otp == users.Otp)
                {
                    _users.Otp = "";
                    db.SaveChanges();
                    status.Add("IsOTPValid", true);
                }
                else
                {
                    status.Add("IsOTPValid", false);
                }

                return Ok(status);
            }
            return BadRequest();
        }

    }
}
