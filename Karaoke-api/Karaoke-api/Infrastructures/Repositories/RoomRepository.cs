using Karaoke_api.AggregateModels.RoomAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Infrastructures.Repositories
{
    public class RoomRepository: IRoomRepository
    {
        IMongoCollection<Room> _rooms;
        public RoomRepository(IMongoCollection<Room> rooms)
        {
            _rooms = rooms;
        }
        public Room AddRoom(Room room) {
            _rooms.InsertOne(room);
            return room;
        }
        public void UpdateRoom(Room room) { 
            var roomDoc = _rooms.Find(r=> r.Id == room.Id).FirstOrDefault();
            if(roomDoc != null)
            {
                roomDoc.Update(room);
                _rooms.ReplaceOne(r => r.Id == room.Id, roomDoc);
            }
            else
            {
                throw new Exception("Room doesn't exist in database");
            }    
        }
        public void DeleteRoom(Room room) {
            _rooms.DeleteOne(r =>r.Id== room.Id);
        }
    }
}
