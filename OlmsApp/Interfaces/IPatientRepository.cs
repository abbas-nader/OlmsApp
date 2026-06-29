using OlmsApp.Models;

namespace OlmsApp.Interfaces;

public interface IPatientRepository
{
    public void Insert(Patient patient);
    public bool Update(Patient patient);
    public bool Delete(Guid patientId);
    public IReadOnlyList<Patient>  GetAll();
    public Patient? GetById(Guid patientId);
}