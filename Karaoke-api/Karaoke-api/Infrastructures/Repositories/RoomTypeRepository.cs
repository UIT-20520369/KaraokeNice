using Karaoke_api.AggregateModels.RoomTypeAggregates;
using MongoDB.Driver;

namespace Karaoke_api.Infrastructures.Repositories
{
    public class RoomTypeRepository:IRoomTypeRepository
    {
        IMongoCollection<RoomType> _roomtypes;
        public RoomTypeRepository(IMongoCollection<RoomType> roomtypes)
        {
            _roomtypes = roomtypes;
        }

        public RoomType AddRoomType(RoomType roomType) {
            _roomtypes.InsertOne(roomType);
            return roomType;
        }
        public void DeleteRoomType(RoomType roomType) {
            _roomtypes.DeleteOne(r => r.Id== roomType.Id);
        }
        public void UpdateRoomType (RoomType roomType) {
            var rt = _roomtypes.Find(rt => rt.Id== roomType.Id).FirstOrDefault();
            if (rt!=null)
            {
                throw new Exception("RoomType doesn't exists in database");
            }
            else
            {
                rt.Update(roomType);
                _roomtypes.ReplaceOne(r=>r.Id==roomType.Id,rt);
            }    
        
        }
    }
}
