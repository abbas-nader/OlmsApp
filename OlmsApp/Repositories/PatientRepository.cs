using OlmsApp.Interfaces;
using OlmsApp.Models;

namespace OlmsApp.Repositories;

public class PatientRepository : IPatientRepository
{
    private static readonly List<Patient>  Patients = [];

    public void Insert(Patient patient)
    {
        Patients.Add(patient);
    }

    public bool Update(Patient patient)
    {
        var existingPatient = Patients.FirstOrDefault(p => p.Id == patient.Id);
        if (existingPatient == null)
            return false;
        existingPatient.FirstName = patient.FirstName;
        existingPatient.LastName = patient.LastName;
        existingPatient.NationalCode = patient.NationalCode;
        existingPatient.PhoneNumber = patient.PhoneNumber;
        return true;
    }

    public bool Delete(Guid patientId)
    {
        var patientToDelete = Patients.FirstOrDefault(p => p.Id == patientId);
        if (patientToDelete == null)
            return false;
        Patients.Remove(patientToDelete);
        return true;
    }

    public IReadOnlyList<Patient> GetAll()
    {
        return Patients;
    }

    public Patient? GetById(Guid patientId)
    {
          return Patients.FirstOrDefault(p => p.Id == patientId);
    }
}