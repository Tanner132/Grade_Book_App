using System;
using GradeBookApi.Models;
using GradeBookApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GradeBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeBookController : ControllerBase
    {
        private readonly GradeBookService _GradeBookService;

        public GradeBookController(GradeBookService GradebookService)
        {
            _GradeBookService = GradebookService;
        }

        [HttpGet]
        public ActionResult<List<Grades>> Get() =>
            _GradeBookService.Get();

        [HttpGet("{id:length(24)}", Name = "getGrade")]
        public ActionResult<Grades> Get(string id)
        {
            var Grade = _GradeBookService.Get(id);

            if (Grade == null)
            {
                return NotFound();
            }

            return Grade;
        }

        [HttpPost]
        public ActionResult<Grades> Create(Grades Grade)
        {
            _GradeBookService.Create(Grade);

            return CreatedAtRoute("getGrade", new { id = Grade.Id.ToString() }, Grade);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Grades GradeIn)
        {
            var Grade = _GradeBookService.Get(id);

            if (Grade == null)
            {
                return NotFound();
            }

            _GradeBookService.Update(id, GradeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Grade = _GradeBookService.Get(id);

            if (Grade == null)
            {
                return NotFound();
            }

            _GradeBookService.Remove(Grade.Id);

            return NoContent();
        }
    }
}
