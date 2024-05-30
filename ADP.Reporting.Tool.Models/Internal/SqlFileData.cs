namespace ADP.Reporting.Tool.Models
{
    public class SqlFileData
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string Description { get; set; }
        public string SqlData { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedBy { get; set; }
        public DateTime? UpdatedBy { get; set; }
    }
}
