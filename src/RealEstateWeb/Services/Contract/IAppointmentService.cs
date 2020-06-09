namespace RealEstateWeb.Services.Contract
{
    public interface IAppointmentService
    {
        void Create(int propertyId, string username);
    }
}