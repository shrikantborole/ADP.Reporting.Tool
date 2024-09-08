namespace ADP.Reporting.Tool.Models
{
    /// <summary>
    /// Represents client information in the system.
    /// </summary>
    public class ClientInformation
    {
        /// <summary>
        /// Gets or sets the unique identifier for the client information.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the associated alphabet.
        /// </summary>
        public int AlphabetId { get; set; }

        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the client information.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the client information was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the client information was last updated.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the username of the person who created the client information.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the username of the person who last updated the client information.
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}
