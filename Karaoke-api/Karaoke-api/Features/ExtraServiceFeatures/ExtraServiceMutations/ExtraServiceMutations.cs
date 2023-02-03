using Karaoke_api.AggregateModels.ExtraServiceAggregates;
using Karaoke_api.Infrastructures.Repositories;
namespace Karaoke_api.Features.ExtraServiceFeatures.ExtraServiceMutations
{
    [ExtendObjectType(name: "Mutation")]
    public class ExtraServiceMutations
    {
        private readonly IExtraServiceRepository extraServiceRepository;
        public ExtraServiceMutations(IExtraServiceRepository extraServiceRepository)
        {
            this.extraServiceRepository = extraServiceRepository;
        }    
        public string CreateExtraService(string name, string unit, double price)
        {
            var es = new ExtraService(name, price, unit);
            var res = extraServiceRepository.AddExtraService(es);
            return res.Id;
        }
        public string UpdateExtraService(string name, string unit, double price,string id)
        {
            var es = new ExtraService(name, price, unit,id);
            extraServiceRepository.UpdateExtraService(es);
            return es.Id;
        }
        public string DeleteExtraService(string name, string unit, double price, string id)
        {
            var es = new ExtraService(name, price, unit, id);
            extraServiceRepository.DeleteExtraService(es);
            return es.Id;
        }
    }
}
