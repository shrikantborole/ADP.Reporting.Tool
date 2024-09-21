namespace ADP.Reporting.Tool.Models.Configurations
{
    /// <summary>
    /// Represents the configuration settings for data migration.
    /// </summary>
    public class MigrationConfiguration
    {
        /// <summary>
        /// Gets or sets the path where the migration files are located.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets a comma-separated list of client names to be migrated.
        /// </summary>
        public string ClientsToMigrate { get; set; }
    }
}