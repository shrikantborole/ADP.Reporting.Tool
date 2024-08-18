namespace ADP.Reporting.Tool.Models
{
    public class SqlFileData
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string Description { get; set; }
        public string SqlFileDataContent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
