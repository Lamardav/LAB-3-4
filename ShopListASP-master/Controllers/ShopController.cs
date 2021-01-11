using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentList.Models;

namespace StudentList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        public static List<Student> shop = new List<Student>();
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<shop> Get()
        {
            return shop;
        }

        [HttpGet("last-id")]
        public int GetLastId()
        {
            return shop.Count > 0 ? shop[^1].id + 1 : 0;
        }

        [HttpPut]
        [Consumes("application/json")]
        public IActionResult Add(shop s)
        {
            students.Add(s);
            return Created("/student", s);
        }

        [HttpPost]
        public IActionResult Edit(shop s)
        {
            Student temp = shop.Find(shop => shop.id == s.id);
            temp.fio = s.fio;
   
            return Accepted();
        }

        [HttpDelete]
        public IActionResult Delete(IEnumerable<int> m)
        {
            List<Student> temp = .FindAll(s => m.Any(i => i == s.id));
            foreach(var t in temp)
                shop.Remove(t);
            return Accepted();
        }
    }
}