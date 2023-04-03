using ControleContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleContatos.Data.Map
{
    public class ContatoMap : IEntityTypeConfiguration<ContatoViewModel>
    {
        public void Configure(EntityTypeBuilder<ContatoViewModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Usuario);
        }
    }
}
