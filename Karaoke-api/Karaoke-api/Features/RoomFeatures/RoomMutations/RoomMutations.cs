using Karaoke_api.AggregateModels.RoomAggregates;
using Karaoke_api.Infrastructures.Repositories;
namespace Karaoke_api.Features.RoomFeatures.RoomMutations
{
    [ExtendObjectType(name: "Mutation")]
    public class RoomMutations
    {
        private readonly IRoomRepository roomRepository;
        public RoomMutations(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public string CreateRoom(string typeId, string number)
        {
            var room = new Room(number,typeId);
            var res = roomRepository.AddRoom(room);
            return res.Id;
        }    
        public string UpdateRoom(string typeId, string number,string id) {
            var room = new Room(number, typeId,id);
            roomRepository.UpdateRoom(room);
            return room.Id;
        }
        public string DeleteRoom(string typeId, string number, string id)
        {
            var room = new Room(number, typeId, id);
            roomRepository.DeleteRoom(room);
            return room.Id;
        }
    }
}
