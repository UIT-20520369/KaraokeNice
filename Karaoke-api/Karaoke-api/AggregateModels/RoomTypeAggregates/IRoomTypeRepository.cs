using Karaoke_api.AggregateModels.RoomTypeAggregates;
using Karaoke_api.AggregateModels.Seedwork;
namespace Karaoke_api.AggregateModels.RoomTypeAggregates
{
    public interface IRoomTypeRepository:IRepository<RoomType>
    {
        public RoomType AddRoomType(RoomType roomType);
        public void UpdateRoomType(RoomType roomType);
        public void DeleteRoomType( RoomType roomType );
    }
}
