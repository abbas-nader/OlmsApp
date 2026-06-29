using FluentValidation;
using OlmsApp.DTOs;
using OlmsApp.Interfaces;
using OlmsApp.Shared;
using OlmsApp.Models;

namespace OlmsApp.Services;

public class PatientService(
    IPatientRepository patientRepository,
    IValidator<CreatePatientDto> createValidator,
    IValidator<UpdatePatientDto> updateValidator) : IPatientService
{
    private readonly IPatientRepository _patientRepository = patientRepository;
    private readonly IValidator<CreatePatientDto> _createValidator = createValidator;
    private readonly IValidator<UpdatePatientDto> _updateValidator = updateValidator;

    public OperationResult InsertPatient(CreatePatientDto patientDto)
    {
        var result = _createValidator.Validate(patientDto);
        if (!result.IsValid)
        {
            var errors = string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage));
            return OperationResult.Failed(errors);
        }

        var patient = new Patient()
        {
            Id = Guid.NewGuid(),
            FirstName = patientDto.FirstName,
            LastName = patientDto.LastName,
            NationalCode = patientDto.NationalCode,
            PhoneNumber = patientDto.PhoneNumber,
        };
        _patientRepository.Insert(patient);
        return OperationResult.Success();
    }

    public OperationResult UpdatePatient(UpdatePatientDto patientDto)
    {
        var result = _updateValidator.Validate(patientDto);
        if (!result.IsValid)
        {
            var errors = string
                .Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage));
            return OperationResult.Failed(errors);
        }

        var patientForUpdate = _patientRepository.GetById(patientDto.Id);
        if (patientForUpdate == null)
            return OperationResult.Failed("Patient not found");
        patientForUpdate.FirstName = patientDto.FirstName;
        patientForUpdate.LastName = patientDto.LastName;
        patientForUpdate.NationalCode = patientDto.NationalCode;
        patientForUpdate.PhoneNumber = patientDto.PhoneNumber;
        _patientRepository.Update(patientForUpdate);
        return OperationResult.Success();
    }

    public OperationResult DeletePatient(Guid patientId)
    {
        if (patientId == Guid.Empty)
            return OperationResult.Failed("Patient not found");
        var deletedPatient = _patientRepository.Delete(patientId);
        if(!deletedPatient)
            return OperationResult.Failed("Patient not found");
        return OperationResult.Success();
    }

    public OperationResult<IReadOnlyList<PatientDto>> GetPatients()
    {
        var patients = _patientRepository.GetAll();
        var result = patients.Select(p => new PatientDto()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                NationalCode = p.NationalCode,
                PhoneNumber = p.PhoneNumber,
            }
        ).ToList();
        return OperationResult<IReadOnlyList<PatientDto>>.Success(result);
    }

    public OperationResult<PatientDto> GetPatientById(Guid id)
    {
        var patient = _patientRepository.GetById(id);

        if (patient is null)
            return OperationResult<PatientDto>.Failed("Patient not found")!;

        var patientDto = new PatientDto
        {
            Id = patient.Id,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            NationalCode = patient.NationalCode,
            PhoneNumber = patient.PhoneNumber
        };

        return OperationResult<PatientDto>.Success(patientDto);
    }
}