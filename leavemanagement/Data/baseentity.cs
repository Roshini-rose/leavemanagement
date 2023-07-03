namespace leavemanagement.Data
{
    public abstract class baseentity
    {
        public int id { get; set; }
        public DateTime datecreated { get; set; }
        public DateTime datemodified { get; set; }
    }
}
