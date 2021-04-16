namespace TAO_CSV_v06.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DailyReads : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyReads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Col_0 = c.String(),
                        Col_1 = c.String(),
                        Col_2 = c.String(),
                        Col_3 = c.String(),
                        Col_4 = c.String(),
                        Col_5 = c.String(),
                        Col_6 = c.String(),
                        Col_7 = c.String(),
                        Col_8 = c.String(),
                        Col_9 = c.String(),
                        Col_10 = c.String(),
                        Col_11 = c.String(),
                        Col_12 = c.String(),
                        Col_13 = c.String(),
                        Col_14 = c.String(),
                        Col_15 = c.String(),
                        Col_16 = c.String(),
                        Col_17 = c.String(),
                        Col_18 = c.String(),
                        Col_19 = c.String(),
                        Col_20 = c.String(),
                        Col_21 = c.String(),
                        Col_22 = c.String(),
                        Col_23 = c.String(),
                        Col_24 = c.String(),
                        Col_25 = c.String(),
                        Col_26 = c.String(),
                        Col_27 = c.String(),
                        Col_28 = c.String(),
                        Col_29 = c.String(),
                        Col_30 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HourlyReads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeterNumber = c.Int(nullable: false),
                        MeterMeasureType = c.String(),
                        InstallationNumber = c.String(),
                        Timestamp = c.String(),
                        InfoCode = c.String(),
                        Comment = c.String(),
                        Energy = c.String(),
                        EnergyUnit = c.String(),
                        Volume = c.String(),
                        VolumeUnit = c.String(),
                        HourCounter = c.String(),
                        HourCounterUnit = c.String(),
                        TempForward = c.String(),
                        TempForwardUnit = c.String(),
                        TempReturn = c.String(),
                        TempReturnUnit = c.String(),
                        valueTempDiff = c.String(),
                        TempDiffUnit = c.String(),
                        Power = c.String(),
                        PowerUnit = c.String(),
                        Flow = c.String(),
                        FlowUnit = c.String(),
                        Peak = c.String(),
                        PeakUnit = c.String(),
                        ForwardedUsage = c.String(),
                        ForwardedUsageUnit = c.String(),
                        ReturnedUsage = c.String(),
                        ReturnedUsageUnit = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HourlyReads");
            DropTable("dbo.DailyReads");
        }
    }
}
