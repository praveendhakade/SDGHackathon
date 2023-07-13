namespace sdgshackathon.Dtos
{
    public partial class PostAddressDto
    {
        // public int AddressId { get; set; }
        public int HouseNo { get; set; }
        public int CustomerId { get; set; }
        public string Tower { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string Country { get; set; }
        public string StateName { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }

        public PostAddressDto()
        {
            if (Tower == null) 
            {
                Tower = "";
            }
            if (StreetAddress1 == null) 
            {
                StreetAddress1 = "";
            }
            if (StreetAddress2 == null) 
            {
                StreetAddress2 = "";
            }
            if (Country == null) 
            {
                Country = "";
            }
            if (StateName == null) 
            {
                StateName = "";
            }
            if (City == null) 
            {
                City = "";
            }
        }
    }
}