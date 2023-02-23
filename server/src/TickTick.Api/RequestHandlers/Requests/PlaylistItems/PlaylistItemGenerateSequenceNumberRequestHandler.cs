using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Requests.PlaylistItems;

public struct PlaylistItemGenerateSequenceNumberRequest : IRequest<double>
{
    public Guid? PreviousItemId { get; set; }
    public Guid? NextItemId { get; set; }
}

public class PlaylistItemGenerateSequenceNumberRequestHandler : IRequestHandler<PlaylistItemGenerateSequenceNumberRequest, double>
{
    private readonly IRepository<PlaylistItem> _repository;
    public async Task<double> Handle(PlaylistItemGenerateSequenceNumberRequest request, CancellationToken cancellationToken)
    {
        if (request.NextItemId is null && request.PreviousItemId is null)
        {
            return 0;
        }

        if (request.PreviousItemId is not null && request.NextItemId is null)
        {
            return await GetSequenceNumber(request.PreviousItemId.Value) + 1;
        }

        if (request.PreviousItemId is null && request.NextItemId is not null)
        {
            return await GetSequenceNumber(request.NextItemId.Value) - 1;
        }

        return (await GetSequenceNumber(request.PreviousItemId.Value) +
                await GetSequenceNumber(request.NextItemId.Value)) / 2;
    }
    
    private async Task<double> GetSequenceNumber(Guid id)
    {
        return await _repository.GetAll()
            .Where(x => x.Id == id)
            .Select(x => x.SequenceNumber)
            .SingleAsync();
    }
}

