using Karaoke_api.AggregateModels.Seedwork;
namespace Karaoke_api.AggregateModels.ShiftDetailAggregates
{
    public interface IShiftDetailRepository:IRepository<ShiftDetail>
    {
        public ShiftDetail AddShiftDetail(ShiftDetail shiftDetail);
        public void UpdateShiftDetail(ShiftDetail shiftDetail);
        public void DeleteShiftDetail(ShiftDetail shiftDetail);

    }
}
