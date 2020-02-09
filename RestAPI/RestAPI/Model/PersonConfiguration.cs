using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Model
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).HasColumnName("first_name").HasMaxLength(30);
            builder.Property(p => p.LastName).HasColumnName("last_name").HasMaxLength(50);
            builder.Property(p => p.Gender).HasColumnName("gender");
            builder.Property(p => p.Address).HasColumnName("address").HasMaxLength(100);
        }
    }
}
