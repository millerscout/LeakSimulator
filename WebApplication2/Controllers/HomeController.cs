using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        public ConcurrentBag<object> list = new ConcurrentBag<object>();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public Task[] tasks;
        private static Random random = new Random();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        [HttpGet]
        public string Get()
        {
            return "hello world";
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
            return Ok("foi :devillaugh:");
        }
    }
}
