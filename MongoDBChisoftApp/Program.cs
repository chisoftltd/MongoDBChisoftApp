using System;

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

            var recs = db.LoadRecord<NameModel>("Users");

            foreach (var rec in recs)
            {
                Console.WriteLine($"{rec.FirstName} {rec.LastName}");
                Console.WriteLine();
            }


            //var recs = db.LoadRecord<PersonModel>("Users");

            //foreach (var rec in recs)
            //{
            //    Console.WriteLine($"{rec.Id}: {rec.FirstName} {rec.LastName}");

            //    if (rec.PrimaryAddress != null)
            //    {
            //        Console.WriteLine(rec.PrimaryAddress.City);
            //    }

            //    Console.WriteLine();
            //}


            //var oneRec = db.LoadRecordById<PersonModel>("Users", new Guid("d2171409-da08-4f7f-9fb2-7e3ab8d79aa7"));
            //oneRec.DateOfBirth = new DateTime(1972, 11, 30, 0, 0, 0, DateTimeKind.Utc);
            //db.UpsertRecord("Users", oneRec.Id, oneRec);
            //db.deleteRecord<PersonModel>("Users", oneRec.Id);

            Console.ReadLine();
        }
    }
}
