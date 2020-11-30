using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace fullframework472.Controllers
{
    public class HomeController : Controller
    {
        public ConcurrentBag<object> list = new ConcurrentBag<object>();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public Task[] tasks;
        private static Random random = new Random();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet, Route("leak/{amount}")]
        public ActionResult leak(int amount)
        {
            tasks = new Task[amount];
            for (int i = 0; i < amount; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    while (true)
                    {
                        if (list.Count < 200000)
                        {
                            list.Add(new string(Enumerable.Repeat(chars, 5000).Select(s => s[random.Next(s.Length)]).ToArray()));
                        }
                    }
                });

            }
            return Content("foi :devillaugh:");
        }
    }
}
