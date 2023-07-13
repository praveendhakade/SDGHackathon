namespace sdgshackathon.Dtos
{
    public partial class AddCustomerDto
    {
        public string Title {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Phone {get; set;}
        public string Aadhar {get; set;}
        public string Pan {get; set;}
        public string Gender {get; set;}
        public DateTime DateOfBirth {get; set;}
        public string Occupation {get; set;}

        public AddCustomerDto()
        {
            if (Title == null) 
            {
                Title = "";
            }
            if (FirstName == null) 
            {
                FirstName = "";
            }
            if (LastName == null) 
            {
                LastName = "";
            }
            if (Gender == null) 
            {
                Gender = "";
            }
            if (Email == null) 
            {
                Email = "";
            }
            if (Occupation == null) 
            {
                Occupation = "";
            }
            if (Phone == null) 
            {
                Phone = "";
            }
            if (Pan == null) 
            {
                Pan = "";
            }
            if (Aadhar == null) 
            {
                Aadhar = "";
            }
        }
    }
}