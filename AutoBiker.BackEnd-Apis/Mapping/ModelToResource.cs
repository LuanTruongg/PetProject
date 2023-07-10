using AutoBiker.Database.Entities;
using AutoBiker.ViewModel.Resource;
using AutoMapper;

namespace AutoBiker.BackEnd_Apis.Mapping
{
    public class ModelToResource : Profile
    {
        public ModelToResource() {
            CreateMap<Product, ProductResource>().ForMember(x => x.BrandName, opt => opt.MapFrom(src => src.Brand.Name));
                                                            //  ProductResource                               Product                
            CreateMap<Brand, BrandResource>();
            CreateMap<AppUser, UserResource>();
        }
    }
}
