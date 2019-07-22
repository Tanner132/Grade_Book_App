using System;
using GradeBookApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace GradeBookApi.Services
{
    public class GradeBookService
    {
            private readonly IMongoCollection<Grades> _Grades;

            public GradeBookService(IGradeBookDatabaseSettings settings)
            {
                var client = new MongoClient(settings.ConnectionString);
                //var database = client.GetDatabase(settings.DatabaseName);
                var database = client.GetDatabase("GradeBook");

                _Grades = database.GetCollection<Grades>(settings.GradeBookCollectionName);
            }

            public List<Grades> Get() =>
                _Grades.Find(Grade => true).ToList();

            public Grades Get(string id) =>
                _Grades.Find<Grades>(Grade => Grade.Id == id).FirstOrDefault();

            public Grades Create(Grades Grade)
            {
                _Grades.InsertOne(Grade);
                return Grade;
            }

            public void Update(string id, Grades GradeIn) =>
                _Grades.ReplaceOne(Grade => Grade.Id == id, GradeIn);

            public void Remove(Grades GradeIn) =>
                _Grades.DeleteOne(Grade => Grade.Id == GradeIn.Id);

            public void Remove(string id) =>
                _Grades.DeleteOne(Grade => Grade.Id == id);
    }
}
