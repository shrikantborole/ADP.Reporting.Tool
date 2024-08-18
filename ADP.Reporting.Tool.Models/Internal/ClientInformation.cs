namespace ADP.Reporting.Tool.Models
{
    public class ClientInformation
    {
        public int Id { get; set; }
        public int AlphabetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
