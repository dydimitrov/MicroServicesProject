using RealEstateWeb.Services.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;
using RealEstateWeb.Data;
using RealEstateWeb.Models.DbModels;
using RealEstateWeb.Models.Enums;
using RealEstateWeb.Models.ViewModels.Property;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;

namespace RealEstateWeb.Services
{
    public class PropertyService : IPropertyService
    {
        private const int MaxPropertiesPerPage = 3;
        private readonly ApplicationDbContext _context;

        public PropertyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateProperty(PropertyCreateViewModel model, string agentUsername)
        {
            try
            {
                var agent = this._context.Users.FirstOrDefault(x => x.UserName == agentUsername);

                var address = new Address
                {
                    State = model.Address.State,
                    Town = model.Address.Town,
                    Neighborhood = model.Address.Neighborhood,
                    Street = model.Address.Street
                };
                this._context.Addresses.Add(address);

                var owner = new Client
                {
                    FirstName = model.Owner.FirstName,
                    LastName = model.Owner.LastName,
                    PhoneNumber = model.Owner.PhoneNumber,
                };

                this._context.Clients.Add(owner);

                var facilities = new NearByFacilities
                {
                    FoodStores = model.Facilities.FoodStores,
                    FoodStoreDistance = model.Facilities.FoodStoreDistance,
                    Hospitals = model.Facilities.Hospitals,
                    HospitalDistance = model.Facilities.HospitalDistance,
                    School = model.Facilities.School,
                    SchoolDistance = model.Facilities.SchoolDistance
                };
                this._context.Facilitieses.Add(facilities);

                var propertyDetails = new PropertyDetails
                {
                    NumberOfBedrooms = model.PropertyDetails.NumberOfBedrooms,
                    NumberOfBeds = model.PropertyDetails.NumberOfBeds,
                    NumberOfBathrooms = model.PropertyDetails.NumberOfBathrooms,
                    HomeArea = model.PropertyDetails.HomeArea,
                    TotalArea = model.PropertyDetails.TotalArea,
                    YearOfBuild = model.PropertyDetails.YearOfBuild
                };
                this._context.PropertyDetails.Add(propertyDetails);

                var property = new Property
                {
                    Title = model.Title,
                    Address = address,
                    Owner = owner,
                    Agent = agent,
                    Currency = model.Currency,
                    Price = model.Price,
                    Description = model.Description,
                    PropertyType = model.PropertyType,
                    PropertyStatus = model.PropertyStatus,
                    PropertyPurpose = model.PropertyPurpose,
                    Facilities = facilities,
                    PropertyDetails = propertyDetails
                };

                this._context.Properties.Add(property);
                List<Picture> urlsList = this.UploadPicturesToCloudinary(model.Files);

                foreach (var picture  in urlsList)
                {
                    picture.Property = property;
                }
                this._context.Pictures.AddRange(urlsList);
                property.Pictures = urlsList;

                this._context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public List<PropertyIndexViewModel> IndexProperties()
        {
            var result = this._context.Properties
                .Include(a => a.Pictures)
                .Include(y => y.Address)
                .OrderByDescending(p => p.CreatedOn)
                .Take(3)
                .Select(x => new PropertyIndexViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Address = new AddressCreateViewModel()
                    {
                        State = x.Address.State,
                        Town = x.Address.Town,
                        Neighborhood = x.Address.Neighborhood,
                        Street = x.Address.Street
                    },
                    Price = x.Price,
                    PictureUrl = x.Pictures.FirstOrDefault().CloudUrl,
                    PropertyPurpose = x.PropertyPurpose.ToString(),
                    Currency = x.Currency
                }).ToList();

            foreach (var item in result)
            {
                item.PictureUrl = item.PictureUrl.Replace(@"upload/", "upload/h_450,w_1300/");
                item.PictureUrlMenuBottom = item.PictureUrl.Replace(@"upload/", "upload/h_130,w_150/");
            }

            return result;
        }

        public List<PropertyIndexViewModel> RandomProperties()
        {
            var result = this._context.Properties
                .Include(a => a.Pictures)
                .Include(y => y.Address)
                .OrderByDescending(p => p.Price)
                .Take(MaxPropertiesPerPage)
                .Select(x => new PropertyIndexViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Address = new AddressCreateViewModel()
                    {
                        State = x.Address.State,
                        Town = x.Address.Town,
                        Neighborhood = x.Address.Neighborhood,
                        Street = x.Address.Street
                    },
                    Price = x.Price,
                    PictureUrl = x.Pictures.FirstOrDefault().CloudUrl,
                    PropertyPurpose = x.PropertyPurpose.ToString(),
                    Currency = x.Currency
                }).ToList();
            

            foreach (var item in result)
            {
                item.PictureUrl = item.PictureUrl.Replace(@"upload/", "upload/h_450,w_1300/");
                item.PictureUrlMenuBottom = item.PictureUrl.Replace(@"upload/", "upload/h_130,w_150/");
            }

            return result;
        }

