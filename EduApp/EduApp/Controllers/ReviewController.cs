using EduApp.Core.Requests.Review;
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
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("List")]
        public async Task<IActionResult> GetReviewList([FromBody] ReviewListRequest request)
        {
            try
            {
                var response = await _reviewService.GetReviewList(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview([FromRoute] GetReviewRequest request)
        {
            try
            {
                var review = await _reviewService.GetReview(request);

                return Ok(review);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveReview([FromRoute] RemoveReviewRequest request)
        {
            try
            {
                var review = await _reviewService.RemoveReview(request);

                return Ok(review);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewRequest request)
        {
            try
            {
                var review = await _reviewService.CreateReview(request);

                return Ok(review);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update/{id}")]
        public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewRequest request)
        {
            try
            {
                var review = await _reviewService.UpdateReview(request);

                return Ok(review);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
