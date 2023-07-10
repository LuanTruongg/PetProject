using AutoBiker.Database.Entities;
using AutoBiker.ViewModel.Request.ProductRequest;
using AutoMapper;

namespace AutoBiker.BackEnd_Apis.Mapping
{
    public class ResourceToModel : Profile
    {
        public ResourceToModel() {
            CreateMap<ProductRequest, Product>();
        }
    }
}
