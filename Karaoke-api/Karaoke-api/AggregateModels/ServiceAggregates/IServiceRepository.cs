using Karaoke_api.AggregateModels.Seedwork;
using Karaoke_api.AggregateModels.ServiceAggregates;
namespace Karaoke_api.AggregateModels.ServiceAggregates
{
    public interface IServiceRepository :IRepository<Service>
    {
        public Service AddService(Service service);
        public void UpdateService(Service service);
        public void DeleteService(Service service);
    }
}
