using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERestaurant.Models;
using ERestaurant.DataRepositories;
using ERestaurant.Util;
using System.IO;

namespace ERestaurant.Controllers
{
    public class HomeController : Controller
    {
        HomeRepositories repo = new HomeRepositories();
        public ActionResult Index()
        {
            // DXCOMMENT: Pass a data model for GridView
            return View(NorthwindDataProvider.GetCustomers());    
        }
        
        public ActionResult GridViewPartialView() 
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", NorthwindDataProvider.GetCustomers());
        }
        public ActionResult FoodCategory()
        {
            IEnumerable<FoodCategoryMaster> data = repo.GetAllFoodcategory();
            return View(data);
        }
        public ActionResult CreateFoodCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFoodCategory(FoodCategoryMaster model)
        {
            if (ModelState.IsValid)
            {
                bool isCreateSc = repo.CreateFoodCategory(model);
                if (isCreateSc)
                {
                    return View();
                }
            }

            return View(model);
        }

        public ActionResult EditFoodCategory(long id)
        {
            FoodCategoryMaster data = repo.GetFoodCategoryById(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult EditFoodCategory(FoodCategoryMaster model)
        {
            if (ModelState.IsValid)
            {
                bool isUpdateSc = repo.UpdateFoodCategory(model);
                if (isUpdateSc)
                {
                    return View();
                }
            }
            
            return View(model);
        }
       
        public ActionResult DeleteFoodCategory(long id)
        {
            bool isDeleteSc = repo.DeleteFoodCategory(id);
            if (isDeleteSc)
            {
                return RedirectToAction("FoodCategory");
            }
            return RedirectToAction("FoodCategory");
        }

        public ActionResult Food()
        {
            IEnumerable<FoodMaster> data = repo.AllFood();
            return View(data);

        }
        public ActionResult CreateFood()
        {
            ViewBag.FoodCategory = repo.GetAllFoodcategory();
            return View();
        }
        [HttpPost]
        public ActionResult CreateFood(FoodMaster model)
        {
            ViewBag.FoodCategory = repo.GetAllFoodcategory();
            HttpPostedFileBase httpPostFile = Request.Files["Image"];
            if (ModelState.IsValid && httpPostFile !=null)
            {
                //create new name
                string strName = UploadFileUtil.CreateNewName(httpPostFile.FileName);
                string strPath = Path.Combine(Server.MapPath("/Upload/images"), strName);
                ImageUtil.GetInstance.CompressImageUpload(httpPostFile, strPath);
                model.Image = strName;
                bool isCreateSc = repo.CreateFood(model);
                if (isCreateSc)
                    return View();
                else
                {
                    ModelState.AddModelError("err", "Error");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult EditFood(long id)
        {
            ViewBag.FoodCategory = repo.GetAllFoodcategory();
            FoodMaster food = repo.GetFoodById(id);
            return View(food);
        }
        [HttpPost]
        public ActionResult EditFood(FoodMaster model)
        {
            ViewBag.FoodCategory = repo.GetAllFoodcategory();
            HttpPostedFileBase httpPostFile = Request.Files["Image"];
            if (ModelState.IsValid)
            {
                if (httpPostFile != null && !String.IsNullOrEmpty(httpPostFile.FileName))
                {
                    //create new name
                    string strName = UploadFileUtil.CreateNewName(httpPostFile.FileName);
                    string strPath = Path.Combine(Server.MapPath("/Upload/images"), strName);
                    ImageUtil.GetInstance.CompressImageUpload(httpPostFile, strPath);
                    model.Image = strName;
                }
                bool updateSc = repo.UpdateFood(model);
                if (updateSc)
                {
                    return View(model);
                }
                return View(model);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeleteFood(long id)
        {
            bool isDeleteSc = repo.DeleteFood(id);
            if (isDeleteSc)
            {
                return RedirectToAction("Food");
            }
            return RedirectToAction("Food");
        }
        public ActionResult Session()
        {
            IEnumerable<SessionMaster> allSession = repo.GetALlSession();
            return View(allSession);
        }
        public ActionResult CreateSession()
        {
            IEnumerable<SessionMaster> allSession = repo.GetALlSession();
            ViewBag.Session = allSession;
            return View();
            
        }

        [HttpPost]
        public ActionResult CreateSession(SessionMaster model)
        {
           
            if(ModelState.IsValid)
            {
                bool isCreateSc = repo.CreateSession(model);
                IEnumerable<SessionMaster> allSession = repo.GetALlSession();
                ViewBag.Session = allSession;
                if (isCreateSc)
                {
                    return View(model);
                }

                return View(model);
            }
            else{
                IEnumerable<SessionMaster> allSession = repo.GetALlSession();
                ViewBag.Session = allSession;
                return View(model);
            }
        }
        public ActionResult DeleteSession(long id)
        {
            bool isDeleteSc = repo.DeleteSession(id);
            if (isDeleteSc)
            {
                return RedirectToAction("Session");
            }
            return RedirectToAction("Session");
        }
        public ActionResult EditSession(long id)
        {
            SessionMaster master = repo.GetSessionById(id);
            IEnumerable<SessionMaster> allSession = repo.GetALlSession();
            ViewBag.Session = allSession;
            return View(master);
        }
        [HttpPost]
        public ActionResult EditSession(SessionMaster model)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<SessionMaster> allSession = repo.GetALlSession();
                ViewBag.Session = allSession;
                bool isUpdateSessionSc = repo.UpdateSession(model);
                if (isUpdateSessionSc)
                {
                    return View(model);
                }
                return View(model);
            }
            else
            {
                IEnumerable<SessionMaster> allSession = repo.GetALlSession();
                ViewBag.Session = allSession;
                return View(model);
            }
           
        }
        public ActionResult Table()
        {
            IEnumerable<TableMaster> allTable = repo.GetAllTable();
            return View(allTable);
        }

        public ActionResult CreateTable()
        {
            ViewBag.Type = repo.GetType();
            ViewBag.Session = repo.GetALlSession();
            return View();
        }
        [HttpPost]
        public ActionResult CreateTable(TableMaster model)
        {
            ViewBag.Type = repo.GetType();
            ViewBag.Session = repo.GetALlSession();
            if (ModelState.IsValid)
            {
                bool isCreateSc = repo.CreateTable(model);
                if (isCreateSc)
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
            return View();
        }
        public ActionResult EditTable(long id)
        {
            TableMaster table = repo.GetTableById(id);
            ViewBag.Type = repo.GetType();
            ViewBag.Session = repo.GetALlSession();
            return View(table);
        }
        [HttpPost]
        public ActionResult EditTable(TableMaster model)
        {
            ViewBag.Type = repo.GetType();
            ViewBag.Session = repo.GetALlSession();
            if (ModelState.IsValid)
            {
                bool isUpdateSc = repo.UpdateTable(model);
                if (isUpdateSc)
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
            return View(model);
        }
        public ActionResult DeleteTable(long id)
        {
            bool isDeleteSc = repo.DeleteTable(id);
            if (isDeleteSc)
            {
                return RedirectToAction("Table");
            }
            return RedirectToAction("Table");
        }
    }
}