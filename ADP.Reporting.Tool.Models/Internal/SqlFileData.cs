namespace ADP.Reporting.Tool.Models
{
    /// <summary>
    /// Represents the data of an SQL file associated with a request.
    /// </summary>
    public class SqlFileData
    {
        /// <summary>
        /// Gets or sets the unique identifier of the SQL file data.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the request associated with this SQL file data.
        /// </summary>
        public int RequestId { get; set; }

        /// <summary>
        /// Gets or sets a description of the SQL file data.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the content of the SQL file.
        /// </summary>
        public string SqlFileDataContent { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the SQL file data was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the SQL file data was last updated.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the user who created the SQL file data.
        /// Nullable if the creator is not specified.
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user who last updated the SQL file data.
        /// Nullable if the updater is not specified.
        /// </summary>
        public string? UpdatedBy { get; set; }
    }
}