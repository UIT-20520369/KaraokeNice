using Karaoke_api.AggregateModels.ShiftAggregates;
using Karaoke_api.Infrastructures.Repositories;
namespace Karaoke_api.Features.ShiftFeatures.ShiftMutations
{
    [ExtendObjectType(name: "Mutation")]
    public class ShiftMutations
    {
        private readonly IShiftRepository shiftRepository;
        public ShiftMutations(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }

        public string CreateShift(string name, DateTime start, DateTime end)
        {
            var shift = new Shift(name,start, end);
            var temp = shiftRepository.AddShift(shift);
            return temp.Id;
        }

        public string UpdateShift(string id,string? name, DateTime? start, DateTime? end)
        {
            var shift = new Shift(name, start, end,id);
            shiftRepository.UpdateShift(shift);
            return shift.Id;
        }
        public string DeleteShift(string id, string? name, DateTime? start, DateTime? end)
        {
            var shift = new Shift(name, start, end, id);
            shiftRepository.DeleteShift(shift);
            return shift.Id;
        }
    }
}
