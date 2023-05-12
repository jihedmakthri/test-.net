using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructue.Configurations
{
    public class CitoyenConfiguration : IEntityTypeConfiguration<Citoyen>
    {
        public void Configure(EntityTypeBuilder<Citoyen> builder)
        {
            builder.OwnsOne(a => a.Addresse, full =>
            {
                full.Property(x => x.CodePostal);
                full.Property(x => x.Rue);
                full.Property(x => x.Ville);

            });
        }
       
    }
}
