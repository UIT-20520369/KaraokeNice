namespace Karaoke_api.Infrastructures.BsonMapping
{
    public static partial class BsonMapping
    {
        public static void CreateBsonMapping()
        {
           CreateUserBsonMapping();
            CreateRoleBsonMapping();
            CreateEmployeeBsonMapping();
            CreateRoomTypeBsonMapping();
        }
    }
}
