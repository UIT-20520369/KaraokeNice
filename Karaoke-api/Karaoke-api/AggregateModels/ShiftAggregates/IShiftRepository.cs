using Karaoke_api.AggregateModels.Seedwork;
using Karaoke_api.AggregateModels.ShiftAggregates;
namespace Karaoke_api.AggregateModels.ShiftAggregates
{
    public interface IShiftRepository: IRepository<Shift>
    {
        public Shift AddShift(Shift shift);
        public void UpdateShift(Shift shift);
        public void DeleteShift(Shift shift);
    }
}
