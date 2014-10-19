using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERestaurant.Models;
using ERestaurant.DataRepositories;
using ERestaurant.Util;
using System.IO;
using DevExpress.Web.Mvc;
using ERestaurant.Customize;
using ERestaurant.Dataservice;
namespace ERestaurant.Controllers
{
    public class HomeController : Controller
    {
        HomeRepositories repo = new HomeRepositories();
        public ActionResult Index()
        {
            // DXCOMMENT: Pass a data model for GridView
            return View();    
        }
        
       
        public ActionResult FoodCategory()
        {
            return View("FoodCategory");
        }
        public ActionResult FoodCategoryPartial()
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelFoodCategoryWithSummary();
            return AdvancedCustomBindingFoodCategory(viewModel);
        }
        static GridViewModel CreateGridViewModelFoodCategoryWithSummary()
        {
            var viewModel = new GridViewModel();
            viewModel.KeyFieldName = "FoodCatID";
            viewModel.Columns.Add("FoodCatName");
            return viewModel;
        }
        PartialViewResult AdvancedCustomBindingFoodCategory(GridViewModel viewModel)
        {
            GridViewCustomBindingHandlers.SetModel("FoodCategory");
            viewModel.ProcessCustomBinding(
                GridViewCustomBindingHandlers.GetDataRowCountAdvanced,
                GridViewCustomBindingHandlers.GetDataAdvanced,
                GridViewCustomBindingHandlers.GetSummaryValuesAdvanced,
                GridViewCustomBindingHandlers.GetGroupingInfoAdvanced,
                GridViewCustomBindingHandlers.GetUniqueHeaderFilterValuesAdvanced
            );
            return PartialView("FoodCategoryPartial", viewModel);
        }
        // Paging
        public ActionResult AdvancedCustomBindingPagingFoodCategoryAction(GridViewPagerState pager)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyPagingState(pager);
            return AdvancedCustomBindingFoodCategory(viewModel);
        }
        // Filtering
        public ActionResult AdvancedCustomBindingFilteringFoodCategoryAction(GridViewFilteringState filteringState)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyFilteringState(filteringState);
            return AdvancedCustomBindingFoodCategory(viewModel);
        }
        // Sorting
        public ActionResult AdvancedCustomBindingSortingFoodCategoryAction(GridViewColumnState column, bool reset)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplySortingState(column, reset);
            return AdvancedCustomBindingFoodCategory(viewModel);
        }
        // Grouping
        public ActionResult AdvancedCustomBindingGroupingFoodCategoryAction(GridViewColumnState column)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyGroupingState(column);
            return AdvancedCustomBindingFoodCategory(viewModel);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult FoodCategoryUpdatePartial(FoodCategoryMaster model)
        {
            if (ModelState.IsValid)
            {
                bool isUpdateSc = repo.UpdateFoodCategory(model);
                if (!isUpdateSc)
                {
                    ViewBag.ErrMessage = "Error while update food category !";
                }
            }
            else
                ViewBag.ErrMessage = "Please, correct all errors.";

            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelFoodCategoryWithSummary();
            return AdvancedCustomBindingFoodCategory(viewModel);
        }
        [HttpPost]
        public ActionResult FoodCategoryDeletePartial(long FoodCatID)
        {
            if (FoodCatID >= 0)
            {
                bool isDeleteSc = repo.DeleteFoodCategory(FoodCatID);
                if (!isDeleteSc)
                {
                    ViewBag.ErrMessage = "Error while delete food category !";
                }
            }
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelFoodCategoryWithSummary();
            return AdvancedCustomBindingFoodCategory(viewModel);
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
            return View("Food");

        }
        public ActionResult FoodPartial()
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelFoodWithSummary();
            return AdvancedCustomBindingFood(viewModel);
        }
        static GridViewModel CreateGridViewModelFoodWithSummary()
        {
            var viewModel = new GridViewModel();
            viewModel.KeyFieldName = "FoodID";
            viewModel.Columns.Add("FoodName");
            viewModel.Columns.Add("FoodCatID");
            viewModel.Columns.Add("Price");
            viewModel.Columns.Add("FinishingTime");
            viewModel.Columns.Add("FoodDescription");
            return viewModel;
        }
        PartialViewResult AdvancedCustomBindingFood(GridViewModel viewModel)
        {
            GridViewCustomBindingHandlers.SetModel("Food");
            viewModel.ProcessCustomBinding(
                GridViewCustomBindingHandlers.GetDataRowCountAdvanced,
                GridViewCustomBindingHandlers.GetDataAdvanced,
                GridViewCustomBindingHandlers.GetSummaryValuesAdvanced,
                GridViewCustomBindingHandlers.GetGroupingInfoAdvanced,
                GridViewCustomBindingHandlers.GetUniqueHeaderFilterValuesAdvanced
            );
            return PartialView("FoodPartial", viewModel);
        }
        // Paging
        public ActionResult AdvancedCustomBindingPagingFoodAction(GridViewPagerState pager)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyPagingState(pager);
            return AdvancedCustomBindingFood(viewModel);
        }
        // Filtering
        public ActionResult AdvancedCustomBindingFilteringFoodAction(GridViewFilteringState filteringState)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyFilteringState(filteringState);
            return AdvancedCustomBindingFood(viewModel);
        }
        // Sorting
        public ActionResult AdvancedCustomBindingSortingFoodAction(GridViewColumnState column, bool reset)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplySortingState(column, reset);
            return AdvancedCustomBindingFood(viewModel);
        }
        // Grouping
        public ActionResult AdvancedCustomBindingGroupingFoodAction(GridViewColumnState column)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyGroupingState(column);
            return AdvancedCustomBindingFood(viewModel);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult FoodCategoryAddNewPartial(FoodCategoryMaster model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.CreateFoodCategory(model);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelFoodCategoryWithSummary();
            return AdvancedCustomBindingFoodCategory(viewModel);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TableAddNewPartial(TableMaster model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.CreateTable(model);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelTableWithSummary();
            return AdvancedCustomBindingTable(viewModel);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult FoodUpdatePartial(FoodMaster model)
        {
            if (ModelState.IsValid)
            {
                bool isUpdateSc = repo.UpdateFood(model);
                if (!isUpdateSc)
                {
                    ViewBag.ErrMessage = "Error while update food !";
                }
            }
            else
                ViewBag.ErrMessage = "Please, correct all errors.";

            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelFoodWithSummary();
            return AdvancedCustomBindingFood(viewModel);
        }
        [HttpPost]
        public ActionResult FoodDeletePartial(long FoodID)
        {
            if (FoodID >= 0)
            {
                bool isDeleteSc = repo.DeleteFood(FoodID);
                if (!isDeleteSc)
                {
                    ViewBag.ErrMessage = "Error while delete food !";
                }
            }
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelFoodWithSummary();
            return AdvancedCustomBindingFood(viewModel);
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
                    ViewBag.Message = "Update successfully !";
                    ViewBag.FoodCategory = repo.GetAllFoodcategory();
                    FoodMaster food = repo.GetFoodById(model.FoodID);
                    return View(food);
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
            return View("Session");
        }
        public ActionResult SessionPartial()
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelSessionWithSummary();
            return AdvancedCustomBindingSession(viewModel);
        }
        static GridViewModel CreateGridViewModelSessionWithSummary()
        {
            var viewModel = new GridViewModel();
            viewModel.KeyFieldName = "SessionID";
            viewModel.Columns.Add("SessionName");
            viewModel.Columns.Add("SessionBelongTo");
            return viewModel;
        }
        PartialViewResult AdvancedCustomBindingSession(GridViewModel viewModel)
        {
            GridViewCustomBindingHandlers.SetModel("Session");
            viewModel.ProcessCustomBinding(
                GridViewCustomBindingHandlers.GetDataRowCountAdvanced,
                GridViewCustomBindingHandlers.GetDataAdvanced,
                GridViewCustomBindingHandlers.GetSummaryValuesAdvanced,
                GridViewCustomBindingHandlers.GetGroupingInfoAdvanced,
                GridViewCustomBindingHandlers.GetUniqueHeaderFilterValuesAdvanced
            );
            return PartialView("SessionPartial", viewModel);
        }
        // Paging
        public ActionResult AdvancedCustomBindingPagingSessionAction(GridViewPagerState pager)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyPagingState(pager);
            return AdvancedCustomBindingSession(viewModel);
        }
        // Filtering
        public ActionResult AdvancedCustomBindingFilteringSessionAction(GridViewFilteringState filteringState)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyFilteringState(filteringState);
            return AdvancedCustomBindingSession(viewModel);
        }
        // Sorting
        public ActionResult AdvancedCustomBindingSortingSessionAction(GridViewColumnState column, bool reset)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplySortingState(column, reset);
            return AdvancedCustomBindingSession(viewModel);
        }
        // Grouping
        public ActionResult AdvancedCustomBindingGroupingSessionAction(GridViewColumnState column)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyGroupingState(column);
            return AdvancedCustomBindingSession(viewModel);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SessionUpdatePartial(SessionMaster model)
        {
            if (ModelState.IsValid)
            {
                bool isUpdateSc = repo.UpdateSession(model);
                if (!isUpdateSc)
                {
                    ViewBag.ErrMessage = "Error while update session !";
                }
            }
            else
                ViewBag.ErrMessage = "Please, correct all errors.";

            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelSessionWithSummary();
            return AdvancedCustomBindingSession(viewModel);
        }
        [HttpPost]
        public ActionResult SessionDeletePartial(long SessionID)
        {
            if (SessionID >= 0)
            {
                bool isDeleteSc = repo.DeleteSession(SessionID);
                if (!isDeleteSc)
                {
                    ViewBag.ErrMessage = "Error while delete session !";
                }
            }
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelSessionWithSummary();
            return AdvancedCustomBindingSession(viewModel);
        }
        
        public ActionResult CreateSession()
        {
            IEnumerable<SessionMaster> allSession = DataProvider.GetInstance.GetAllSession();
            ViewBag.Session = allSession;
            return View();
            
        }

        [HttpPost]
        public ActionResult CreateSession(SessionMaster model)
        {
           
            if(ModelState.IsValid)
            {
                bool isCreateSc = repo.CreateSession(model);
                IEnumerable<SessionMaster> allSession = DataProvider.GetInstance.GetAllSession();
                ViewBag.Session = allSession;
                if (isCreateSc)
                {
                    return View(model);
                }

                return View(model);
            }
            else{
                IEnumerable<SessionMaster> allSession = DataProvider.GetInstance.GetAllSession();
                ViewBag.Session = allSession;
                return View(model);
            }
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SessionAddNewPartial(SessionMaster model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.CreateSession(model);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelSessionWithSummary();
            return AdvancedCustomBindingSession(viewModel);
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
            IEnumerable<SessionMaster> allSession = DataProvider.GetInstance.GetAllSession();
            ViewBag.Session = allSession;
            return View(master);
        }
        [HttpPost]
        public ActionResult EditSession(SessionMaster model)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<SessionMaster> allSession = DataProvider.GetInstance.GetAllSession(); 
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
                IEnumerable<SessionMaster> allSession = DataProvider.GetInstance.GetAllSession();
                ViewBag.Session = allSession;
                return View(model);
            }
           
        }
        public ActionResult SessionManagement()
        {
            List<TreeViewNode> treeViewNode = repo.GetTreeViewList();
            return View(treeViewNode);
        }
       
        public ActionResult Table()
        {
            return View("Table");
        }
        public ActionResult TablePartial()
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelTableWithSummary();
            if (string.IsNullOrEmpty(Request.Params["nodeName"]))
            {
                return AdvancedCustomBindingTable(viewModel);
            }
            else
            {
                string nodeId= Request.Params["nodeName"].ToString();
                return AdvancedCustomBindingTable(viewModel, nodeId);
            }
        }
        
        static GridViewModel CreateGridViewModelTableWithSummary()
        {
            var viewModel = new GridViewModel();
            viewModel.KeyFieldName = "TableID";
            viewModel.Columns.Add("TableName");
            viewModel.Columns.Add("SessionID");
            viewModel.Columns.Add("Type");
            return viewModel;
        }
        PartialViewResult AdvancedCustomBindingTable(GridViewModel viewModel)
        {
            GridViewCustomBindingHandlers.SetModel("Table");
            viewModel.ProcessCustomBinding(
                GridViewCustomBindingHandlers.GetDataRowCountAdvanced,
                GridViewCustomBindingHandlers.GetDataAdvanced,
                GridViewCustomBindingHandlers.GetSummaryValuesAdvanced,
                GridViewCustomBindingHandlers.GetGroupingInfoAdvanced,
                GridViewCustomBindingHandlers.GetUniqueHeaderFilterValuesAdvanced
            );
            return PartialView("TablePartial", viewModel);
        }
        PartialViewResult AdvancedCustomBindingTable(GridViewModel viewModel, string nodeId)
        {
            GridViewCustomBindingHandlers.NodeId = nodeId;
            GridViewCustomBindingHandlers.SetModel("TableTree");
            viewModel.ProcessCustomBinding(
                GridViewCustomBindingHandlers.GetDataRowCountAdvanced,
                GridViewCustomBindingHandlers.GetDataAdvanced,
                GridViewCustomBindingHandlers.GetSummaryValuesAdvanced,
                GridViewCustomBindingHandlers.GetGroupingInfoAdvanced,
                GridViewCustomBindingHandlers.GetUniqueHeaderFilterValuesAdvanced
            );
            return PartialView("TablePartial", viewModel);
        }
        // Paging
        public ActionResult AdvancedCustomBindingPagingTableAction(GridViewPagerState pager)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyPagingState(pager);
            return AdvancedCustomBindingTable(viewModel);
        }
        // Filtering
        public ActionResult AdvancedCustomBindingFilteringTableAction(GridViewFilteringState filteringState)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyFilteringState(filteringState);
            return AdvancedCustomBindingTable(viewModel);
        }
        // Sorting
        public ActionResult AdvancedCustomBindingSortingTableAction(GridViewColumnState column, bool reset)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplySortingState(column, reset);
            return AdvancedCustomBindingTable(viewModel);
        }
        // Grouping
        public ActionResult AdvancedCustomBindingGroupingTableAction(GridViewColumnState column)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyGroupingState(column);
            return AdvancedCustomBindingTable(viewModel);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TableUpdatePartial(TableMaster model)
        {
            if (ModelState.IsValid)
            {
                bool isUpdateSc = repo.UpdateTable(model);
                if (!isUpdateSc)
                {
                    ViewBag.ErrMessage = "Error while update update !";
                }
            }
            else
                ViewBag.ErrMessage = "Please, correct all errors.";

            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelTableWithSummary();
            return AdvancedCustomBindingTable(viewModel);
        }
        [HttpPost]
        public ActionResult TableDeletePartial(long TableID)
        {
            if (TableID >= 0)
            {
                bool isDeleteSc = repo.DeleteTable(TableID);
                if (!isDeleteSc)
                {
                    ViewBag.ErrMessage = "Error while delete table !";
                }
            }
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelTableWithSummary();
            return AdvancedCustomBindingTable(viewModel);
        }
        public ActionResult CreateTable()
        {
            ViewBag.Type = repo.GetType();
            ViewBag.Session = DataProvider.GetInstance.GetAllSession();
            return View();
        }
        [HttpPost]
        public ActionResult CreateTable(TableMaster model)
        {
            ViewBag.Type = repo.GetType();
            ViewBag.Session = DataProvider.GetInstance.GetAllSession();
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
            ViewBag.Session = DataProvider.GetInstance.GetAllSession();
            return View(table);
        }
        [HttpPost]
        public ActionResult EditTable(TableMaster model)
        {
            ViewBag.Type = repo.GetType();
            ViewBag.Session = DataProvider.GetInstance.GetAllSession();
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
        public ActionResult TestPage()
        {
            return View();
        }
    }
}