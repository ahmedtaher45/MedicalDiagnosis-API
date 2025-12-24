using Diagnosis.Application.UseCases.Dashboard.DoctorDashboard;
using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers.AdminControllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly GetAllDoctorsUseCase _getAllDoctorsUseCase;
        private readonly GetDoctorByIdUseCase _getDoctorByIdUseCase;
        private readonly CreateDoctorUseCase _createDoctorUseCase;
        private readonly UpdateDoctorUseCase _updateDoctorUseCase;
        private readonly DeleteDoctorUseCase _deleteDoctorUseCase;
        private readonly SearchDoctorsUseCase _searchDoctorsUseCase;

        public DoctorsController(
            GetAllDoctorsUseCase getAllDoctorsUseCase,
            GetDoctorByIdUseCase getDoctorByIdUseCase,
            CreateDoctorUseCase createDoctorUseCase,
            UpdateDoctorUseCase updateDoctorUseCase,
            DeleteDoctorUseCase deleteDoctorUseCase,
            SearchDoctorsUseCase searchDoctorsUseCase)
        {
            _getAllDoctorsUseCase = getAllDoctorsUseCase;
            _getDoctorByIdUseCase = getDoctorByIdUseCase;
            _createDoctorUseCase = createDoctorUseCase;
            _updateDoctorUseCase = updateDoctorUseCase;
            _deleteDoctorUseCase = deleteDoctorUseCase;
            _searchDoctorsUseCase = searchDoctorsUseCase;
        }

       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var doctors = await _getAllDoctorsUseCase.ExecuteAsync();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving doctors", error = ex.Message });
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
                var doctor = await _getDoctorByIdUseCase.ExecuteAsync(id);
                if (doctor == null)
                    return NotFound(new { message = $"Doctor with ID {id} not found" });

                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving doctor", error = ex.Message });
            }
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateDoctorDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var doctor = await _createDoctorUseCase.ExecuteAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = doctor.Id }, doctor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error creating doctor", error = ex.Message });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDoctorDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _updateDoctorUseCase.ExecuteAsync(id, dto);
                if (!result)
                    return NotFound(new { message = $"Doctor with ID {id} not found" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error updating doctor", error = ex.Message });
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
                var result = await _deleteDoctorUseCase.ExecuteAsync(id);
                if (!result)
                    return NotFound(new { message = $"Doctor with ID {id} not found" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error deleting doctor", error = ex.Message });
            }
        }

        
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            try
            {
                var doctors = await _searchDoctorsUseCase.ExecuteAsync(term ?? string.Empty);
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error searching doctors", error = ex.Message });
            }
        }
    }
    }