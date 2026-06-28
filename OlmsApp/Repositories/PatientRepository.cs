using OlmsApp.Interfaces;
using OlmsApp.Models;

namespace OlmsApp.Repositories;

public class PatientRepository : IPatientRepository
{
    private static readonly List<Patient>? Patients = [];

    public void Insert(Patient patient)
    {
        Patients?.Add(patient);
    }

    public void Update(Patient patient)
    {
        Patients?[Patients.IndexOf(patient)] = patient;
    }

    public void Delete(Patient patient)
    {
        Patients?.Remove(patient);
    }

    public List<Patient>? Select()
    {
        return  Patients;
    }

}