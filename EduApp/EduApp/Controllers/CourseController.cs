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

        [HttpGet("List")]
        public async Task<IActionResult> GetCourseList([FromBody] CourseListRequest request)
        {
            try
            {
                var response = await _courseService.GetCourseList(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse([FromRoute]GetCourseRequest request)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCourse([FromRoute] RemoveCourseRequest request)
        {
            try
            {
                var course = await _courseService.RemoveCourse(request);

                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest request)
        {
            try
            {
                var course = await _courseService.CreateCourse(request);

                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update/{id}")]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseRequest request)
        {
            try
            {
                var course = await _courseService.UpdateCourse(request);

                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddParticipant")]
        public async Task<IActionResult> AddParticipant([FromBody] ParticipantRequest request)
        {
            try
            {
                var course = await _courseService.AddParticipant(request);

                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RemoveParticipant")]
        public async Task<IActionResult> RemoveParticipant([FromBody] ParticipantRequest request)
        {
            try
            {
                var course = await _courseService.RemoveParticipant(request);

                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ParticipantList")]
        public async Task<IActionResult> GetCourseParticipantList([FromBody] ParticipantListRequest request)
        {
            try
            {
                var response = await _courseService.GetCourseParticipantList(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
