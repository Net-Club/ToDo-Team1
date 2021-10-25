using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Models;

namespace ToDo.Data
{
    class TaskConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(k => k.TaskId);
            builder.HasOne(n => n.Category).WithMany(f => f.Tasks).HasForeignKey(n => n.CategoryId);
            builder.HasOne(n => n.User).WithMany(f => f.Tasks).HasForeignKey(n => n.TaskId);
            builder.HasOne(n => n.Status).WithMany(f => f.Tasks).HasForeignKey(n => n.StatusId);
        }
    }
}
