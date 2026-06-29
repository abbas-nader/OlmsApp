using OlmsApp.Interfaces;
using OlmsApp.Models;

namespace OlmsApp.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly List<Patient>  _patients = [];

    public void Insert(Patient patient)
    {
        _patients.Add(patient);
    }

    public bool Update(Patient patient)
    {
        var existingPatient = _patients.FirstOrDefault(p => p.Id == patient.Id);
        if (existingPatient == null)
            return false;
        existingPatient.FirstName = patient.FirstName;
        existingPatient.LastName = patient.LastName;
        existingPatient.NationalCode = patient.NationalCode;
        existingPatient.PhoneNumber = patient.PhoneNumber;
        return true;
    }

    public void Delete(int patientId)
    {
        var patientToDelete = _patients.FirstOrDefault(p => p.Id == patientId);
        if (patientToDelete == null)
            return;
        _patients.Remove(patientToDelete);
    }

    public IReadOnlyList<Patient> GetAll()
    {
        return _patients;
    }

    public Patient? GetById(int patientId)
    {
          return _patients.FirstOrDefault(p => p.Id == patientId);
    }
}