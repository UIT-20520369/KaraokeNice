using Karaoke_api.AggregateModels.ShiftDetailAggregates;
using Karaoke_api.Infrastructures.Repositories;
namespace Karaoke_api.Features.ShiftDetailFeatures.ShiftDetailMutations
{
    [ExtendObjectType(name: "Mutation")]
    public class ShiftDetailMutations
    {
        private readonly IShiftDetailRepository shiftDetailRepository;
        public ShiftDetailMutations(IShiftDetailRepository shiftDetailRepository)
        {
            this.shiftDetailRepository = shiftDetailRepository;
        }

        public string CreateShiftDetail(string shiftId, string userId, DateTime workDay)
        {
            var shifts = new ShiftDetail(shiftId, userId, workDay);
            var res = shiftDetailRepository.AddShiftDetail(shifts);
            return res.Id;
        }

        public string UpdateShiftDetail(string id, string shiftId, string userId, DateTime workDay)
        {
            var shifts = new ShiftDetail(shiftId, userId, workDay,id);
            shiftDetailRepository.UpdateShiftDetail(shifts);
            return shifts.Id;
        }
        public string DeleteShiftDetail(string id, string shiftId, string userId, DateTime workDay)
        {
            var shifts = new ShiftDetail(shiftId, userId, workDay, id);
            shiftDetailRepository.DeleteShiftDetail(shifts);
            return shifts.Id;
        }
    }
}
