using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace ESPAPI.Models
{
    public partial class espContext : DbContext, IespContext
    {
        public espContext()
        {
        }

        public espContext(DbContextOptions<espContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PrimaryDataList> primarydatalist { get; set; }
        public virtual DbSet<PrimaryData> primarydata { get; set; }
        public virtual DbSet<User> user { get; set; }
        public virtual DbSet<SecondaryDesignData> secondarydata { get; set; }
        public virtual DbSet<SecondaryOperatingData> secondaryoperatingdata { get; set; }
        //public virtual DbSet<UserRole> userrole { get; set; }

        // Add this method for unit testing update
        public void MarkAsModified(PrimaryData item)
        {
            Entry(item).State = EntityState.Modified;
        }
        public void MarkAsModified(User item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public void MarkAsModified(SecondaryDesignData item)
        {
            Entry(item).State = EntityState.Modified;
        }
        public void MarkAsModified(SecondaryOperatingData item)
        {
            Entry(item).State = EntityState.Modified;
        }
        //public void MarkAsModified(UserRole item)
        //{
        //    Entry(item).State = EntityState.Modified;
        //}
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=sakila;Uid=writer;Pwd=Password1;");
            }
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrimaryData>(entity =>
            {
                entity.ToTable("primarydata", "esp");

                //entity.HasIndex(e => e.id)
                //    .HasName("idx_actor_last_name");

                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.CustomerName)
                    .HasColumnName("CustomerName")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                   .HasColumnName("Address")
                   .HasMaxLength(500)
                   .IsUnicode(false);

                entity.Property(e => e.ESP)
                   .HasColumnName("ESP")
                   .HasMaxLength(250)
                   .IsUnicode(false);

                entity.Property(e => e.OriginalManufacturer)
                 .HasColumnName("OriginalManufacturer")
                 .HasMaxLength(250)
                 .IsUnicode(false);

                entity.Property(e => e.Model)
             .HasColumnName("Model")
             .HasMaxLength(250)
             .IsUnicode(false);


                entity.Property(e => e.CommissioningDate)
                .HasColumnName("CommissioningDate")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ProcessApplication)
            .HasColumnName("ProcessApplication")
            .HasMaxLength(250)
            .IsUnicode(false);


                entity.Property(e => e.GasFlow)
                .HasColumnName("GasFlow")
                .HasColumnType("decimal(18,2)");


                entity.Property(e => e.GasTemperature)
             .HasColumnName("GasTemperature")
             .HasColumnType("decimal(18,2)");


                entity.Property(e => e.InletDustBurden)
          .HasColumnName("InletDustBurden")
          .HasColumnType("decimal(18,2)");


                entity.Property(e => e.GasMoisture)
          .HasColumnName("GasMoisture")
          .HasColumnType("decimal(18,2)");


                entity.Property(e => e.OutletEmission)
          .HasColumnName("OutletEmission")
          .HasColumnType("decimal(18,2)");

                entity.Property(e => e.ESPType)
       .HasColumnName("ESPType")
       .HasMaxLength(150)
       .IsUnicode(false);


                entity.Property(e => e.NoOfPassesChambers)
  .HasColumnName("NoOfPassesChambers")
    .HasColumnType("int");


                entity.Property(e => e.NoofFieldsZones)
 .HasColumnName("NoofFieldsZones")
   .HasColumnType("int");


                entity.Property(e => e.DetOfElecSectionalisation)
 .HasColumnName("DetOfElecSectionalisation")
     .HasMaxLength(500)
       .IsUnicode(false);


                entity.Property(e => e.NoOfGasPassages)
 .HasColumnName("NoOfGasPassages")
   .HasColumnType("int");


                entity.Property(e => e.GasPassageWidth)
        .HasColumnName("GasPassageWidth")
        .HasColumnType("decimal(18,2)");

                entity.Property(e => e.FieldHeight)
    .HasColumnName("FieldHeight")
    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.FieldLength)
    .HasColumnName("FieldLength")
    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.EmitterElectrodeType)
.HasColumnName("EmitterElectrodeType")
    .HasMaxLength(500)
      .IsUnicode(false);


                entity.Property(e => e.EmitterElectrodeLength)
.HasColumnName("EmitterElectrodeLength")
   .HasColumnType("decimal(18,2)");

                entity.Property(e => e.NoOfEmittSeries)
.HasColumnName("NoOfEmittSeries")
   .HasColumnType("int");

                entity.Property(e => e.CollElectrodeType)
    .HasColumnName("CollElectrodeType")
    .HasMaxLength(250)
    .IsUnicode(false);

                entity.Property(e => e.CollElectrodeHeight)
                .HasColumnName("CollElectrodeHeight")
                .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CollElectrodeLength)
                  .HasColumnName("CollElectrodeLength")
                  .HasColumnType("decimal(18,2)");


                entity.Property(e => e.CollElectrodeThickness)
                  .HasColumnName("CollElectrodeThickness")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.NoOfCEsalongGas)
          .HasColumnName("NoOfCEsalongGas")
             .HasColumnType("int");

                entity.Property(e => e.TypeOfCollRapping)
      .HasColumnName("TypeOfCollRapping")
      .HasMaxLength(250)
      .IsUnicode(false);


                entity.Property(e => e.NoOfCollRappers)
         .HasColumnName("NoOfCollRappers")
            .HasColumnType("int");

                entity.Property(e => e.TypeOfEmitterRapping)
       .HasColumnName("TypeOfEmitterRapping")
       .HasMaxLength(250)
       .IsUnicode(false);

                entity.Property(e => e.NoOfEmitterRappers)
    .HasColumnName("NoOfEmitterRappers")
     .HasColumnType("int");

                entity.Property(e => e.EmitRapperInsulatorType)
     .HasColumnName("EmitRapperInsulatorType")
     .HasMaxLength(250)
     .IsUnicode(false);

                entity.Property(e => e.NoOfGDScreenRappers)
    .HasColumnName("NoOfGDScreenRappers")
    .HasColumnType("int");


                entity.Property(e => e.TypeOfRapperControl)
    .HasColumnName("TypeOfRapperControl")
    .HasMaxLength(250)
    .IsUnicode(false);


                entity.Property(e => e.TRSetMakeforallFields)
    .HasColumnName("TRSetMakeforallFields")
    .HasMaxLength(250)
    .IsUnicode(false);


                entity.Property(e => e.TRSetKV)
    .HasColumnName("TRSetKV")
    .HasMaxLength(250)
    .IsUnicode(false);


                entity.Property(e => e.TRSetmA)
    .HasColumnName("TRSetmA")
    .HasMaxLength(250)
    .IsUnicode(false);

                entity.Property(e => e.NoOfFieldsconntoTRSet)
              .HasColumnName("NoOfFieldsconntoTRSet")
              .HasColumnType("int");

                entity.Property(e => e.NoOfTRSetsConnetoField)
                        .HasColumnName("NoOfTRSetsConnetoField")
                        .HasColumnType("int");



                entity.Property(e => e.TRSetLocation)
    .HasColumnName("TRSetLocation")
    .HasMaxLength(250)
    .IsUnicode(false);


                entity.Property(e => e.HTConnectionType)
             .HasColumnName("HTConnectionType")
             .HasMaxLength(250)
             .IsUnicode(false);


                entity.Property(e => e.TRControllerMakeType)
             .HasColumnName("TRControllerMakeType")
             .HasMaxLength(250)
             .IsUnicode(false);



                entity.Property(e => e.TypeOfInsulatorEnclosure)
             .HasColumnName("TypeOfInsulatorEnclosure")
             .HasMaxLength(250)
             .IsUnicode(false);

                entity.Property(e => e.TypeOfSupportInsulators)
      .HasColumnName("TypeOfSupportInsulators")
      .HasMaxLength(250)
      .IsUnicode(false);

                entity.Property(e => e.MaterialOfSupportInsulator)
     .HasColumnName("MaterialOfSupportInsulator")
     .HasMaxLength(250)
     .IsUnicode(false);


                entity.Property(e => e.NoOfSupportInsulators)
                         .HasColumnName("NoOfSupportInsulators")
                         .HasColumnType("int");

                entity.Property(e => e.TypeOfInsulatorHeaterProvided)
      .HasColumnName("TypeOfInsulatorHeaterProvided")
      .HasMaxLength(250)
      .IsUnicode(false);

                entity.Property(e => e.NoOfHoppers)
                       .HasColumnName("NoOfHoppers")
                       .HasColumnType("int");

                entity.Property(e => e.NoOfHoppersperField)
                        .HasColumnName("NoOfHoppersperField")
                        .HasColumnType("int");


                entity.Property(e => e.NoOfFieldsperHopper)
                         .HasColumnName("NoOfFieldsperHopper")
                         .HasColumnType("int");

                entity.Property(e => e.TypeOfHopper)
    .HasColumnName("TypeOfHopper")
    .HasMaxLength(250)
    .IsUnicode(false);

                entity.Property(e => e.DustEvacuationMethod)
     .HasColumnName("DustEvacuationMethod")
     .HasMaxLength(250)
     .IsUnicode(false);

                entity.Property(e => e.FixedCarbonFC)
                             .HasColumnName("FixedCarbonFC")
                             .HasColumnType("decimal(18,2)");

                entity.Property(e => e.AshContent)
                           .HasColumnName("AshContent")
                           .HasColumnType("decimal(18,2)");


                entity.Property(e => e.VolatileMatter)
                           .HasColumnName("VolatileMatter")
                           .HasColumnType("decimal(18,2)");

                entity.Property(e => e.InherentMoisture)
                      .HasColumnName("InherentMoisture")
                      .HasColumnType("decimal(18,2)");

                entity.Property(e => e.SurfaceMoisture)
                  .HasColumnName("SurfaceMoisture")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.NetCalorificValue)
                .HasColumnName("NetCalorificValue")
                .HasColumnType("decimal(18,2)");

                entity.Property(e => e.GrossCalorificValue)
              .HasColumnName("GrossCalorificValue")
              .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Carbon)
              .HasColumnName("Carbon")
              .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Hydrogen)
           .HasColumnName("Hydrogen")
           .HasColumnType("decimal(18,2)");


                entity.Property(e => e.OxygenInCoalAnalysis)
        .HasColumnName("OxygenInCoalAnalysis")
        .HasColumnType("decimal(18,2)");

                entity.Property(e => e.NitrogenInCoalAnalysis)
       .HasColumnName("NitrogenInCoalAnalysis")
       .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Sulphur)
                .HasColumnName("Sulphur")
             .HasColumnType("decimal(18,2)");

                entity.Property(e => e.OtherElements)
                .HasColumnName("OtherElements")
                .HasColumnType("decimal(18,2)");


                entity.Property(e => e.SiliconDioxide)
                 .HasColumnName("SiliconDioxide")
                 .HasColumnType("decimal(18,2)");

                entity.Property(e => e.AluminiumOxide)
              .HasColumnName("AluminiumOxide")
              .HasColumnType("decimal(18,2)");

                entity.Property(e => e.IronOxide)
            .HasColumnName("IronOxide")
            .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CalciumOxide)
    .HasColumnName("CalciumOxide")
    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.SodiumOxide)
   .HasColumnName("SodiumOxide")
   .HasColumnType("decimal(18,2)");

                entity.Property(e => e.PotassiumOxide)
    .HasColumnName("PotassiumOxide")
    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.MagnesiumOxide)
                .HasColumnName("MagnesiumOxide")
                .HasColumnType("decimal(18,2)");


                entity.Property(e => e.ManganeseDioxide)
                .HasColumnName("ManganeseDioxide")
                .HasColumnType("decimal(18,2)");

                entity.Property(e => e.LithiumOxide)
            .HasColumnName("LithiumOxide")
            .HasColumnType("decimal(18,2)");


                entity.Property(e => e.PhosphorousPentoxide)
            .HasColumnName("PhosphorousPentoxide")
            .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Sulphates)
     .HasColumnName("Sulphates")
     .HasColumnType("decimal(18,2)");


                entity.Property(e => e.Chlorides)
     .HasColumnName("Chlorides")
     .HasColumnType("decimal(18,2)");


                entity.Property(e => e.Others)
   .HasColumnName("Others")
   .HasColumnType("decimal(18,2)");



                entity.Property(e => e.SizeGreaterthan50microns)
   .HasColumnName("SizeGreaterthan50microns")
   .HasColumnType("decimal(18,2)");

                entity.Property(e => e.twentyfivetofiftymicrons)
