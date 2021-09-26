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
    public class AdminsController : ControllerBase
    {
        OnlineExamContext db;
        public AdminsController(OnlineExamContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Admin);
        }
        [HttpPost("AdminLogin")]
        public IActionResult AdminLogin(Admin admin)
        {
            var existAdmin = db.Admin.Where(adminOb => (adminOb.Emailid == admin.Emailid) && (adminOb.Password == admin.Password)).FirstOrDefault();
            if (existAdmin != null)
            {
                return Ok(new { status = "successful" });
            }
            return Ok(new { status = "unsuccessful" });
        }
    }
}
