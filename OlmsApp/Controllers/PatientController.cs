using Microsoft.AspNetCore.Mvc;
using OlmsApp.DTOs;
using OlmsApp.Interfaces;

namespace OlmsApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController(IPatientService patientService) : ControllerBase
{
    private readonly IPatientService _patientService = patientService;

    [HttpPost]
    public IActionResult CreatePatient([FromBody] CreatePatientDto patient)
    {
        var result = _patientService.InsertPatient(patient);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAllPatients()
    {
        var result = _patientService.GetPatients();
        if (!result.IsSuccess)
            return NotFound(result.Message);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetPatientById(Guid id)
    {
        var result = _patientService.GetPatientById(id);
        if (!result.IsSuccess)
            return NotFound(result.Message);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePatient(Guid id)
    {
        _patientService.GetPatientById(id);
        var result = _patientService.DeletePatient(id);
        if (!result.IsSuccess)
            return NotFound(result.Message);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePatient([FromRoute] Guid id, [FromBody] UpdatePatientDto patient)
    {
        patient.Id = id;
        _patientService.GetPatientById(id);
        var result = _patientService.UpdatePatient(patient);
        if (!result.IsSuccess)
            return NotFound(result.Message);
        return Ok(result);
    }
}