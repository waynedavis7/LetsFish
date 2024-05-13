namespace LetsFish.Application.Domain.Profiles;

internal class CaptainProfile : Profile
{
    public CaptainProfile()
    {
        CreateMap<Captain, Captain>().ReverseMap();
    }
}
