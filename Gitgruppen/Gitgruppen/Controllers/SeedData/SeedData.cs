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

        public static async Task InitAsync(GitgruppenContext db)
        {
            if (await db.Member.AnyAsync()) return;

            faker = new Faker("sv");

            var members = GenerateMembers(50);
            await db.AddRangeAsync(members);

            //var courses = GenerateCourses(20);
            //await db.AddRangeAsync(courses);

            //var enrollments = GenerateEnrollments(courses, students);
            //await db.AddRangeAsync(enrollments);

            await db.SaveChangesAsync();
        }

        internal static async Task AddParkingSpots(GitgruppenContext db, int nrOfParkingSpots)
        {
            if (faker == null) faker = new Faker("sv");

            var parkingsSpots = GenerateParkingSpots(nrOfParkingSpots);
            await db.AddRangeAsync(parkingsSpots);
            await db.SaveChangesAsync();
        }

        private static IEnumerable<ParkingSpot> GenerateParkingSpots(int nrOfParkingSpots)
        {
            List<ParkingSpot> parkingSpots = new List<ParkingSpot>();

            for (int i = 0; i < nrOfParkingSpots; i++)
            {
                ParkingSpot parkingSpot = new ParkingSpot();
                string name_1 = (i / 2 + 1).ToString();
                string name_2 = (i % 2 == 0) ? "A" : "B";
                parkingSpot.SpotName = name_1 + name_2;
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

                vehicle.LicensePlate = bogusVehicle.Vin();

                vehicle.Model = bogusVehicle.Model();

                vehicle.VehicleType = vhcl_ids[randomGen.Next(vhcl_ids.Length)];

                vehicles.Add(vehicle);
            }

            return vehicles;
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




