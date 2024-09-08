namespace ADP.Reporting.Tool.Models
{
    /// <summary>
    /// Represents an alphabet entity in the system.
    /// </summary>
    public class Alphabet
    {
        /// <summary>
        /// Gets or sets the unique identifier for the alphabet.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the alphabet.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the alphabet was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the alphabet was last updated.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the username of the person who created the alphabet.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the username of the person who last updated the alphabet.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the description of the alphabet.
        /// </summary>
        public string Description { get; set; }
    }
}
