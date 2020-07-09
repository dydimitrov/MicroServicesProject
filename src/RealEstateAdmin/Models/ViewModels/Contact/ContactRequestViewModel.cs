namespace RealEstateAdmin.Models.ViewModels.Contact
{
    public class ContactRequestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string City { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
