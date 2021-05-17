using FluentMigrator.Runner.VersionTableInfo;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Database.FluentMigrator
{
    [ExcludeFromCodeCoverage]
    [VersionTableMetaData]
    public class VersionTable : IVersionTableMetaData
    {
        public object ApplicationContext { get; set; }

        public bool OwnsSchema => true;

        public string SchemaName => "Migrator";

        public string TableName => "VersionInfo";

        public string ColumnName => "Version";

        public string DescriptionColumnName => "Description";

        public string UniqueIndexName => "UC_Version";

        public string AppliedOnColumnName => "AppliedOn";
    }
}
