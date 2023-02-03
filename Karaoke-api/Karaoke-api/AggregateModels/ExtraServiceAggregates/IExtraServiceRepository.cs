using Karaoke_api.AggregateModels.Seedwork;
namespace Karaoke_api.AggregateModels.ExtraServiceAggregates
{
    public interface IExtraServiceRepository:IRepository<ExtraService>
    {
        public ExtraService AddExtraService (ExtraService extraService);
        public void UpdateExtraService (ExtraService extraService);
        public void DeleteExtraService(ExtraService extraService);
        
    }
}