        public IEnumerable<PropertyListingViewModel> AllProperty()
        {
            return this._context
                .Properties
                .Include(x => x.Pictures)
                .Select(p => new PropertyListingViewModel()
                {
                    Id = p.Id,
                    Address = new AddressCreateViewModel()
                    {
                        State = p.Address.State,
                        Town = p.Address.Town,
                        Neighborhood = p.Address.Neighborhood,
                        Street = p.Address.Street
                    },
                    CreatedOn = p.CreatedOn,
                    Price = p.Price,
                    PropertyPurpose = p.PropertyPurpose.ToString(),
                    Title = p.Title,
                    PictureUrl = p.Pictures.FirstOrDefault().CloudUrl,
                    Details = new PropertyDetailsViewModel()
                    {
                        HomeArea = p.PropertyDetails.HomeArea,
                        TotalArea = p.PropertyDetails.TotalArea,
                        NumberOfBedrooms = p.PropertyDetails.NumberOfBedrooms,
                        NumberOfBathrooms = p.PropertyDetails.NumberOfBathrooms,
                        NumberOfBeds = p.PropertyDetails.NumberOfBeds,
                        YearOfBuild = p.PropertyDetails.YearOfBuild
                    },
                    Description = p.Description,
                    CurrencyType = p.Currency
                });
        }

        public SinglePropertyDetailsViewModel Details(int id)
        {
            var model = this._context.Properties
                .Where(p => p.Id == id)
                .Select(x => new SinglePropertyDetailsViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Address = new AddressCreateViewModel()
                    {
                        State = x.Address.State,
                        Town = x.Address.Town,
                        Neighborhood = x.Address.Neighborhood,
                        Street = x.Address.Street
                    },
                    Price = x.Price,
                    Currency = x.Currency.ToString(),
                    Purpose = x.PropertyPurpose.ToString(),
                    Status = x.PropertyStatus.ToString(),
                    PropertyType = x.PropertyType.ToString(),
                    Details = new PropertyDetailsViewModel()
                    {
                        HomeArea = x.PropertyDetails.HomeArea,
                        TotalArea = x.PropertyDetails.TotalArea,
                        NumberOfBedrooms = x.PropertyDetails.NumberOfBedrooms,
                        NumberOfBathrooms = x.PropertyDetails.NumberOfBathrooms,
                        NumberOfBeds = x.PropertyDetails.NumberOfBeds,
                        YearOfBuild = x.PropertyDetails.YearOfBuild
                    },
                    Facilities = new FacilitiesViewModel()
                    {
                        FoodStores = x.Facilities.FoodStores,
                        FoodStoreDistance = x.Facilities.FoodStoreDistance.ToString(),
                        Hospitals = x.Facilities.Hospitals,
                        HospitalDistance = x.Facilities.HospitalDistance.ToString(),
                        School = x.Facilities.School,
                        SchoolDistance = x.Facilities.SchoolDistance.ToString()
                    },
                    Agent = new AgentViewModel()
                    {
                        FirstName = x.Agent.FirstName,
                        LastName = x.Agent.LastName,
                        Email = x.Agent.Email,
                        PhoneNumber = x.Agent.PhoneNumber
                    }
                }).FirstOrDefault();

            if (model == null)
            {
                return null;
            }
            var pictures = this._context.Pictures.Where(p => p.PropertyId == id).Select(x => x.CloudUrl).ToList();
            model.PictureUrls = pictures;

            return model;
        }

