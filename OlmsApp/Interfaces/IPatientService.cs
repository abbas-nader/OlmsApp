using OlmsApp.Models;

namespace OlmsApp.Interfaces;

public interface IPatientService
{
    public void InsertPatient(Patient patient);
    public void UpdatePatient(Patient patient);
    public void DeletePatient(Patient patient);
    public List<Patient> GetPatients();
}