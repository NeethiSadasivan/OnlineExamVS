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
    public class AdminController : ControllerBase
    {
        OnlineExamContext db;
        public AdminController(OnlineExamContext context)
        {
            db = context;
        }
        [HttpPost("Login")]
        public IActionResult Login(Admin admin)
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
