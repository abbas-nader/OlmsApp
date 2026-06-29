using OlmsApp.DTOs;
using OlmsApp.Interfaces;
using OlmsApp.Models;

namespace OlmsApp.Services;

public class PatientService( IPatientService iPatientService): IPatientService
{
    public void InsertPatient(CreatePatientDto patientDto)
    {
        
    }

    public bool UpdatePatient(UpdatePatientDto patientDto)
    {
        throw new NotImplementedException();
    }

    public void DeletePatient(int patientId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<PatientDto> GetPatients()
    {
        throw new NotImplementedException();
    }

    public PatientDto? GetPatientById(int id)
    {
        throw new NotImplementedException();
    }
}