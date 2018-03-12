using Inspinia_MVC5_SeedProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5_SeedProject.Controllers
{

    class khalid
    {
        public int id { get; set; }

        public string name { get; set; }

    }

    public class ConstComputationController : Controller
    {
        CONST constDB = new CONST();

        

        string cs = ConfigurationManager.ConnectionStrings["CONST"].ConnectionString;

        /// <summary>
        /// GET: ConstComputation
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// ConstComputation/List
        /// </summary>
        /// <returns></returns>
        public JsonResult List()
        {
            List<ConstCompetitionViewModel> lccvm = new List<ConstCompetitionViewModel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("constCompetitionTest", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lccvm.Add(new ConstCompetitionViewModel
                    {
                        CompetitionID = Convert.ToInt32(rdr["CompetitionID"]),
                        competitionNo = rdr["competitionNo"].ToString(),
                        competitionNote = rdr["competitionNote"].ToString(),
                        CompetitionAddedDate = Convert.ToDateTime(rdr["CompetitionAddedDate"]),
                        competitionFragmented = Convert.ToBoolean(rdr["competitionFragmented"]),
                        CompetitionStatusName = rdr["CompetitionStatusName"].ToString(),
                        UserName = rdr["fullName"].ToString(),
                    });
                }
            }
            //try
            //{
            //    foreach (var item in constDB.ConstCompetitions)
            //    {
            //        lccvm.Add(new ConstCompetitionViewModel()
            //        {
            //            CompetitionID = item.CompetitionID,
            //            competitionNo = item.competitionNo,
            //            competitionNote = item.competitionNote,
            //            CompetitionAddedDate = item.CompetitionAddedDate,
            //            competitionFragmented = item.competitionFragmented,
            //            CompetitionStatusName = ((ConstCompetitionStatu)constDB.ConstCompetitionStatus.Where(p => p.CompetitionStatusID == item.CompetitionStatusID_FK).FirstOrDefault()).CompetitionStatusName,
            //            UserName = ((User)constDB.Users.Where(p => p.userNationalID == item.userNationalID_FK).FirstOrDefault()).name_A + " " + ((User)constDB.Users.Where(p => p.userNationalID == item.userNationalID_FK).FirstOrDefault()).lastName_A
            //        });
            //    }
            //}
            //catch (Exception err)
            //{
            //    return Json(err.Message, JsonRequestBehavior.AllowGet);
            //}
            return Json(lccvm, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ConstComputation/Add
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public JsonResult Add(ConstCompetition cc)
        {
            cc.CompetitionAddedDate = DateTime.Now;
            cc.CompetitionStatusID_FK = 1;
            cc.userNationalID_FK = 63012460;

            constDB.ConstCompetitions.Add(cc);
            constDB.SaveChanges();
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ConstComputation/Update
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public JsonResult Update(ConstCompetition cc)
        {
            constDB.ConstCompetitions.Find(cc.CompetitionID).competitionNo = cc.competitionNo;
            constDB.ConstCompetitions.Find(cc.CompetitionID).competitionNote = cc.competitionNote;
            constDB.ConstCompetitions.Find(cc.CompetitionID).competitionFragmented = cc.competitionFragmented;
            //constDB.ConstCompetitions.Find(cc.CompetitionID).competitionNote = cc.competitionNote;
            //constDB.ConstCompetitions.Find(cc.CompetitionID).competitionNote = cc.competitionNote;
            constDB.SaveChanges();
            
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ConstComputation/Delete
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public JsonResult Delete(int ID)
        {
            string[] res;
            var cc = constDB.ConstCompetitions.Find(ID);
            constDB.ConstCompetitions.Remove(cc);
            try
            {
                constDB.SaveChanges();
                res = new string[] { "ok",  "تم حذف البيانات بنجاح" };
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch(Exception err)
            {
                res = new string[] { "err", "يوجد مشاريع مرتبطة برقم المنافسة" };
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// ConstComputation/GetbyID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public JsonResult GetbyID(int ID)
        {
            var ConstCompetitions = constDB.ConstCompetitions.Find(ID);
            return Json(ConstCompetitions, JsonRequestBehavior.AllowGet);
        }
    }
}