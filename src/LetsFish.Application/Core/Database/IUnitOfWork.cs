
namespace LetsFish.Application.Core.Database
{
    internal interface IUnitOfWork
    {
        GenericRespository<Captain> CaptainRepository { get; }
        GenericRespository<Angler> AnglerRepository { get; }
        GenericRespository<Team> TeamRepository { get; }

        void Dispose();
        Task Save();
    }
}