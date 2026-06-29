using OlmsApp.DTOs;
using OlmsApp.Shared;
namespace OlmsApp.Interfaces;

public interface IPatientService
{
    public OperationResult InsertPatient(CreatePatientDto patientDto);
    public OperationResult UpdatePatient(UpdatePatientDto patientDto);
    public OperationResult DeletePatient(Guid patientId);
    public OperationResult<IReadOnlyList<PatientDto>> GetPatients();
    public OperationResult<PatientDto> GetPatientById(Guid id);
}