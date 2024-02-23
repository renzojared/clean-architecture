namespace NorthWind.Sales.Backend.DataContexts.EFCore.Configurations;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(s => new { s.OrderId, s.ProductId });

        builder.Property(s => s.UnitPrice)
            .HasPrecision(8, 2);
    }
}