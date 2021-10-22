using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Models;

namespace ToDo.Data
{
    class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(k => k.StatusId);
            builder.Property(n => n.StatusEnum).IsRequired().HasMaxLength(30);
        }
    }
}
