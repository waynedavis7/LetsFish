using LetsFish.Application.Core.Database;

namespace LetsFish.Application.Features.Captains.Commands;

public  class CaptainAddCommand : ICommand<int> {
    public Captain Captain { get; set; }
}

internal class CaptainAddCommandHandler : ICommandHandler<CaptainAddCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CaptainAddCommandHandler(IUnitOfWork unitOfWork , IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IResult<int>> Handle(CaptainAddCommand request, CancellationToken cancellationToken)
    {
        if (request.Captain.CaptainId > 0)
        {
            _unitOfWork.CaptainRepository.Update(request.Captain);
        }
        else
        {
            await _unitOfWork.CaptainRepository.InsertAsync(request.Captain);
        }        

        await _unitOfWork.Save();

        return await Result<int>.SuccessAsync(request.Captain.CaptainId);
    }

}