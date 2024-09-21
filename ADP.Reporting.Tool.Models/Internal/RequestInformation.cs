namespace ADP.Reporting.Tool.Models
{
    /// <summary>
    /// Represents a request for information in the reporting system.
    /// </summary>
    public class RequestInformation
    {
        /// <summary>
        /// Gets or sets the unique identifier of the request information.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the client associated with the request.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets the type of the request.
        /// </summary>
        public string RequestType { get; set; }

        /// <summary>
        /// Gets or sets a description of the request.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the request was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the request was last updated.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the user who created the request.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user who last updated the request.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the report associated with the request.
        /// </summary>
        public int ReportId { get; set; }
    }
}
