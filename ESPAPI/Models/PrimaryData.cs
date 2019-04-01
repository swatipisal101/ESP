using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESPAPI.Models
{


    public class PrimaryData
    {
        //private MusicStoreContext context;
        //public int id { get; set; }
        //public string description { get; set; }



        public int id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        //public string description { get; set; }
        public string ESP { get; set; }
        public string OriginalManufacturer { get; set; }
        public string Model { get; set; }
        public DateTime CommissioningDate { get; set; }
        public string ProcessApplication { get; set; }
        public decimal GasFlow { get; set; }
        public decimal GasTemperature { get; set; }
        public decimal InletDustBurden { get; set; }

        public decimal GasMoisture { get; set; }
        public decimal OutletEmission { get; set; }
        public string ESPType { get; set; }
        public int NoOfPassesChambers { get; set; }
        public int NoofFieldsZones { get; set; }
        public string DetOfElecSectionalisation { get; set; }

        public int NoOfGasPassages { get; set; }
        public decimal GasPassageWidth { get; set; }
        public decimal FieldHeight { get; set; }
        public decimal FieldLength { get; set; }
        public string EmitterElectrodeType { get; set; }
        public decimal EmitterElectrodeLength { get; set; }

        public int NoOfEmittSeries { get; set; }
        public string CollElectrodeType { get; set; }
        public decimal CollElectrodeHeight { get; set; }
        public decimal CollElectrodeLength { get; set; }
        public decimal CollElectrodeThickness { get; set; }


        public int NoOfCEsalongGas { get; set; }
        public string TypeOfCollRapping { get; set; }
        public int NoOfCollRappers { get; set; }
        public string TypeOfEmitterRapping { get; set; }
        public int NoOfEmitterRappers { get; set; }

        public string EmitRapperInsulatorType { get; set; }
        public int NoOfGDScreenRappers { get; set; }
        public string TypeOfRapperControl { get; set; }
        public string TRSetMakeforallFields { get; set; }
        public string TRSetKV { get; set; }
        public string TRSetmA { get; set; }
        public int NoOfFieldsconntoTRSet { get; set; }
        public int NoOfTRSetsConnetoField { get; set; }
        public string TRSetLocation { get; set; }
        public string HTConnectionType { get; set; }
        public string TRControllerMakeType { get; set; }
        public string TypeOfInsulatorEnclosure { get; set; }
        public string TypeOfSupportInsulators { get; set; }
        public string MaterialOfSupportInsulator { get; set; }
        public int NoOfSupportInsulators { get; set; }
        public string TypeOfInsulatorHeaterProvided { get; set; }
        public int NoOfHoppers { get; set; }
        public int NoOfHoppersperField { get; set; }
        public int NoOfFieldsperHopper { get; set; }
        public string TypeOfHopper { get; set; }
        public string DustEvacuationMethod { get; set; }
        public decimal FixedCarbonFC { get; set; }
        public decimal AshContent { get; set; }
        public decimal VolatileMatter { get; set; }
        public decimal InherentMoisture { get; set; }
        public decimal SurfaceMoisture { get; set; }
        public decimal NetCalorificValue { get; set; }
        public decimal GrossCalorificValue { get; set; }
        public decimal Carbon { get; set; }

        public decimal Hydrogen { get; set; }
        public decimal OxygenInCoalAnalysis { get; set; }
        public decimal NitrogenInCoalAnalysis { get; set; }
        public decimal Sulphur { get; set; }
        public decimal OtherElements { get; set; }
        
        public decimal SiliconDioxide { get; set; }
        public decimal AluminiumOxide { get; set; }
        public decimal IronOxide { get; set; }
        public decimal CalciumOxide { get; set; }

        public decimal SodiumOxide { get; set; }
        public decimal PotassiumOxide { get; set; }
        public decimal MagnesiumOxide { get; set; }
        public decimal ManganeseDioxide { get; set; }
        public decimal LithiumOxide { get; set; }
        public decimal PhosphorousPentoxide { get; set; }
        public decimal Sulphates { get; set; }
        public decimal Chlorides { get; set; }


        public decimal Others { get; set; }
        public decimal SizeGreaterthan50microns { get; set; }
        public decimal twentyfivetofiftymicrons { get; set; }
    public decimal tentotwentyfivemicrons { get; set; }
public decimal fivetotenmicrons { get; set; }
 public decimal twotofivemicrons { get; set; }
 public decimal onetotwomicrons { get; set; }
 public decimal SizeLessthan1micron { get; set; }
public decimal Oxygen { get; set; }
public decimal CarbonDioxide { get; set; }
public decimal CarbonMonoxide { get; set; }
public decimal OxidesOfSuphur { get; set; }
public decimal OxidesOfNitrogen { get; set; }
public decimal Moisture { get; set; }
public decimal OtherGases { get; set; }
public decimal Nitrogen { get; set; }
        public string AdditionInfo { get; set; }
    }
    public class PrimaryDataList
    {
        //private MusicStoreContext context;
        //public int id { get; set; }
        //public string description { get; set; }



        public int id { get; set; }
        public string CustomerName { get; set; }
       // public string Address { get; set; }
      
        public string ESP { get; set; }
        public string OriginalManufacturer { get; set; }
        public string Model { get; set; }
       // public DateTime CommissioningDate { get; set; }
        public string ProcessApplication { get; set; }
    }

    }
