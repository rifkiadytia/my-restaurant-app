using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;
using ERestaurant.Filters;
using ERestaurant.Models;
using ERestaurant.DataRepositories;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.Mvc;
using ERestaurant.Util;
using System.IO;
using ERestaurant.Customize;
using DevExpress.Data;
using DevExpress.Web.ASPxGridView;
using System.Web.SessionState;
using ERestaurant.Dataservice;

namespace ERestaurant.Controllers
{



    public class AccountController : Controller
    {

        public AccountRepositories account = new AccountRepositories();
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (account.IsValidUser(model.UserName, model.Password))
                {
                    var session = HttpContext.Session;
                    session["UserName"] = model.UserName;
                    return Redirect(returnUrl ?? "/");
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ManageRole()
        {
            IEnumerable<Role> role = account.GetAllRole();
            return View(role);
        }
        public ActionResult CreateRole()
        {
            return View();
        }

        public ActionResult EditRole(int id)
        {
            Role role = account.GetRoleById(id);
            return View(role);
        }
        [HttpPost]
        public ActionResult EditRole(Role role)
        {
            if (ModelState.IsValid)
            {
                bool isUpdateSc = account.UpdateRole(role);
                if (isUpdateSc)
                {
                    ViewBag.Message = "Role update successfully";
                    return View(role);
                }
                else
                {
                    ViewBag.Message = "Error while update role ";
                }
            }
            return View(role);
        }
        [HttpPost]
        public ActionResult CreateRole(Role role)
        {
            if (ModelState.IsValid)
            {
                bool isCreateSc = account.CreateRole(role);
                if (isCreateSc)
                {
                    ViewBag.Message = "Role create successfully ";
                    return View(role);
                }
                else
                {
                    ViewBag.Message = "Error while create role ";
                }
            }
            return View(role);
        }
        public ActionResult EditUser()
        {
            return View();
        }
        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            RenderCombo();
            return View();
        }
        private void RenderCombo()
        {
            ViewBag.AllPosition = account.GetAllPosition();
            List<Gender> allGender = new List<Gender>();
            Gender gender = new Gender();
            gender.GenderValue = false;
            gender.GenderName = "Male";
            allGender.Add(gender);
            gender = new Gender();
            gender.GenderValue = false;
            gender.GenderName = "Female";
            allGender.Add(gender);
            ViewBag.AllGender = allGender;
        }
        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            RenderCombo();
            if (ModelState.IsValid)
            {

                // Attempt to register the user
                bool isCreateSc = account.CreateUser(model);
                if (isCreateSc)
                {
                    ViewBag.Message = "Create user successfully";
                    return View(model);
                }
                else
                {
                    ViewBag.Message = "Error while create user";
                }
            }
            return View(model);
        }
        public ActionResult EditUserInfo(long id)
        {
            RenderCombo();
            RegisterModel model = account.GetUserById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditUserInfo(RegisterModel model)
        {
            RenderCombo();
            if (ModelState.IsValid)
            {

                // Attempt to register the user
               
                bool isCreateSc = account.UpdateUser(model);
                if (isCreateSc)
                {
                    ViewBag.Message = "User info update successfully";
                    return View(model);
                }
                else
                {
                    ViewBag.Message = "Error while update user info";
                }
            }
            return View(model);
        }
        //
        // GET: /Account/ChangePassword

        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                bool isChangePwdSc = account.ChangePassword(model);
                if (!isChangePwdSc)
                {
                    ModelState.AddModelError("", "Error occur in change password");
                }
                else
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
            }
            return View(model);
            // If we got this far, something failed, redisplay form
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion

