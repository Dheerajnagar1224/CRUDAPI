using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

public class EntityConfiguration : IEntityTypeConfiguration<Entity>
{
    public void Configure(EntityTypeBuilder<Entity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired();

        builder.Property(e => e.Deceased).IsRequired();
        builder.Property(e => e.Gender).IsRequired(false);

        builder.OwnsMany(e => e.Addresses, address =>
        {
            address.Property(a => a.AddressLine);
            address.Property(a => a.City);
            address.Property(a => a.Country);
        });

        builder.OwnsMany(e => e.Dates, date =>
        {
            date.Property(d => d.DateType);
            date.Property(d => d.DateValue);
        });

        builder.OwnsMany(e => e.Names, name =>
        {
            name.Property(n => n.FirstName);
            name.Property(n => n.MiddleName);
            name.Property(n => n.Surname);
        });
    }
}
