using WpfServiceTask.Classes;
using WpfServiceTask.Classes.OrderData;

namespace WpfServiceTask.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        GenericRepository<Order> Orders { get; }
        GenericRepository<RestaurantData> Restaurants { get; }
        GenericRepository<GoodsData> Goods { get; }
        GenericRepository<Address> Addresses { get; }
        GenericRepository<ClientData> Clients { get; }
        void Save();
    }
}