.HasColumnName("25to50microns")
.HasColumnType("decimal(18,2)");


                entity.Property(e => e.tentotwentyfivemicrons)
.HasColumnName("10to25microns")
.HasColumnType("decimal(18,2)");

                entity.Property(e => e.fivetotenmicrons)
.HasColumnName("5to10microns")
.HasColumnType("decimal(18,2)");

                entity.Property(e => e.twotofivemicrons)
.HasColumnName("2to5microns")
.HasColumnType("decimal(18,2)");

                entity.Property(e => e.onetotwomicrons)
          .HasColumnName("1to2microns")
          .HasColumnType("decimal(18,2)");

                entity.Property(e => e.SizeLessthan1micron)
       .HasColumnName("SizeLessthan1micron")
       .HasColumnType("decimal(18,2)");


                entity.Property(e => e.Oxygen)
           .HasColumnName("Oxygen")
           .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CarbonDioxide)
        .HasColumnName("CarbonDioxide")
        .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CarbonMonoxide)
     .HasColumnName("CarbonMonoxide")
     .HasColumnType("decimal(18,2)");

                entity.Property(e => e.OxidesOfSuphur)
    .HasColumnName("OxidesOfSuphur")
    .HasColumnType("decimal(18,2)");


                entity.Property(e => e.OxidesOfNitrogen)
    .HasColumnName("OxidesOfNitrogen")
    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Moisture)
                 .HasColumnName("Moisture")
                 .HasColumnType("decimal(18,2)");

                entity.Property(e => e.OtherGases)
              .HasColumnName("OtherGases")
              .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Nitrogen)
             .HasColumnName("Nitrogen")
             .HasColumnType("decimal(18,2)");


                entity.Property(e => e.AdditionInfo)
         .HasColumnName("AdditionInfo")
          .HasMaxLength(500)
     .IsUnicode(false);



            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "esp");



                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasMaxLength(500)
                    .IsUnicode(false);


                entity.Property(e => e.UserName)
                    .HasColumnName("UserName")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasMaxLength(500)
                .IsUnicode(false);

                entity.Property(e => e.Token)
              .HasColumnName("Token")
              .HasMaxLength(500)
              .IsUnicode(false);

                entity.Property(e => e.RoleId)
          .HasColumnName("RoleId")
          .HasMaxLength(128)
          .IsUnicode(false);



                entity.Property(e => e.Email)
          .HasColumnName("Email")
          .HasMaxLength(256)
          .IsUnicode(false);

                entity.Property(e => e.firstname)
        .HasColumnName("firstname")
        .HasMaxLength(500)
        .IsUnicode(false);

                entity.Property(e => e.lastname)
     .HasColumnName("lastname")
     .HasMaxLength(500)
     .IsUnicode(false);
            });

            modelBuilder.Entity<SecondaryDesignData>(entity =>
            {
                entity.ToTable("SecondaryDesignData", "esp");

                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.CustomerName)
                    .HasColumnName("CustomerName")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                   .HasColumnName("Address")
                   .HasMaxLength(500)
                   .IsUnicode(false);

                entity.Property(e => e.ESP)
                   .HasColumnName("ESP")
                   .HasMaxLength(250)
                   .IsUnicode(false);

                entity.Property(e => e.OriginalManufacturer)
                 .HasColumnName("OriginalManufacturer")
                 .HasMaxLength(250)
                 .IsUnicode(false);

                entity.Property(e => e.Model)
                 .HasColumnName("Model")
                 .HasMaxLength(250)
                 .IsUnicode(false);

                entity.Property(e => e.CommissioningDate)
                 .HasColumnName("CommissioningDate")
                 .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ProcessApplication)
                 .HasColumnName("ProcessApplication")
                 .HasMaxLength(250)
                 .IsUnicode(false);

                entity.Property(e => e.Efficiency)
                 .HasColumnName("Efficiency")
                 .HasColumnType("decimal(18,2)");

                entity.Property(e => e.GasVelocity)
                 .HasColumnName("GasVelocity")
                 .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CollectionAreafield)
                  .HasColumnName("CollectionAreafield")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CollectionAreapass)
                  .HasColumnName("CollectionAreapass")
                  .HasColumnType("decimal(18,2)");


                entity.Property(e => e.TotalCollectionArea)
                  .HasColumnName("TotalCollectionArea")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.SpecificCollectionArea)
                  .HasColumnName("SpecificCollectionArea")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.SCAPerField)
                   .HasColumnName("SCAPerField")
                   .HasColumnType("decimal(18,2)");

                entity.Property(e => e.SCANormalized)
                  .HasColumnName("SCANormalized")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.TreatmentTime)
                  .HasColumnName("TreatmentTime")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.TreatmentLength)
                  .HasColumnName("TreatmentLength")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.AspectRatio)
                  .HasColumnName("AspectRatio")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.MigrationVelocity)
                  .HasColumnName("MigrationVelocity")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.KFactorToBeConsidered)
                  .HasColumnName("KFactorToBeConsidered")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.MigrationVelocityK)
                  .HasColumnName("MigrationVelocityK")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.NoOfPlatesPerRapper)
                  .HasColumnName("NoOfPlatesPerRapper")
                  .HasColumnType("int");

                entity.Property(e => e.CollectingAreaPerRapper)
                  .HasColumnName("CollectingAreaPerRapper")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.TotalTRCurrent)
                 .HasColumnName("TotalTRCurrent")
                 .HasColumnType("decimal(18,2)");

                entity.Property(e => e.AverageCurrentDensity)
                  .HasColumnName("AverageCurrentDensity")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.AverageTRVoltage)
                  .HasColumnName("AverageTRVoltage")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.PowerDensity)
                  .HasColumnName("PowerDensity")
                  .HasColumnType("decimal(18,2)");

            });

            modelBuilder.Entity<SecondaryOperatingData>(entity =>
            {
                entity.ToTable("SecondaryOperatingData", "esp");

                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.CustomerName)
                    .HasColumnName("CustomerName")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                   .HasColumnName("Address")
                   .HasMaxLength(500)
                   .IsUnicode(false);

                entity.Property(e => e.ESP)
                   .HasColumnName("ESP")
                   .HasMaxLength(250)
                   .IsUnicode(false);

                entity.Property(e => e.OriginalManufacturer)
                 .HasColumnName("OriginalManufacturer")
                 .HasMaxLength(250)
                 .IsUnicode(false);

                entity.Property(e => e.Model)
                 .HasColumnName("Model")
                 .HasMaxLength(250)
                 .IsUnicode(false);

                entity.Property(e => e.CommissioningDate)
                 .HasColumnName("CommissioningDate")
                 .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ProcessApplication)
                 .HasColumnName("ProcessApplication")
                 .HasMaxLength(250)
                 .IsUnicode(false);

                entity.Property(e => e.DateofRecording)
                .HasColumnName("DateofRecording")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Efficiency)
                 .HasColumnName("Efficiency")
                 .HasColumnType("decimal(18,2)");

                entity.Property(e => e.GasVelocity)
                 .HasColumnName("GasVelocity")
                 .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CollectionAreafield)
                  .HasColumnName("CollectionAreafield")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CollectionAreapass)
                  .HasColumnName("CollectionAreapass")
                  .HasColumnType("decimal(18,2)");


                entity.Property(e => e.TotalCollectionArea)
                  .HasColumnName("TotalCollectionArea")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.SpecificCollectionArea)
                  .HasColumnName("SpecificCollectionArea")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.SCAPerField)
                   .HasColumnName("SCAPerField")
                   .HasColumnType("decimal(18,2)");

                entity.Property(e => e.SCANormalized)
                  .HasColumnName("SCANormalized")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.TreatmentTime)
                  .HasColumnName("TreatmentTime")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.TreatmentLength)
                  .HasColumnName("TreatmentLength")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.AspectRatio)
                  .HasColumnName("AspectRatio")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.MigrationVelocity)
                  .HasColumnName("MigrationVelocity")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.KFactorToBeConsidered)
                  .HasColumnName("KFactorToBeConsidered")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.MigrationVelocityK)
                  .HasColumnName("MigrationVelocityK")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.NoOfPlatesPerRapper)
                  .HasColumnName("NoOfPlatesPerRapper")
                  .HasColumnType("int");

                entity.Property(e => e.CollectingAreaPerRapper)
                  .HasColumnName("CollectingAreaPerRapper")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.TotalTRCurrent)
                 .HasColumnName("TotalTRCurrent")
                 .HasColumnType("decimal(18,2)");

                entity.Property(e => e.AverageCurrentDensity)
                  .HasColumnName("AverageCurrentDensity")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.AverageTRVoltage)
                  .HasColumnName("AverageTRVoltage")
                  .HasColumnType("decimal(18,2)");

                entity.Property(e => e.PowerDensity)
                  .HasColumnName("PowerDensity")
                  .HasColumnType("decimal(18,2)");

            });
            //modelBuilder.Entity<UserRole>(entity =>
            //{
            //    entity.ToTable("userrole", "esp");



            //    entity.Property(e => e.RoleId)
            //        .HasColumnName("RoleId")
            //        .HasMaxLength(128);

            //    entity.Property(e => e.RoleName)
            //        .HasColumnName("RoleName")
            //        .HasMaxLength(256)
            //        .IsUnicode(false);


            //});

        }
    }
}
