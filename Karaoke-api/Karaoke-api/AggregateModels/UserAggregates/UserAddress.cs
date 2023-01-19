namespace Karaoke_api.AggregateModels.UserAggregates
{
    public class UserAddress
    {
        public UserAddress() { }
        public UserAddress(string city, string country, string ward, string street)
        {
            this.city = city;
            this.country = country;
            this.ward = ward;
            this.street = street;
        }
        public string city { get; private set; }
        public string country { get;private set; }
        public string ward { get; private set; }
        public string street { get; private set; }
    }
}
