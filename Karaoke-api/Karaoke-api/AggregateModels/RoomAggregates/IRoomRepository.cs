using Karaoke_api.AggregateModels.Seedwork;
namespace Karaoke_api.AggregateModels.RoomAggregates
{
    public interface IRoomRepository :IRepository<Room>
    {
        public Room AddRoom(Room room);
        public void UpdateRoom(Room room);
        public void DeleteRoom(Room room);
    }
}