        public List<MyPropertiesViewModel> MyProperties(string username)
        {
            return this._context.Properties
                .Where(p => p.Agent.UserName == username)
                .Select(p => new MyPropertiesViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = p.Price,
                    Currency = p.Currency.ToString(),
                    PictureUrl = p.Pictures.First().CloudUrl,
                    AddressTown = p.Address.Town,
                    AddressStreet = p.Address.Street
                })
                .ToList();
        }

        public bool Remove(int id)
        {
            var property = this._context.Properties.FirstOrDefault(p => p.Id == id);
            
            if (property != null)
            {
                var appointmentsForApartment = this._context.Appointments.Where(x => x.PropertyId == property.Id).ToList();
                this._context.Appointments.RemoveRange(appointmentsForApartment);
                this._context.Properties.Remove(property);
                this._context.SaveChanges();
                return true;
            }

            return false;
        }

        public PropertyUpdateViewModel Edit(int id)
        {
            var model = this._context.Properties
                .Include(p => p.Owner)
                .Include(p => p.Facilities)
                .Include(p => p.PropertyDetails)
                .Include(p => p.Address)
                .First(x => x.Id == id);

            return new PropertyUpdateViewModel()
            {
                Id = model.Id,
                Currency = model.Currency,
                Description = model.Description,
                Price = model.Price,
                Title = model.Title,
                Facilities = model.Facilities,
                PropertyPurpose = model.PropertyPurpose,
                PropertyStatus = model.PropertyStatus,
                PropertyType = model.PropertyType,
                Address = new AddressCreateViewModel()
                {
                    State = model.Address.State,
                    Town = model.Address.Town,
                    Neighborhood = model.Address.Neighborhood,
                    Street = model.Address.Street
                },
                FirstName = model.Owner.FirstName,
                LastName = model.Owner.LastName,
                PhoneNumber = model.Owner.PhoneNumber,
                TotalArea = model.PropertyDetails.TotalArea,
                HomeArea = model.PropertyDetails.HomeArea,
                NumberOfBedrooms = model.PropertyDetails.NumberOfBedrooms,
                NumberOfBathrooms = model.PropertyDetails.NumberOfBathrooms,
                NumberOfBeds = model.PropertyDetails.NumberOfBeds,
                YearOfBuild = model.PropertyDetails.YearOfBuild,

            };
        }

        public void Update(PropertyUpdateViewModel model)
        {
            var modelDb = this._context.Properties
                .Include(p => p.Owner)
                .Include(p => p.Facilities)
                .Include(p => p.PropertyDetails)
                .Include(p => p.Address)
                .FirstOrDefault(x => x.Id == model.Id);

            modelDb.Title = model.Title;
            modelDb.CreatedOn = DateTime.UtcNow;
            modelDb.Description = model.Description;
            modelDb.Address.State = model.Address.State;
            modelDb.Address.Town = model.Address.Town;
            modelDb.Address.Neighborhood = model.Address.Neighborhood;
            modelDb.Address.Street = model.Address.Street;
            modelDb.Facilities = model.Facilities;
            modelDb.Owner.FirstName = model.FirstName;
            modelDb.Owner.LastName = model.LastName;
            modelDb.Owner.PhoneNumber = model.PhoneNumber;
            modelDb.PropertyDetails.NumberOfBathrooms = model.NumberOfBathrooms;
            modelDb.PropertyDetails.NumberOfBedrooms = model.NumberOfBedrooms;
            modelDb.PropertyDetails.NumberOfBeds = model.NumberOfBeds;
            modelDb.PropertyDetails.TotalArea = model.TotalArea;
            modelDb.PropertyDetails.HomeArea = model.HomeArea;
            modelDb.PropertyDetails.YearOfBuild = model.YearOfBuild;
            modelDb.PropertyStatus = model.PropertyStatus;
            modelDb.PropertyType = model.PropertyType;
            modelDb.Currency = model.Currency;
            modelDb.Price = model.Price;
            modelDb.PropertyPurpose = model.PropertyPurpose;

            this._context.SaveChanges();
        }

        private List<Picture> UploadPicturesToCloudinary(IEnumerable<IFormFile> modelFiles)
        {
            //ToDo remove api secret and api key

            Account account = new Account(
                //"custom_cloudinary_name",
                //"api_key",
                //"api_sercret"
                "dydimitrov",
                "151154596751112",
                "w8dKarNWtw_h0m_iEacVPifswV4"
                );

            Cloudinary cloudinary = new Cloudinary(account);

            var listOfUrl = new List<Picture>();

            foreach (var file in modelFiles)
            {
                Guid id = Guid.NewGuid();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.Name, file.OpenReadStream()),
                    PublicId = id.ToString(),
                };

                var uploadResult = cloudinary.Upload(uploadParams);
                var picture = new Picture { CloudUrl = uploadResult.SecureUri.ToString(), PublicId = uploadResult.PublicId };
                listOfUrl.Add(picture);
            }

            return listOfUrl;
        }
    }
}
