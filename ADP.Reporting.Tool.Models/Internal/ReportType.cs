﻿namespace ADP.Reporting.Tool.Models
{
    public class ReportType
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
