using AutoMapper;
using Business.Requests.Brands;
using Business.Responses.Brands;
using Entities.Concretes;

namespace Business.Profiles.Brands;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandRequest>().ReverseMap();
        CreateMap<Brand, CreateBrandResponse>().ReverseMap();
        CreateMap<Brand, GetAllBrandResponse>().ReverseMap();

    }
}
