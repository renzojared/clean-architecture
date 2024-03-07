namespace NorthWind.Sales.Backend.DataContexts.EFCore.Configurations;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .Property(s => s.Id)
            .HasMaxLength(5)
            .IsFixedLength();

        builder
            .Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(40);

        builder
            .Property(s => s.CurrentBalance)
            .HasPrecision(8, 2);

        builder.HasData(
            new Customer() { Id = "ALFKI", Name = "Alfreds Futterkiste", CurrentBalance = 0 },
            new Customer() { Id = "ANATR", Name = "Ana Trujillo", CurrentBalance = 0 },
            new Customer() { Id = "ANTON", Name = "Antonio Moreno", CurrentBalance = 100 }
        );
    }
}