        //User manager
        public ActionResult SearchUser()
        {
            return View("SearchUser");
        }
        public ActionResult SearchUserPartial()
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelWithSummary();
            return AdvancedCustomBindingCore(viewModel);
        }
        // Paging
        public ActionResult AdvancedCustomBindingPagingAction(GridViewPagerState pager)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyPagingState(pager);
            return AdvancedCustomBindingCore(viewModel);
        }
        // Filtering
        public ActionResult AdvancedCustomBindingFilteringAction(GridViewFilteringState filteringState)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyFilteringState(filteringState);
            return AdvancedCustomBindingCore(viewModel);
        }
        // Sorting
        public ActionResult AdvancedCustomBindingSortingAction(GridViewColumnState column, bool reset)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplySortingState(column, reset);
            return AdvancedCustomBindingCore(viewModel);
        }
        // Grouping
        public ActionResult AdvancedCustomBindingGroupingAction(GridViewColumnState column)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyGroupingState(column);
            return AdvancedCustomBindingCore(viewModel);
        }
        PartialViewResult AdvancedCustomBindingCore(GridViewModel viewModel)
        {
            viewModel.ProcessCustomBinding(
                GridViewCustomBindingHandlers.GetDataRowCountAdvanced,
                GridViewCustomBindingHandlers.GetDataAdvanced,
                GridViewCustomBindingHandlers.GetSummaryValuesAdvanced,
                GridViewCustomBindingHandlers.GetGroupingInfoAdvanced,
                GridViewCustomBindingHandlers.GetUniqueHeaderFilterValuesAdvanced
            );
            return PartialView("SearchUserPartial", viewModel);
        }
        static GridViewModel CreateGridViewModelWithSummary()
        {
            var viewModel = new GridViewModel();
            viewModel.KeyFieldName = "ID";
            viewModel.Columns.Add("Username");
            viewModel.Columns.Add("DOB");
            viewModel.Columns.Add("Position");
            viewModel.Columns.Add("Mobile");
            viewModel.Columns.Add("Address");
            viewModel.Columns.Add("Gender");
            return viewModel;
        }
        [HttpPost]
        public ActionResult UserDeletePartial(int ID)
        {
            if (ID >= 0)
            {
                bool isDeleteSc = account.DeleteUser(ID);
                if (!isDeleteSc)
                {
                    ViewBag.ErrMessage = "Error while delete user !";
                }
            }
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelWithSummary();
            return AdvancedCustomBindingCore(viewModel);
        }
        //Reset user password to default
        [HttpPost]
        public JsonResult ResetPassword(long ID)
        {
            if (ID >= 0)
            {
                string newPass = "123456789";
                bool resetPasswordSc = account.ResetUserPassword(ID, newPass);
                if (resetPasswordSc)
                {
                    return Json(new { status = "SC.001" },JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { status = "ERR.001" },JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UserUpdatePartial(UserInfo user)
        {
            if (ModelState.IsValid)
            {
                bool isUpdateSc = account.UpdateUserInGridModel(user);
                if (!isUpdateSc)
                {
                    ViewBag.ErrMessage = "Error while update user !";
                }
            }
            else
                ViewBag.ErrMessage = "Please, correct all errors.";

            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelWithSummary();
            return AdvancedCustomBindingCore(viewModel);
        }

        [HttpGet]
        public ActionResult AssignRole(long ID)
        {
            List<Role> lstRole = account.GetRoleByUser(ID);
            RegisterModel registerModel = account.GetUserById(ID);
            RoleModel model = new RoleModel();
            model.Roles = lstRole;
            model.UserId = ID;
            model.UserInfo = registerModel;
            return View(model);
        }
        [HttpPost]
        public ActionResult AssignRole(RoleModel model)
        {

            //recent role upload
            List<Role> upRoleAssign = model.Roles.Where(x => x.IsSelected == true).ToList();
            //role already assign
            List<Role> roleAssignUser = account.GetRoleAssignByUser(model.UserId);

            if (roleAssignUser != null)
            {
                if (upRoleAssign.Count== 0)
                {
                    account.RemoveRoleFromUser(roleAssignUser, model.UserId);
                }
                else
                {
                    if (roleAssignUser.Count > upRoleAssign.Count)
                    {
                        List<Role> removeSection = new List<Role>();
                        foreach (var item in roleAssignUser)
                        {
                            bool flg = false;
                            foreach (var item1 in upRoleAssign)
                            {
                                if (item.RoleID == item1.RoleID) { flg = true; }
                            }
                            if (!flg)
                            {
                                removeSection.Add(item);
                            }
                        }
                        account.RemoveRoleFromUser(removeSection, model.UserId);
                    }
                }
            }
            else
            {
                if (upRoleAssign.Count!= 0)
                {
                    account.AssignRoleToUser(model.UserId, upRoleAssign);
                }
            }
            return RedirectToAction("SearchUser","Account");
        }
        
    }
    public class GridViewEditingDemosHelper
    {
        const string
            EditingModeSessionKey = "AA054892-1B4C-4158-96F7-894E1545C05C";

        public static GridViewEditingMode EditMode
        {
            get
            {
                if (Session[EditingModeSessionKey] == null)
                    Session[EditingModeSessionKey] = GridViewEditingMode.EditFormAndDisplayRow;
                return (GridViewEditingMode)Session[EditingModeSessionKey];
            }
            set { HttpContext.Current.Session[EditingModeSessionKey] = value; }
        }
        protected static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    }
    
}