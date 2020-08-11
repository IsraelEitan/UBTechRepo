using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UBTeach.Data.Models;

namespace UBTeach.Data.Configuration
{
    class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(e => e.Role)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasData
              (
                  new Person
                  {
                      Id = 1,
                      FirstName = "John",
                      LastName = "Doe",
                      Age = 30,
                      Role = "CTO"
                  },
                  new Person
                  {
                      Id = 2,
                      FirstName = "Mosh",
                      LastName = "Zeev",
                      Age = 25,
                      Role = "Dev"
                  },
                   new Person
                   {
                       Id = 3,
                       FirstName = "Guy",
                       LastName = "Tzof",
                       Age = 28,
                       Role = "QA"
                   },
                  new Person
                  {
                      Id = 4,
                      FirstName = "Noam",
                      LastName = "Cohen",
                      Age = 24,
                      Role = "Dev"
                  },
                   new Person
                   {
                       Id = 5,
                       FirstName = "Avi",
                       LastName = "Avraham",
                       Age = 30,
                       Role = "PO"
                   },
                  new Person
                  {
                      Id = 6,
                      FirstName = "Yochai",
                      LastName = "Moalem",
                      Age = 22,
                      Role = "Dev"
                  }
              );
        }
    }
}
