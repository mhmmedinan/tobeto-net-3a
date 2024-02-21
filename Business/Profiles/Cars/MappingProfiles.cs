using AutoMapper;
using Business.Requests.Brands;
using Business.Requests.Cars;
using Business.Responses.Cars;
using Entities.Concretes;

namespace Business.Profiles.Cars;

public class MappingProfiles:Profile
{
	public MappingProfiles()
	{
		CreateMap<Car,CreateCarRequest>().ReverseMap();
		CreateMap<Car,CreateCarResponse>().ReverseMap();
		CreateMap<Car,GetAllCarResponse>().ReverseMap();
	}
}
