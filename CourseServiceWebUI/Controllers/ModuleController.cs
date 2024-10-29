using CourseDAL.Entities;
using CourseDAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseServiceWebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly ILogger<ModuleController> _logger;

        private IModuleRepository _moduleRepository;

        public ModuleController(ILogger<ModuleController> logger, IModuleRepository moduleRepository)
        {
            _logger = logger;
            _moduleRepository = moduleRepository;
        }

        [HttpGet("GetAllModules")]
        public async Task<ActionResult> GetAllModulesAsync()
        {
            try
            {
                var results = await _moduleRepository.GetAllModulesAsync();
                _logger.LogInformation($"Reurned all modules from database.");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Transaction Failed! Something went wrong inside GetAllModulesAsync() action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}", Name = "GetModuleById")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _moduleRepository.GetModuleByIdAsync(id);
                if (result == null)
                {
                    _logger.LogError($"Module with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned module with id: {id}");
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAsync action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost("PostModule")]
        public async Task<ActionResult> PostModuleAsync([FromBody] ModuleEntity newModule)
        {
            try
            {
                if (newModule == null)
                {
                    _logger.LogError("Module object sent from client is null.");
                    return BadRequest("Module object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Module object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var created_id = await _moduleRepository.AddModuleAsync(newModule.Title, newModule.Description, newModule.Duration, newModule.CourseId);
                var CreatedModule = await _moduleRepository.GetModuleByIdAsync(created_id);
                return CreatedAtRoute("GetModuleById", new { id = created_id }, CreatedModule);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside PostModuleAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("Put/{id}")]
        public async Task<ActionResult> PutModuleAsync(int id, [FromBody] ModuleEntity updateModule)
        {
            try
            {
                if (updateModule == null)
                {
                    _logger.LogError("Module object sent from client is null.");
                    return BadRequest("Module object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid module object sent from client.");
                    return BadRequest("Invalid module object");
                }
                var ModuleEntity = await _moduleRepository.GetModuleByIdAsync(id);
                if (ModuleEntity == null)
                {
                    _logger.LogError($"module with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                await _moduleRepository.UpdateModuleAsync(updateModule.Id, updateModule.Title, updateModule.Description, updateModule.Duration, updateModule.CourseId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside PutModuleAsync action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteModuleAsync(int id)
        {
            try
            {
                var moduleEntity = await _moduleRepository.GetModuleByIdAsync(id);
                if (moduleEntity == null)
                {
                    _logger.LogError($"Module with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                await _moduleRepository.DeleteModuleAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteModuleAsync action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
