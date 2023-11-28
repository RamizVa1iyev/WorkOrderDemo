using MediatR;

namespace WorkOrderDemo.Api.Application.Features.Commends.DeleteVisit;

public class DeleteVisitCommand:IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteVisitCommand(Guid ıd)
    {
        Id = ıd;
    }
}
