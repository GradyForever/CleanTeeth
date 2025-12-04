using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Domain.Entities;
using FluentValidation;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommandHandler
{
    private readonly IDentalOfficeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateDentalOfficeCommand> _validator;

    public CreateDentalOfficeCommandHandler(
        IDentalOfficeRepository repository,
        IUnitOfWork unitOfWork,
        IValidator<CreateDentalOfficeCommand> validator
        )
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Guid> Handle(CreateDentalOfficeCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new CustomValidationException(validationResult);
        }

        DentalOffice dentalOffice = new(command.Name);

        try
        {
            var item = await _repository.AddAsync(dentalOffice, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return item.Id;
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
