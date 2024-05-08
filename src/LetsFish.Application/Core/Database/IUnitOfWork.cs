
namespace LetsFish.Application.Core.Database
{
    internal interface IUnitOfWork
    {
        GenericRespository<Captain> CaptainRepository { get; }

        void Dispose();
        Task Save();
    }
}