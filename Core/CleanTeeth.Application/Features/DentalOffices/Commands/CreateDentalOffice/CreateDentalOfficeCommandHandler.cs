using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommandHandler
{
    private readonly IDentalOfficeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDentalOfficeCommandHandler(
        IDentalOfficeRepository repository,
        IUnitOfWork unitOfWork
        )
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateDentalOfficeCommand command, CancellationToken cancellationToken)
    {
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
