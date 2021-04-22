using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DIProject.Models;
using DIProject.Services;

namespace DIProject.Controllers
{
    public class HomeController : Controller
    {
        readonly Imail mail1;
        public HomeController(Imail _mail) => mail1 = _mail;
        public IActionResult Index([FromServices] Imail mail)
        {
            //MailGmail mailGmail = new MailGmail();

            //////////////////////////////////////
            //ViewData["gmail"] = mail.ToList()[0].SendEmail();
            //ViewData["yahoo"] = mail.ToList()[1].SendEmail();
            
            //////////////////////////////////////////////////
            
            ViewData["gmail"] = mail.SendEmail();

            return View();
        }


        ///////////////////////////////////////////////
        //public IActionResult Index([FromServices] IEnumerable<Imail> mail)
        //{
            //MailGmail mailGmail = new MailGmail();

            //////////////////////////////////////
            //ViewData["gmail"] = mail.ToList()[0].SendEmail();
            //ViewData["yahoo"] = mail.ToList()[1].SendEmail();

            //////////////////////////////////////////////////

            //ViewData["yahoo"] = mail.ToList()[1].SendEmail();

           // return View();
        //}
    }
}
