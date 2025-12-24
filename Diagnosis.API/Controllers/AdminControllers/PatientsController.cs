
using Diagnosis.Application.UseCases.Dashboard.PatiantDashboard;
using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers.AdminControllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly GetAllPatientsUseCase _getAllPatientsUseCase;
        private readonly GetPatientByIdUseCase _getPatientByIdUseCase;
        private readonly CreatePatientUseCase _createPatientUseCase;
        private readonly UpdatePatientUseCase _updatePatientUseCase;
        private readonly DeletePatientUseCase _deletePatientUseCase;
        private readonly SearchPatientsUseCase _searchPatientsUseCase;

        public PatientsController(
            GetAllPatientsUseCase getAllPatientsUseCase,
            GetPatientByIdUseCase getPatientByIdUseCase,
            CreatePatientUseCase createPatientUseCase,
            UpdatePatientUseCase updatePatientUseCase,
            DeletePatientUseCase deletePatientUseCase,
            SearchPatientsUseCase searchPatientsUseCase)
        {
            _getAllPatientsUseCase = getAllPatientsUseCase;
            _getPatientByIdUseCase = getPatientByIdUseCase;
            _createPatientUseCase = createPatientUseCase;
            _updatePatientUseCase = updatePatientUseCase;
            _deletePatientUseCase = deletePatientUseCase;
            _searchPatientsUseCase = searchPatientsUseCase;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var patients = await _getAllPatientsUseCase.ExecuteAsync();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving patients", error = ex.Message });
            }
        }

     
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var patient = await _getPatientByIdUseCase.ExecuteAsync(id);
                if (patient == null)
                    return NotFound(new { message = $"Patient with ID {id} not found" });

                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving patient", error = ex.Message });
            }
        }

       
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreatePatientDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var patient = await _createPatientUseCase.ExecuteAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error creating patient", error = ex.Message });
            }
        }

     
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] CreatePatientDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _updatePatientUseCase.ExecuteAsync(id, dto);
                if (!result)
                    return NotFound(new { message = $"Patient with ID {id} not found" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error updating patient", error = ex.Message });
            }
        }

 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _deletePatientUseCase.ExecuteAsync(id);
                if (!result)
                    return NotFound(new { message = $"Patient with ID {id} not found" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error deleting patient", error = ex.Message });
            }
        }

        
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            try
            {
                var patients = await _searchPatientsUseCase.ExecuteAsync(term ?? string.Empty);
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error searching patients", error = ex.Message });
            }
        }
    }
    }