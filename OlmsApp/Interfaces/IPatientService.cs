using OlmsApp.DTOs;
using OlmsApp.Models;

namespace OlmsApp.Interfaces;

public interface IPatientService
{
    public void InsertPatient(CreatePatientDto patientDto);
    public bool UpdatePatient(UpdatePatientDto patientDto);
    public void DeletePatient(int patientId);
    public IReadOnlyList<PatientDto> GetPatients();
    public PatientDto?  GetPatientById(int id);
}