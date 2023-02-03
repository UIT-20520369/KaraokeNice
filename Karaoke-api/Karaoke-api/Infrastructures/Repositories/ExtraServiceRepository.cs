using Karaoke_api.AggregateModels.ExtraServiceAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Infrastructures.Repositories
{
    public class ExtraServiceRepository: IExtraServiceRepository
    {
        IMongoCollection<ExtraService> _extraService;
        public ExtraServiceRepository(IMongoCollection<ExtraService> extraService)
        {
            _extraService = extraService;
        }
        public ExtraService AddExtraService(ExtraService extraService) {
            _extraService.InsertOne(extraService);
            return extraService;
        }
        public void UpdateExtraService (ExtraService extraService) {
            var extraDoc = _extraService.Find(e => e.Id == extraService.Id).FirstOrDefault();
            if (extraDoc != null)
            {
                extraDoc.Update(extraService);
                _extraService.ReplaceOne(e => e.Id== extraService.Id, extraDoc);
            }
            else
            {
                throw new Exception(" Extra Service doesn't exits in database");
            }    
        
        }
        public void DeleteExtraService (ExtraService extraService) {
            _extraService.DeleteOne(e => e.Id== extraService.Id);
        }
    }
}
