using Karaoke_api.AggregateModels.ShiftAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Infrastructures.Repositories
{
    public class ShiftRepository:IShiftRepository
    {
        IMongoCollection<Shift> _shifts;
        public ShiftRepository(IMongoCollection<Shift> shifts)
        {
            _shifts = shifts;
        }
        public Shift AddShift(Shift shift) { 
            _shifts.InsertOne(shift);
            return shift;
        }
        public void UpdateShift(Shift shift) { 
            var shiftDoc = _shifts.Find(s =>s.Id== shift.Id).FirstOrDefault();
            if (shiftDoc != null)
            {
                shiftDoc.Update(shift);
                _shifts.ReplaceOne(s =>s.Id ==shift.Id, shiftDoc);
            }
            else
            {
                throw new Exception(" Shift doesn't exist in database");
            }    
        }
        public void DeleteShift(Shift shift) { 
            _shifts.DeleteOne(s =>s.Id == shift.Id);
        }
    }
}
