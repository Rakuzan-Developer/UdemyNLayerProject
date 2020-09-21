using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Seeds
{
    class PersonSeed : IEntityTypeConfiguration<Person>
    {
        private readonly int[] _ids;

        public PersonSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(

                new Person { Id = _ids[0], Name = "Ahmed Akif", Surname = "Kaya" }
            );
        }
    }
}
