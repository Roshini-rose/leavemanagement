using AutoMapper;
using leavemanagement.Data;
using leavemanagement.Models;

namespace leavemanagement.Configurations
{
    public class mapperconfig:Profile
    {
        public mapperconfig()
        {
            CreateMap<leavetype, leavetypevm>().ReverseMap();
        }
    }
}
