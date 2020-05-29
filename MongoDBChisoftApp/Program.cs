using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoDBChisoftApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("AddressBook");

            //PersonModel person = new PersonModel
            //{
            //    FirstName = "Mikael",
            //    LastName = "Chinwe",
            //    PrimaryAddress = new AddressModel
            //    {
            //        StreetAddress = " 8 Church Street",
            //        City = "Baillieston",
            //        State = "Glasgow",
            //        PostCode = "G69 7NU"
            //    }
            //};

            //db.InsertRecord("Users", person);

            var recs = db.LoadRecord<PersonModel>("Users");

            foreach (var rec in recs)
            {
                Console.WriteLine($"{rec.Id}: {rec.FirstName} {rec.LastName}");

                if(rec.PrimaryAddress != null)
                {
                    Console.WriteLine(rec.PrimaryAddress.City);
                }

                Console.WriteLine();
            }
          
            Console.ReadLine();
        }
    }

    public class PersonModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel PrimaryAddress { get; set; }
    }

    public class AddressModel
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }

    }
    public class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public List<T> LoadRecord<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadRecordById<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).First();
        }
    }
}
