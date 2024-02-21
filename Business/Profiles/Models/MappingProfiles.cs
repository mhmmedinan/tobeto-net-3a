using AutoMapper;
using Business.Requests.Models;
using Business.Responses.Models;
using Entities.Concretes;

namespace Business.Profiles.Models;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Model,CreateModelRequest>().ReverseMap();
        CreateMap<Model,CreateModelResponse>().ReverseMap();
        CreateMap<Model,GetAllModelResponse>().ReverseMap();
    }
}
