using Microsoft.EntityFrameworkCore;
using SearchEngine.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Database
{
    public class DbContextRandom : DbContext
    { 
        public DbSet<Person> People { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Random.db";
            string dbPath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source = {dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Car>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Project>().Property(e => e.Id).ValueGeneratedOnAdd();

            List<Car> dummyCars = new List<Car>();

            for (int i = 0; i < 5; i++)
            {
                Car car = new Car
                {
                    Id = i+1,
                    Brand = $"Brand{i + 1}",
                    Model = $"Model{i + 1}",
                    Year = 2020 + i,
                    FuelType = i % 2 == 0 ? "Petrol" : "Diesel",
                    TyreSize = 18
                };

                dummyCars.Add(car);
            }

            List<Project> dummyProjects = new List<Project>();

            for (int i = 0; i < 5; i++)
            {
                Project project = new Project
                {
                    Id = i + 1,
                    Name = $"Project {i + 1}",
                    Year = 2020 + i,
                    AuthorName = $"Author {i + 1}",
                    DocumentFormat = i % 2 == 0 ? "PDF" : "DOCX"
                };

                dummyProjects.Add(project);
            }

            List<Person> dummyPeople = new List<Person>();

            for (int i = 0; i < 5; i++)
            {
                Person person = new Person
                {
                    Id = i + 1,
                    Name = $"Person {i + 1}",
                    YearBorn = "1990",
                    Sex = i % 2 == 0 ? "Male" : "Female",
                    Height = 170
                };

                dummyPeople.Add(person);
            }

            modelBuilder.Entity<Car>().HasData(dummyCars);
            modelBuilder.Entity<Project>().HasData(dummyProjects);
            modelBuilder.Entity<Person>().HasData(dummyPeople);
        }

    }
}
