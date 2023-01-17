using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions.Sweden;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Globalization;
using Gitgruppen.Data;
using GitGruppen.Core;
using System.Drawing;

namespace Gitgruppen.Controllers.SeedData
{
    public class SeedData
    {
        private static Faker faker = null!;


        public static async Task InitAsync(GitgruppenContext db)
        {
            if (await db.Member.AnyAsync()) return;

            faker = new Faker("sv");

            var members = GenerateMembers(10).ToList();
            await db.AddRangeAsync(members);

            var vehicleTypes = GenerateVehicleTypes().ToList();
            await db.AddRangeAsync(vehicleTypes);

            await AddParkingSpots(db, 20);

            var vehicles = GenerateVehicles2(30, members, vehicleTypes);
            await db.AddRangeAsync(vehicles);

            await db.SaveChangesAsync();
        }

        private static IEnumerable<GitGruppen.Core.Vehicle> GenerateVehicles2(int nrOfVehicles, List<Member> members, List<VehicleType> vehicleTypes)
        {
            var vehicles = new List<GitGruppen.Core.Vehicle>();

            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));

            //Member[] mbr_ids = members.ToArray();
            //VehicleType[] vhcl_ids = vehicleTypes.ToArray();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < nrOfVehicles; i++)
            {
                Bogus.DataSets.Vehicle bogusVehicle = faker.Vehicle;
                var vehicle = new GitGruppen.Core.Vehicle();

                KnownColor randomColorName = names[randomGen.Next(names.Length)];
                vehicle.Color = Color.FromKnownColor(randomColorName).Name;

                vehicle.Brand = bogusVehicle.Manufacturer();

                vehicle.Arrived = faker.Date.Past(1, DateTime.Now);

                vehicle.Member = members[randomGen.Next(0, members.Count())];

                vehicle.NumberOfWheels = randomGen.Next(6) + 1;

                int j = randomGen.Next(1000);
                string license2 = "";
                if (j < 10) license2 = "00" + j.ToString();
                else if (j < 100) license2 = "0" + j.ToString();
                else license2 = j.ToString();

                vehicle.LicensePlate = (new string(Enumerable.Repeat(chars, 3)
                    .Select(s => s[randomGen.Next(s.Length)]).ToArray())).ToString() + license2;

                vehicle.Model = bogusVehicle.Model();

                vehicle.VehicleType = vehicleTypes[randomGen.Next(vehicleTypes.Count())];

                vehicles.Add(vehicle);
            }

