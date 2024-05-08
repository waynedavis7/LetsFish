namespace LetsFish.Application.Core.Database;

internal class UnitOfWork : IDisposable, IUnitOfWork
{
    private readonly LetsFishContext _letsFishContext;
    private GenericRespository<Captain>? _captainRepository;

    public UnitOfWork(LetsFishContext letsFishContext)
    {
        _letsFishContext = letsFishContext;
    }

    public GenericRespository<Captain> CaptainRepository
    {
        get
        {
            if (_captainRepository == null)
            {
                _captainRepository = new GenericRespository<Captain>(_letsFishContext);
            }
            return _captainRepository;
        }
    }

    public async Task Save()
    {
        await _letsFishContext.SaveChangesAsync();
    }


    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _letsFishContext.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
