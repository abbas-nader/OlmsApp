using Microsoft.AspNetCore.Mvc;
using OlmsApp.ActionFilter;
using OlmsApp.DTOs;
using OlmsApp.Interfaces;

namespace OlmsApp.Controllers;

[ApiController]
[Route("api/[controller]")]
[ServiceFilter(typeof(AuthorizeActionFilter))]
public class PatientController(IPatientService patientService) : ControllerBase
{
    private readonly IPatientService _patientService = patientService;

    [HttpPost]
    public IActionResult CreatePatient([FromBody] CreatePatientDto patient)
    {
        var result = _patientService.InsertPatient(patient);
        return !result.IsSuccess ? BadRequest(result.Message) : Ok(result);
    }

    [HttpGet]
    public IActionResult GetAllPatients()
    {
        var result = _patientService.GetPatients();
        return !result.IsSuccess ? NotFound(result.Message) : Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetPatientById(Guid id)
    {
        var result = _patientService.GetPatientById(id);
        return !result.IsSuccess ? NotFound(result.Message) : Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePatient(Guid id)
    {
        _patientService.GetPatientById(id);
        var result = _patientService.DeletePatient(id);
        return !result.IsSuccess ? NotFound(result.Message) : Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePatient([FromRoute] Guid id, [FromBody] UpdatePatientDto patient)
    {
        patient.Id = id;
        _patientService.GetPatientById(id);
        var result = _patientService.UpdatePatient(patient);
        return !result.IsSuccess ? NotFound(result.Message) : Ok(result);
    }
}