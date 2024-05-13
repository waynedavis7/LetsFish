using LetsFish.Application.Core.Database;

namespace LetsFish.Application.Features.Anglers.Commands;

public class AnglerAddCommand : ICommand<int>
{
    public Angler Angler { get; set; }
}

internal class CaptainAddCommandHandler : ICommandHandler<AnglerAddCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CaptainAddCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IResult<int>> Handle(AnglerAddCommand request, CancellationToken cancellationToken)
    {
        if (request.Angler.AnglerId > 0)
        {
            _unitOfWork.AnglerRepository.Update(request.Angler);
        }
        else
        {
            await _unitOfWork.AnglerRepository.InsertAsync(request.Angler);
        }

        await _unitOfWork.Save();

        return await Result<int>.SuccessAsync(request.Angler.AnglerId);
    }

}