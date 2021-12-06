using EduApp.Core.Requests.Homework;
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
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkService _homeworkService;

        public HomeworkController(IHomeworkService homeworkService)
        {
            _homeworkService = homeworkService;
        }

        [HttpPost("List")]
        public async Task<IActionResult> GetHomeworkList([FromBody] HomeworkListRequest request)
        {
            try
            {
                var response = await _homeworkService.GetHomeworkList(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHomework([FromRoute] GetHomeworkRequest request)
        {
            try
            {
                var homework = await _homeworkService.GetHomework(request);

                return Ok(homework);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveHomework([FromRoute] RemoveHomeworkRequest request)
        {
            try
            {
                var homework = await _homeworkService.RemoveHomework(request);

                return Ok(homework);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateHomework([FromBody] CreateHomeworkRequest request)
        {
            try
            {
                var homework = await _homeworkService.CreateHomework(request);

                return Ok(homework);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update/{id}")]
        public async Task<IActionResult> UpdateHomework([FromBody] UpdateHomeworkRequest request)
        {
            try
            {
                var homework = await _homeworkService.UpdateHomework(request);

                return Ok(homework);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