            return vehicles;
        }

        private static IEnumerable<VehicleType> GenerateVehicleTypes()
        {
            var list = new List<VehicleType>
            {
                new VehicleType  { NrOfSpaces = 1, Type = "Car"},
                new VehicleType  { NrOfSpaces = 1, Type = "Boat"},
                new VehicleType  { NrOfSpaces = 1, Type = "Motorcycle"},
                new VehicleType  { NrOfSpaces = 1, Type = "Car"}
            };

            return list;

        }

        public static async Task AddMembers(GitgruppenContext db, int nrOfMembers)
        {
            if(faker == null) faker = new Faker("sv");

            var members = GenerateMembers(nrOfMembers);
            await db.AddRangeAsync(members);
            await db.SaveChangesAsync();

        }

        private static IEnumerable<Member> GenerateMembers(int numberOfStudents)
        {
            var students = new List<Member>();

            for (int i = 0; i < numberOfStudents; i++)
            {

                var fkr = new Faker("sv");

                
                var fName = fkr.Name.FirstName();
                var lName = fkr.Name.LastName();
                var persNr = fkr.Person.Personnummer();
                
                //var avatar = faker.Internet.Avatar();
                //var email = faker.Internet.Email(fName, lName, "lexicon.se");

                var member = new Member
                {
                    //Avatar = avatar,
                    PersNr= persNr,
                    FirstName = fName,
                    LastName = lName,
                    //Email = email,
                    //Address = new Core.Address
                    //{
                    //    Street = faker.Address.StreetAddress(),
                    //    City = faker.Address.City(),
                    //    ZipCode = faker.Address.ZipCode()
                    //}
                };

                students.Add(member);
            }

            return students;
        }



        internal static async Task AddParkingSpots(GitgruppenContext db, int nrOfParkingSpots)
        {
            if (faker == null) faker = new Faker("sv");

            var parkingsSpots = GenerateParkingSpots(nrOfParkingSpots);
            await db.AddRangeAsync(parkingsSpots);
            //await db.SaveChangesAsync();
        }

        private static IEnumerable<ParkingSpot> GenerateParkingSpots(int nrOfParkingSpots)
        {
            List<ParkingSpot> parkingSpots = new List<ParkingSpot>();

            for (int i = 0; i < nrOfParkingSpots; i++)
            {
                ParkingSpot parkingSpot = new ParkingSpot();
                int name_1 = (i / 2 + 1);
                int name_2 = (i % 2 == 0) ? 6 : 9;
                parkingSpot.SpotNo = name_1 + name_2; 
                parkingSpots.Add(parkingSpot);
            }

            return parkingSpots;
        }

        internal static async Task AddVehicles(GitgruppenContext db, int nrOfVehicles)
        {
            if (faker == null) faker = new Faker("sv");

            

            var parkingsSpots = GenerateVehicles( db.Member, db.VehicleType, nrOfVehicles);
            await db.AddRangeAsync(parkingsSpots);
            await db.SaveChangesAsync();
        }

        private static IEnumerable<GitGruppen.Core.Vehicle> GenerateVehicles(DbSet<Member> members, DbSet<VehicleType> vehicleTypes, int nrOfVehicles)
        {
            List<GitGruppen.Core.Vehicle> vehicles = new List<GitGruppen.Core.Vehicle>();
            Faker fkr = new Faker("sv");


            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));

            Member[] mbr_ids = members.ToArray();
            VehicleType[] vhcl_ids = vehicleTypes.ToArray();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < nrOfVehicles; i++)
            {
                Bogus.DataSets.Vehicle bogusVehicle = fkr.Vehicle;
                GitGruppen.Core.Vehicle vehicle = new GitGruppen.Core.Vehicle();

                KnownColor randomColorName = names[randomGen.Next(names.Length)];
                vehicle.Color = Color.FromKnownColor(randomColorName).Name;

                vehicle.Brand = bogusVehicle.Manufacturer();

                vehicle.Arrived = fkr.Date.Past(1, DateTime.Now);                
                
                vehicle.Member = mbr_ids[randomGen.Next(mbr_ids.Length)];

                vehicle.NumberOfWheels = randomGen.Next(6) + 1;

                int j = randomGen.Next(1000);
                string license2 = "";
                if (j < 10) license2 = "00" + j.ToString();
                else if (j < 100) license2 = "0" + j.ToString();
                else license2 = j.ToString();

                vehicle.LicensePlate = (new string(Enumerable.Repeat(chars, 3)
                    .Select(s => s[randomGen.Next(s.Length)]).ToArray())).ToString() + license2;

                vehicle.Model = bogusVehicle.Model();

                // vehicle.VehicleType = vhcl_ids[randomGen.Next(vhcl_ids.Length)];

                vehicles.Add(vehicle);
            }

            return vehicles;
        }

        internal static async Task AddGarage(GitgruppenContext db)
        {
            //4 vehicle types, 50 vehicles, 50 members, 50 parking spots
            db.VehicleType.Add(new VehicleType
            {
                NrOfSpaces = 1,
                Type = "Car"
            });
            db.VehicleType.Add(new VehicleType
            {
                NrOfSpaces = 1,
                Type = "Boat"
            });
            db.VehicleType.Add(new VehicleType
            {
                NrOfSpaces = 1,
                Type = "Motorcycle"
            });
            db.VehicleType.Add(new VehicleType
            {
                NrOfSpaces = 1,
                Type = "Airplane"
            });
            await AddParkingSpots(db, 50);
            await AddMembers(db, 50);
            await AddVehicles(db, 50);
        }

        internal static async Task DropGarage(GitgruppenContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            context.SaveChangesAsync();
        }

        //private static IEnumerable<Enrollment> GenerateEnrollments(IEnumerable<Course> courses, IEnumerable<Student> students)
        //{
        //    var rnd = new Random();

        //    var enrollments = new List<Enrollment>();

        //    foreach (var student in students)
        //    {
        //        foreach (var course in courses)
        //        {
        //            if (rnd.Next(0, 5) == 0)
        //            {
        //                var enrollment = new Enrollment
        //                {
        //                    Course = course,
        //                    Student = student,
        //                    Grade = rnd.Next(1, 6)
        //                };

        //                enrollments.Add(enrollment);
        //            }

        //        }
        //    }

        //    return enrollments;
        //}

        //private static IEnumerable<Course> GenerateCourses(int numberOfCourses)
        //{
        //    var courses = new List<Course>();

        //    for (int i = 0; i < numberOfCourses; i++)
        //    {
        //        // "hej jag heter david" => "Hej Jag Heter David"
        //        var title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Company.Bs());
        //        var course = new Course { Title = title };
        //        courses.Add(course);
        //    }

        //    return courses;
        //}

    }
}




