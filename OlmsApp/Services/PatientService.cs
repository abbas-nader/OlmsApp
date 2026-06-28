using OlmsApp.Interfaces;
using OlmsApp.Models;

namespace OlmsApp.Services;

public class PatientService( IPatientService iPatientService): IPatientService
{
    public void InsertPatient(Patient patient)
    {
    }

    public void UpdatePatient(Patient patient)
    {
        throw new NotImplementedException();
    }

    public void DeletePatient(Patient patient)
    {
        throw new NotImplementedException();
    }

    public List<Patient> GetPatients()
    {
        throw new NotImplementedException();
    }
}