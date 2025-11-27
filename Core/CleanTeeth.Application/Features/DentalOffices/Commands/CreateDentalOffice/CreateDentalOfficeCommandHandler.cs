using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommandHandler
{
    private readonly IDentalOfficeRepository _repository;

    public CreateDentalOfficeCommandHandler(
        IDentalOfficeRepository repository
        )
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateDentalOfficeCommand command, CancellationToken cancellationToken)
    {
        DentalOffice dentalOffice = new(command.Name);

        var item = await _repository.AddAsync(dentalOffice, cancellationToken);

        return item.Id;
    }
}
