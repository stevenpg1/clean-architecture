using CleanTeeth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Configurations
{
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ComplexProperty(prop => prop.TimeInterval, action =>
            {
                action.Property(equals => equals.Start).HasColumnName("StartDate");
                action.Property(equals => equals.End).HasColumnName("EndDate");
            });
        }
    }
}
