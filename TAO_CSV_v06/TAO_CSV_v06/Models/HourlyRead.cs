using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TAO_CSV_v06.Models
{
    public class HourlyRead
    {
        [Key]
        public int Id { get; set; }
        public int MeterNumber { get; set; }
        public string MeterMeasureType { get; set; }
        public string InstallationNumber { get; set; }
        public string Timestamp { get; set; }
        public string InfoCode { get; set; }
        public string Comment { get; set; }
        public string Energy { get; set; }
        public string EnergyUnit { get; set; }
        public string Volume { get; set; }
        public string VolumeUnit { get; set; }
        public string HourCounter { get; set; }
        public string HourCounterUnit { get; set; }
        public string TempForward { get; set; }
        public string TempForwardUnit { get; set; }
        public string TempReturn { get; set; }
        public string TempReturnUnit { get; set; }
        public string valueTempDiff { get; set; }
        public string TempDiffUnit { get; set; }
        public string Power { get; set; }
        public string PowerUnit { get; set; }
        public string Flow { get; set; }
        public string FlowUnit { get; set; }
        public string Peak { get; set; }
        public string PeakUnit { get; set; }
        public string ForwardedUsage { get; set; }
        public string ForwardedUsageUnit { get; set; }
        public string ReturnedUsage { get; set; }
        public string ReturnedUsageUnit { get; set; }
    }
}