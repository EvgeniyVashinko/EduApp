using EduApp.Core.Requests.Course;
using EduApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse([FromBody]GetCourseRequest request)
        {
            try
            {
                var course = await _courseService.GetCourse(request);

                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
