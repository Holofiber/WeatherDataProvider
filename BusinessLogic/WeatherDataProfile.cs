using AutoMapper;
using Newtonsoft.Json.Linq;

namespace BusinessLogic
{
    public class WeatherDataProfile : Profile
    {
        //protected override string ProfileName()
        //{
        //    CreateMap<JObject, WeatherData>()
        //        .ForMember(dest => dest.City, cfg => { cfg.MapFrom(jo => jo["name"]); })
        //        .ForMember(dest => dest.Temp, cfg => { cfg.MapFrom(jo => jo["temp"]); })
        //        .ForMember(dest => dest.Humidity, cfg => { cfg.MapFrom(jo => jo["humidity"]); })
        //        .ForMember(dest => dest.Pressure, cfg => { cfg.MapFrom(jo => jo["pressure"]); })
        //        .ForMember(dest => dest.WindSpeed, cfg => { cfg.MapFrom(jo => jo["speed"]); });
        //}
    }
}