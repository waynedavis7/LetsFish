namespace LetsFish.Application.Domain.Profiles;

internal class CaptainProfile : Profile
{
    protected CaptainProfile()
    {
        CreateMap<Captain, Captain>().ReverseMap();
    }
}
