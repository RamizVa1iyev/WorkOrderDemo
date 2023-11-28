using MediatR;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;

namespace WorkOrderDemo.Api.Application.Features.Commends.ChangeDatas;

public class ChangeDatasCommand:IRequest<ChangingDataInformation>
{
}
