namespace ADP.Reporting.Tool.Models.Internal
{
    /// <summary>
    /// Represents the context for migration operations, holding temporary state during the migration process.
    /// </summary>
    public class MigrationContext
    {
        /// <summary>
        /// Gets or sets the name of the client being processed in the migration.
        /// </summary>
        public string ClinetName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the alphabet associated with the migration.
        /// </summary>
        public int AlphabetId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the client associated with the migration.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the report type associated with the migration.
        /// </summary>
        public int ReportId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the request information associated with the migration.
        /// </summary>
        public int RequestInformationId { get; set; }
    }
}
