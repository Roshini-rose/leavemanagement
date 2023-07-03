using Microsoft.AspNetCore.Identity;

namespace leavemanagement.Data
{
    public class employee: IdentityUser
    {
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? taxid { get; set; }   
        public DateTime dateofbirth { get; set; }
        public DateTime datejoined { get; set; }
    }
}
