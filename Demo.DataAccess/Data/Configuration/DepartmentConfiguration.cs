namespace Demo.DataAccess.Data.Configuration
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(dept => dept.ID).UseIdentityColumn(10, 10);
            builder.Property(dept => dept.Code).HasColumnType("varchar(20)");
            builder.Property(dept => dept.Name).HasColumnType("varchar(20)");

            builder.Property(dept => dept.CreatedOn).HasDefaultValueSql("GETDATE()");
            //if row is inserted without value, the deault value will be used
            //on insert
            builder.Property(dept => dept.LastModifiedOn).HasDefaultValueSql("GETDATE()");
            //value is computed every time the record changes
            //on update
        }
    }
}
