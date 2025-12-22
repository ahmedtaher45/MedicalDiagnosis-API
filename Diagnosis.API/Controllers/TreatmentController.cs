using Diagnosis.Application.DTOs;
using Diagnosis.Application.UseCases;
using Diagnosis.Application.UseCases.Treatment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentsController : ControllerBase
    {
        private readonly GetAllTreatmentsUseCase _getAllTreatmentsUseCase;
        private readonly GetTreatmentByIdUseCase _getTreatmentByIdUseCase;
        private readonly CreateTreatmentUseCase _createTreatmentUseCase;
        private readonly GetActiveTreatmentsUseCase _getActiveTreatmentsUseCase;

        public TreatmentsController(
            GetAllTreatmentsUseCase getAllTreatmentsUseCase,
            GetTreatmentByIdUseCase getTreatmentByIdUseCase,
            CreateTreatmentUseCase createTreatmentUseCase,
            GetActiveTreatmentsUseCase getActiveTreatmentsUseCase)
        {
            _getAllTreatmentsUseCase = getAllTreatmentsUseCase;
            _getTreatmentByIdUseCase = getTreatmentByIdUseCase;
            _createTreatmentUseCase = createTreatmentUseCase;
            _getActiveTreatmentsUseCase = getActiveTreatmentsUseCase;
        }

        // GET: api/treatments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreatmentDTO>>> GetAll()
        {
            try
            {
                var treatments = await _getAllTreatmentsUseCase.ExecuteAsync();
                return Ok(treatments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/treatments/active
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<TreatmentDTO>>> GetActive()
        {
            try
            {
                var treatments = await _getActiveTreatmentsUseCase.Execute();
                return Ok(treatments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/treatments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TreatmentDTO>> GetById(int id)
        {
            try
            {
                var treatment = await _getTreatmentByIdUseCase.ExecuteAsync(id);
                if (treatment == null)
                    return NotFound(new { message = $"Treatment with ID {id} not found" });

                return Ok(treatment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/treatments
        //[HttpPost]
        //public async Task<ActionResult<TreatmentDTO>> Create([FromBody] CreateTreatmentDTO dto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest(ModelState);

        //        //var treatment = await _createTreatmentUseCase.Execute(dto);
        //        return CreatedAtAction(nameof(GetById), new { id = treatment.Id }, treatment);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}
    }

}
