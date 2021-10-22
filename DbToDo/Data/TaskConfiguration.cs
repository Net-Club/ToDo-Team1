using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Models;

namespace ToDo.Data
{
    class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(k => k.TaskID);
            builder.HasOne(n => n.Category).WithMany(f => f.Tasks).HasForeignKey(n => n.CategoryId);
            builder.HasOne(n => n.User).WithMany(f => f.Tasks).HasForeignKey(n => n.TaskID);
            builder.HasOne(n => n.Status).WithMany(f => f.Tasks).HasForeignKey(n => n.StatusId);
        }
    }
}
