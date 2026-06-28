using OlmsApp.Models;

namespace OlmsApp.Interfaces;

public interface IPatientRepository
{
    public void Insert(Patient patient);
    public void Update(Patient patient);
    public void Delete(Patient patient);
    public List<Patient>? Select();
}