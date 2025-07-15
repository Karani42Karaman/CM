using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CM.Core.Model;


namespace CM.Data
{
    public class RCVDBContext : IdentityDbContext<IdentityUser>
    {

        public RCVDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BelgelerModel>().UseTpcMappingStrategy().HasKey(x => x.BelgelerId);

            builder.Entity<FirmaModel>().HasKey(x => x.FirmaId);

            builder.Entity<GaleriModel>().UseTpcMappingStrategy().HasKey(x => x.GaleriId);

            builder.Entity<IletişimModel>().HasKey(x => x.IletisimId);
            // builder.Entity<MenuKategoriModel>().HasKey(x => x.MenuKategoriId);
            //  builder.Entity<MenuModel>().HasKey(x => x.menuId);
            builder.Entity<RakamlarModel>().HasKey(x => x.RakamId);

            builder.Entity<RakamYaniModel>().UseTpcMappingStrategy().HasKey(x => x.RakamYaniId);

            builder.Entity<SliderModel>().UseTpcMappingStrategy().HasKey(x => x.SliderId);

            builder.Entity<UrünKategoriModel>().UseTpcMappingStrategy().HasKey(x => x.UrünKategorId);

            builder.Entity<UrünlerModel>().UseTpcMappingStrategy().HasKey(x => x.UrünId);
            builder.Entity<MissionModel>().UseTpcMappingStrategy().HasKey(x => x.MissionId);
            builder.Entity<VisionModel>().UseTpcMappingStrategy().HasKey(x => x.VisionId);

            builder.Entity<PriceModel>().HasKey(x => x.PriceId);

            builder.Entity<UrünlerModel>()
        .HasOne(b => b.UrünKategoriModel)
        .WithMany(a => a.UrünlerModel).HasForeignKey(x=>x.UrünKategoriModelUrünKategorId).OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(builder);
        }

        // public DbSet<ImageModel> ImageModels{ get; set; }
        public DbSet<SliderModel> BelgelerModels { get; set; }
        public DbSet<GaleriModel> GaleriModels { get; set; }
        public DbSet<UrünKategoriModel> UrünKategoriModels { get; set; }
        public DbSet<UrünlerModel> UrünlerModels { get; set; }
        public DbSet<RakamYaniModel> RakamYaniModels { get; set; }
        public DbSet<SliderModel> SliderModels { get; set; }


        public DbSet<FirmaModel> FirmaModels { get; set; }
        public DbSet<IletişimModel> IletiModels { get; set; }
        //  public DbSet<MenuKategoriModel> MenuKategoriModels { get;set; }
        // public DbSet<MenuModel> MenuModels { get; set; }
        public DbSet<RakamlarModel> RakamlarModels { get; set; }

        public DbSet<MissionModel> MissionModels { get; set; }


        public DbSet<VisionModel> VisionModels { get; set; }

        public DbSet<PriceModel> PriceModels { get; set; }



    }
}
