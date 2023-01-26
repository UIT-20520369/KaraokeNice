using Karaoke_api.AggregateModels.ShiftDetailAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Infrastructures.Repositories
{
    public class ShiftDetailRepository:IShiftDetailRepository
    {
        IMongoCollection<ShiftDetail> _shiftDetails;
        public ShiftDetailRepository(IMongoCollection<ShiftDetail> shiftDetails)
        {
            _shiftDetails = shiftDetails;
        }
        public ShiftDetail AddShiftDetail(ShiftDetail shiftDetail) {
            _shiftDetails.InsertOne(shiftDetail);
            return shiftDetail;
        }
        public void UpdateShiftDetail(ShiftDetail shiftDetail) {
            var shiftDoc = _shiftDetails.Find(sd =>sd.Id== shiftDetail.Id).FirstOrDefault();
            if(shiftDoc != null)
            {
                shiftDoc.Update(shiftDetail);
                _shiftDetails.ReplaceOne(sd => sd.Id == shiftDoc.Id, shiftDoc);
            }
            else
            {
                throw new Exception("ShiftDetail doesn't exist in database");
            }    
        }
        public void DeleteShiftDetail(ShiftDetail shiftDetail) {
            _shiftDetails.DeleteOne(sd => sd.Id ==shiftDetail.Id);
        }
    }
}
