using CourseDAL.Entities;
using CourseDAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseServiceWebUI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;

        private IUnitOfWorkDapper _unitOfWork;

        public CourseController(ILogger<CourseController> logger, IUnitOfWorkDapper unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllCourses")]
        public async Task<ActionResult<IEnumerable<CourseEntity>>> GetAllCoursesAsync()
        {
            try
            {
                var results = await _unitOfWork._courseRepository.GetAllAsync();
                _unitOfWork.Commit();
                _logger.LogInformation($"Reurned all courses from database.");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Transaction Failed! Something went wrong inside GetAllCoursesAsync() action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}", Name = "GetCourseById")]


        public async Task<ActionResult<IEnumerable<CourseEntity>>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork._courseRepository.GetAsync(id);
                _unitOfWork.Commit();
                if (result == null)
                {
                    _logger.LogError($"Course with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned course with id: {id}");
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAsync action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("GetCoursesWithModules")]
        public async Task<ActionResult<IEnumerable<CourseEntity>>> GetCoursesWithModules()
        {
            try
            {
                var results = await _unitOfWork._courseRepository.GetCoursesWithModules();
                _unitOfWork.Commit();
                _logger.LogInformation($"Returned top five courses from database.");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Transaction Failed! Something went wrong inside GetCoursesWithModules action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("GetCoursesWithModuleCount")]
        public async Task<ActionResult<IEnumerable<CourseEntity>>> GetCoursesWithModuleCount()
        {
            try
            {
                var results = await _unitOfWork._courseRepository.GetCoursesWithModuleCount();
                _unitOfWork.Commit();
                _logger.LogInformation($"Returned top five courses from database.");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Transaction Failed! Something went wrong inside GetCoursesWithModuleCount action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost("PostCourse")]
        public async Task<ActionResult> PostAsync([FromBody] CourseEntity newCourse)
        {
            try
            {
                if (newCourse == null)
                {
                    _logger.LogError("Course object sent from client is null.");
                    return BadRequest("Course object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Course object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var created_id = await _unitOfWork._courseRepository.AddAsync(newCourse);
                var CreatedCourse = await _unitOfWork._courseRepository.GetAsync(created_id);
                _unitOfWork.Commit();
                return CreatedAtRoute("GetCourseById", new { id = created_id }, CreatedCourse);
                //return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside PostCourseAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("Put/{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] CourseEntity updateCourse)
        {
            try
            {
                if (updateCourse == null)
                {
                    _logger.LogError("Course object sent from client is null.");
                    return BadRequest("Course object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid course object sent from client.");
                    return BadRequest("Invalid course object");
                }
                var CourseEntity = await _unitOfWork._courseRepository.GetAsync(id);
                if (CourseEntity == null)
                {
                    _logger.LogError($"course with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                await _unitOfWork._courseRepository.ReplaceAsync(updateCourse);
                _unitOfWork.Commit();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside PutAsync action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var courseEntity = await _unitOfWork._courseRepository.GetAsync(id);
                if (courseEntity == null)
                {
                    _logger.LogError($"Course with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                await _unitOfWork._courseRepository.DeleteAsync(id);
                _unitOfWork.Commit();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Course action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
