using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESPAPI.Models
{
    public class SecondaryOperatingData
    {
        public int id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        //public string description { get; set; }
        public string ESP { get; set; }
        public string OriginalManufacturer { get; set; }
        public string Model { get; set; }
        public DateTime CommissioningDate { get; set; }
        public string ProcessApplication { get; set; }
        public DateTime DateofRecording { get; set; }

        public decimal Efficiency { get; set; }
        public decimal GasVelocity { get; set; }
        public decimal CollectionAreafield { get; set; }
        public decimal CollectionAreapass { get; set; }
        public decimal TotalCollectionArea { get; set; }
        public decimal SpecificCollectionArea { get; set; }
        public decimal SCAPerField { get; set; }
        public decimal SCANormalized { get; set; }
        public decimal TreatmentTime { get; set; }
        public decimal TreatmentLength { get; set; }
        public decimal AspectRatio { get; set; }
        public decimal MigrationVelocity { get; set; }

        public decimal KFactorToBeConsidered { get; set; }
        public decimal MigrationVelocityK { get; set; }
        public int NoOfPlatesPerRapper { get; set; }
        public decimal CollectingAreaPerRapper { get; set; }
        public decimal TotalTRCurrent { get; set; }
        public decimal AverageCurrentDensity { get; set; }
        public decimal AverageTRVoltage { get; set; }
        public decimal PowerDensity { get; set; }
    }
}
