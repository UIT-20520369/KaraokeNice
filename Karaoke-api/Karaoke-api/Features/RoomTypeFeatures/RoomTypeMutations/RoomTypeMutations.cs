using Karaoke_api.AggregateModels.RoomTypeAggregates;
using Karaoke_api.Infrastructures.Repositories;
namespace Karaoke_api.Features.RoomTypeFeatures.RoomTypeMutations
{
    [ExtendObjectType(name: "Mutation")]
    public class RoomTypeMutations
    {
        private readonly IRoomTypeRepository roomTypeRepository;
        public RoomTypeMutations(IRoomTypeRepository roomTypeRepository)
        {
            this.roomTypeRepository = roomTypeRepository;
        }
        public string CreateRoomType(string name, string description, double areas, string[] gallery,int guests, double price, string Thumbnail, string[] services,string shortContent)
        {
            var roomType = new RoomType(name, description, gallery, guests, price, services, Thumbnail, shortContent, areas);
            var temp = roomTypeRepository.AddRoomType(roomType);
            return temp.Id;
        }
        public string UpdateRoomType(string id,string? name, string? description, double? areas, string[]? gallery, int? guests, double? price, string? Thumbnail, string?[] services, string? shortContent)
        {
            var roomType = new RoomType(name, description, gallery, guests, price, services, Thumbnail, shortContent, areas,id);
            roomTypeRepository.UpdateRoomType(roomType);
            return roomType.Id;

        }
        public string DeleteRoomType(string id, string? name, string? description, double? areas, string[]? gallery, int? guests, double? price, string? Thumbnail, string?[] services, string? shortContent)
        {
            var roomType = new RoomType(name, description, gallery, guests, price, services, Thumbnail, shortContent, areas, id);
            roomTypeRepository.DeleteRoomType(roomType);
            return roomType.Id;

        }
    }
}
