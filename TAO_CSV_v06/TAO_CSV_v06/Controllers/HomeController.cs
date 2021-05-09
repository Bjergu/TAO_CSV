using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TAO_CSV_v06.Models;

namespace TAO_CSV_v06.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Tilskudsberegner()
        {
            ViewBag.Message = "Tilskudsberegner.";

            return View();
        }

        public ActionResult Mailer()
        {
            ViewBag.Message = "Mailer.";

            return View();
        }

        [Authorize]
        public ActionResult DataReads()
        {
            ViewBag.Message = "Datar reads";

            return View();
        }

        [Authorize]
        public ActionResult PrintSVC()
        {
            _dbContext.HourlyReads.ToList();
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ImportFile(HttpPostedFileBase importFile)
        {
            if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

            try
            {
                StreamReader reader = new StreamReader(importFile.InputStream);
                string content = reader.ReadToEnd();
                CSVTable table = new CSVTable(content, true, ';', '\n');
                List<HourlyRead> hr = table.ConvertCSVToModel<HourlyRead>((record) => new HourlyRead()
                {
                    // MeterNumber = int.Parse(record["MeterNumber"].ToString()),
                    MeterMeasureType = record["MeterMeasureType"].ToString(),
                    InstallationNumber = record["InstallationNumber"].ToString(),
                    Timestamp = record["Timestamp"].ToString(),
                    InfoCode = record["InfoCode"].ToString(),
                    Comment = record["Comment"].ToString(),
                    Energy = record["Energy"].ToString(),
                    EnergyUnit = record["EnergyUnit"].ToString(),
                    Volume = record["Volume"].ToString(),
                    VolumeUnit = record["VolumeUnit"].ToString(),
                    HourCounter = record["HourCounter"].ToString(),
                    HourCounterUnit = record["HourCounterUnit"].ToString(),
                    TempForward = record["TempForward"].ToString(),
                    TempForwardUnit = record["TempForwardUnit"].ToString(),
                    TempReturn = record["TempReturn"].ToString(),
                    TempReturnUnit = record["TempReturnUnit"].ToString(),
                    valueTempDiff = record["valueTempDiff"].ToString(),
                    TempDiffUnit = record["TempDiffUnit"].ToString(),
                    Power = record["Power"].ToString(),
                    PowerUnit = record["PowerUnit"].ToString(),
                    Flow = record["Flow"].ToString(),
                    FlowUnit = record["FlowUnit"].ToString(),
                    Peak = record["Peak"].ToString(),
                    PeakUnit = record["PeakUnit"].ToString(),
                    ForwardedUsage = record["ForwardedUsage"].ToString(),
                    ForwardedUsageUnit = record["ForwardedUsageUnit"].ToString(),
                    ReturnedUsage = record["ReturnedUsage"].ToString(),
                    ReturnedUsageUnit = record["ReturnedUsageUnit"].ToString(),
                });

                foreach (var s in hr)
                {
                    _dbContext.HourlyReads.Add(s);

                }
                //hr.ForEach(s => _dbContext.HourlyReadings.Add(s));
                _dbContext.SaveChanges();
                int i = _dbContext.HourlyReads.Count();

                return Json(new { Status = 1, Message = "File Imported Successfully " });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> ImportDailyReads(HttpPostedFileBase importFile)
        {
            if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

            try
            {
                StreamReader reader = new StreamReader(importFile.InputStream);
                string content = reader.ReadToEnd();
                CSVTable table = new CSVTable(content, false, ';', '\n');
                List<DailyRead> hr = table.ConvertCSVToModel<DailyRead>((record) => new DailyRead()
                {
                    // MeterNumber = int.Parse(record["MeterNumber"].ToString()),
                    Col_0 = record["Col_0"],
                    Col_1 = record["Col_1"],
                    Col_2 = record["Col_2"],
                    Col_3 = record["Col_3"],
                    Col_4 = record["Col_4"],
                    Col_5 = record["Col_5"],
                    Col_6 = record["Col_6"],
                    Col_7 = record["Col_7"].ToString(),
                    Col_8 = record["Col_8"].ToString(),
                    Col_9 = record["Col_9"].ToString(),
                    Col_10 = record["Col_10"].ToString(),
                    Col_11 = record["Col_11"].ToString(),
                    Col_12 = record["Col_12"].ToString(),
                    Col_13 = record["Col_13"].ToString(),
                    Col_14 = record["Col_14"].ToString(),
                    Col_15 = record["Col_15"].ToString(),
                    Col_16 = record["Col_16"].ToString(),
                    Col_17 = record["Col_17"].ToString(),
                    Col_18 = record["Col_18"].ToString(),
                    Col_19 = record["Col_19"].ToString(),
                    Col_20 = record["Col_20"].ToString(),
                    Col_21 = record["Col_21"].ToString(),
                    Col_22 = record["Col_22"].ToString(),
                    Col_23 = record["Col_23"].ToString(),
                    Col_24 = record["Col_24"].ToString(),
                    Col_25 = record["Col_25"].ToString(),
                    Col_26 = record["Col_26"].ToString(),
                    Col_27 = record["Col_27"].ToString(),
                    Col_28 = record["Col_28"].ToString(),
                    Col_29 = record["Col_29"].ToString(),
                    Col_30 = record["Col_30"].ToString(),
                });

                foreach (var s in hr)
                {
                    _dbContext.DailyReads.Add(s);

                }
                //hr.ForEach(s => _dbContext.HourlyReadings.Add(s));
                _dbContext.SaveChanges();
                int i = _dbContext.DailyReads.Count();

                return Json(new { Status = 1, Message = "File Imported Successfully " });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
            }
        }
    }
}