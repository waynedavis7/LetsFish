namespace LetsFish.Application.Domain.Profiles;

internal class AnglerProfile : Profile
{
    public AnglerProfile()
    {
        CreateMap<Angler, Angler>().ReverseMap();
    }
}
