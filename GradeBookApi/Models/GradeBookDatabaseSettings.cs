using System;
namespace GradeBookApi.Models
{
    public class GradeBookDatabaseSettings : IGradeBookDatabaseSettings
    {
        public string GradeBookCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IGradeBookDatabaseSettings
    {
        string GradeBookCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

