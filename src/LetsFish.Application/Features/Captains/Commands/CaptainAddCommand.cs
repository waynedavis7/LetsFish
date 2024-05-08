using LetsFish.Application.Core.Database;

namespace LetsFish.Application.Features.Captains.Commands;

public  class CaptainAddCommand : ICommand<int> {
    public Captain Captain { get; set; }
}

internal class CaptainAddCommandHandler : ICommandHandler<CaptainAddCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CaptainAddCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<int>> Handle(CaptainAddCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CaptainRepository.InsertAsync(request.Captain);   
        await _unitOfWork.Save();

        return await Result<int>.SuccessAsync(request.Captain.CaptainId);
    }

}