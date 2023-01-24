using Karaoke_api.AggregateModels.ServiceAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Infrastructures.Repositories
{
    public class ServiceRepository:IServiceRepository
    {
        IMongoCollection<Service> _services;
        public ServiceRepository(IMongoCollection<Service> services)
        {
            _services = services;
        }
        public Service AddService(Service service) {
            _services.InsertOne(service);
            return service;
        }
        public void DeleteService(Service service)
        {
            _services.DeleteOne(sv => sv.Id == service.Id);
        }
        public void UpdateService(Service service) {
            var serviceDoc = _services.Find(sv=>sv.Id == service.Id).FirstOrDefault();
            if (serviceDoc != null)
            {
                serviceDoc.Update(service);
                _services.ReplaceOne(sv => sv.Id == service.Id, serviceDoc);
            }
            else
            {
                throw new Exception("Service doesn't exist in database");
            }    
        }
    }
}
