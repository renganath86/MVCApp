using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
namespace MvcApplication1.Controllers
{
    public class DemoController : Controller
    {
        //
        // GET: /Demo/

        public ActionResult Index()
        {
            loadnightreqdetailsdropdown();
            loadpickupdroplst();
            return View();
        }
        [HttpGet]
        public ActionResult Country()
        {
            loadCountry();
            return View();
        }
        
        public ActionResult Country(string CountryName)
        {
            string path = Server.MapPath("~/CountryDet.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataRow[] dr = dt.Select("Country_Desc='" + CountryName + "'");
            string Countrycd = string.Empty;
            if (dr.Length > 0)
            {
                Countrycd = dr[0]["Country_Cd"].ToString();
            }
            var result = new { Value = Countrycd.ToString() };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public void loadCountry()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            string path = Server.MapPath("~/CountryDet.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lst.Add(new SelectListItem { Text = ds.Tables[0].Rows[i]["Country_Desc"].ToString(), Value = ds.Tables[0].Rows[i]["Country_Cd"].ToString() });
            }            
            ViewBag.CountryLst = lst;
        }
        public ActionResult Unit(string Unit)
        {
            string path = Server.MapPath("~/Pincodes.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataRow[] dr=dt.Select("Name='"+ Unit + "'");
            string pincd = string.Empty;
            if (dr.Length > 0)
            {
                pincd = dr[0]["Cd"].ToString();
            }
            var result = new { Value = pincd.ToString() };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public void loadnightreqdetailsdropdown()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem { Text = "Night Drop", Value ="Night Drop" });
            lst.Add(new SelectListItem { Text = "Others", Value = "Others" });
            ViewBag.nightdrp = lst;
            Session["nightdrp"] = lst;
        }
        public void loadpickupdroplst()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem { Text = "Velachery", Value = "Velachery" });
            lst.Add(new SelectListItem { Text = "KK Nagar", Value = "KK Nagar" });
            lst.Add(new SelectListItem { Text = "MKB Nagar", Value = "MKB Nagar" });
            ViewBag.pickupdrp = lst;
            Session["nightdrp"] = lst;
        }
    }
}
