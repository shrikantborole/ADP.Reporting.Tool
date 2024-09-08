namespace ADP.Reporting.Tool.Models
{
    /// <summary>
    /// Represents a type of report in the reporting system.
    /// </summary>
    public class ReportType
    {
        /// <summary>
        /// Gets or sets the unique identifier of the report type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the client associated with the report type.
        /// Nullable if not associated with a specific client.
        /// </summary>
        public int? ClientId { get; set; }

        /// <summary>
        /// Gets or sets the type of the report.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a description of the report type.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the report type was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the report type was last updated.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the user who created the report type.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user who last updated the report type.
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}