﻿using LetsFish.Application.Core.Database;

namespace LetsFish.Application.Features.Captains.Queries;

public class AnglersQuery : IQuery<IEnumerable<Captain>> { }

internal class CaptainsQueryHandler : IQueryHandler<AnglersQuery, IEnumerable<Captain>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CaptainsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<IEnumerable<Captain>>> Handle(AnglersQuery request, CancellationToken cancellationToken)
    {
        var captains = await _unitOfWork.CaptainRepository.GetAllAsync();
        return Result<IEnumerable<Captain>>.Success(captains);
    }
}