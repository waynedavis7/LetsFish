
namespace LetsFish.Application.Core.Database
{
    internal interface IUnitOfWork
    {
        GenericRespository<Captain> CaptainRepository { get; }
        GenericRespository<Angler> AnglerRepository { get; }

        void Dispose();
        Task Save();
    }
}