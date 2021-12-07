using EduApp.Core.Requests.Lesson;
using EduApp.Core.Services;
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
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost("List")]
        public async Task<IActionResult> GetLessonList([FromBody] LessonListRequest request)
        {
            try
            {
                var response = await _lessonService.GetLessonList(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetLesson([FromRoute] GetLessonRequest request)
        {
            try
            {
                var lesson = await _lessonService.GetLesson(request);

                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveLesson([FromRoute] RemoveLessonRequest request)
        {
            try
            {
                var lesson = await _lessonService.RemoveLesson(request);

                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateLesson([FromBody] CreateLessonRequest request)
        {
            try
            {
                var lesson = await _lessonService.CreateLesson(request);

                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update/{id}")]
        public async Task<IActionResult> UpdateLesson([FromBody] UpdateLessonRequest request)
        {
            try
            {
                var lesson = await _lessonService.UpdateLesson(request);

                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
