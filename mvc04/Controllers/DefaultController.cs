using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc04.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public String CAction()
        {
            return "This is CAction";
        }

        public String Action()
        {
            int atotal = IncrementAndGetApplication("Action");
            int stotal = IncrementAndGetSession("Action");

            return "Action with no parameter<br />" + "This action has been accessed: " + atotal + " times<br/>" + "this action has been accessed: " + stotal + " times in this session.";
        }

        public String ActionN(int i1)
        {
            int atotal = IncrementAndGetApplication("ActionN");
            int stotal = IncrementAndGetSession("ActionN");

            return "Action with one numebr: " + i1.ToString() + "<br />" + "This action has been accessed: " + atotal + " times<br />" + "This action has been accessed: " + stotal + " times in this session.";
        }

        public String ActionS(string i1)
        {
            int atotal = IncrementAndGetApplication("ActionS");
            int stotal = IncrementAndGetSession("ActionS");

            if (TempData["s1"] != null && TempData["s2"] != null)
            {
                i1 = i1 + "(" + (string)TempData["s1"] + ", " + (string)TempData["s2"] + ")";
            }

            return "Action with one string: " + i1 + "<br />" + "This action has been accessed: " + atotal + " times<br />" + "This action has been accessed: " + stotal + " times in this session.";
        }

        public ActionResult ActionSS(string s1, string s2)
        {
            TempData["s1"] = s1;
            TempData["s2"] = s2;

            return RedirectToAction("ActionS", new {
                i1 = "dummy"
            });
        }

        private int IncrementAndGetSession(string name)
        {
            int counter = 0;

            if (Session[name] != null)
            {
                counter = (int)Session[name];
            }

            counter += 1;
            Session[name] = counter;

            return counter;
        }


        private int IncrementAndGetApplication(string name)
        {
            int counter = 0;
            HttpContext.Application.Lock();
            if (HttpContext.Application[name] != null)
            {
                counter = (int)HttpContext.Application[name];
            }

            counter += 1;
            HttpContext.Application[name] = counter;
            HttpContext.Application.UnLock();
            
            return counter;
        }
    }
}