using Karaoke_api.AggregateModels.ServiceAggregates;
using Karaoke_api.Infrastructures.Repositories;
namespace Karaoke_api.Features.ServiceFeatures.ServiceMutations
{
    [ExtendObjectType(name: "Mutation")]
    public class ServiceMutations
    {
        private readonly IServiceRepository _servicesRepository;
        public ServiceMutations(IServiceRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }
        
        public string CreateService (string name, string type,string thumbnail)
        {
            var service = new Service(name, type, thumbnail);
            var addService =_servicesRepository.AddService(service);
            return addService.Id;
        }

        public string UpdateService (string id, string? name,string? type, string? thumbnail)
        {
            var service = new Service(name, type, thumbnail,id);
            _servicesRepository.UpdateService(service);
            return id;
        }

        public string DeleteService(string id, string? name, string? type, string? thumbnail)
        {
            var service = new Service(name, type, thumbnail, id);
            _servicesRepository.DeleteService(service);
            return id;
        }
    }
}
