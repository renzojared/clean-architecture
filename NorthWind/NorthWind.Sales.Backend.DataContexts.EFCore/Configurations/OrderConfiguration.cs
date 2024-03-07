namespace NorthWind.Sales.Backend.DataContexts.EFCore.Configurations;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(s => s.CustomerId)
            .IsRequired()
            .HasMaxLength(5)
            .IsFixedLength();

        builder.Property(s => s.ShipAddress)
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(s => s.ShipCity)
            .HasMaxLength(15);

        builder.Property(s => s.ShipCountry)
            .HasMaxLength(15);

        builder.Property(s => s.ShipPostalCode)
            .HasMaxLength(10);

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(s => s.CustomerId);
    }
}