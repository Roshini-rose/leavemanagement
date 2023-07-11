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
            CreateMap<employee,employeelistvm>().ReverseMap();  
            CreateMap<employee,employeeallocationvm>().ReverseMap();
            CreateMap<leaveallocation,leaveallocationvm>().ReverseMap();
            CreateMap<leaveallocation,leaveallocationeditvm>().ReverseMap();
            CreateMap<leaverequest,leaverequestcreatevm>().ReverseMap();
            CreateMap<leaverequest, leaverequestvm>().ReverseMap();
        }
    }
}
