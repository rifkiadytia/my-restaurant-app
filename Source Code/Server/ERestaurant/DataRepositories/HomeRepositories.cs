using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERestaurant.Models;

namespace ERestaurant.DataRepositories
{
    public class HomeRepositories
    {
        private static RestaurantDataContext dataContext = Dataservice.DataConnection.Instance;

        public IEnumerable<FoodCategoryMaster>  GetAllFoodcategory()
        {
            return dataContext.FoodCategoryMasters.ToList();
        }

        public bool CreateFoodCategory(FoodCategoryMaster category)
        {
            try
            {
                dataContext.FoodCategoryMasters.InsertOnSubmit(category);
                dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public FoodCategoryMaster GetFoodCategoryById(long id)
        {
            return dataContext.FoodCategoryMasters.Where(x => x.FoodCatID == id).FirstOrDefault();
        }

        public bool UpdateFoodCategory(FoodCategoryMaster category)
        {
            try
            {
                FoodCategoryMaster foodctg = dataContext.FoodCategoryMasters.Where(x => x.FoodCatID == category.FoodCatID).FirstOrDefault();
                foodctg.FoodCatName = category.FoodCatName;
                dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteFoodCategory(long id)
        {
            try
            {
                FoodCategoryMaster foodctg = dataContext.FoodCategoryMasters.Where(x => x.FoodCatID == id).FirstOrDefault();
                dataContext.FoodCategoryMasters.DeleteOnSubmit(foodctg);
                dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<FoodMaster> AllFood()
        {
            return dataContext.FoodMasters.ToList();
        }

        public FoodMaster GetFoodById(long id)
        {
            return dataContext.FoodMasters.Where(x => x.FoodID == id).FirstOrDefault();
        }
        public bool CreateFood(FoodMaster food)
        {
            try
            {
                dataContext.FoodMasters.InsertOnSubmit(food);
                dataContext.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool UpdateFood(FoodMaster food)
        {
            try
            {
                FoodMaster fd = dataContext.FoodMasters.Where(x => x.FoodID == food.FoodID).FirstOrDefault();
                fd.FoodDescription = food.FoodDescription;
                fd.FoodName = food.FoodName;
                fd.Price = food.Price;
                fd.Image = food.Image;
                fd.FoodCatID = food.FoodCatID;
                fd.FinishingTime = fd.FinishingTime;
                dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteFood(long id)
        {
            try
            {
                FoodMaster food = dataContext.FoodMasters.Where(x => x.FoodID == id).FirstOrDefault();
                dataContext.FoodMasters.DeleteOnSubmit(food);
                dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
       
        //public IEnumerable<SessionMaster> GetALlSession()
        //{
        //    return dataContext.SessionMasters.ToList();
        //}

        public SessionMaster GetSessionById(long sessionId)
        {
            return dataContext.SessionMasters.Where(x => x.SessionID == sessionId).FirstOrDefault();
        }
        public bool CreateSession(SessionMaster model)
        {
            try
            {
                long sesssionId = 0 ; 
                if (model.SessionBelongto.HasValue)
                {
                    List<long> allParent = GetParent( model.SessionBelongto.Value);
                    dataContext.SessionMasters.InsertOnSubmit(model);
                    dataContext.SubmitChanges();
                    sesssionId = model.SessionID;
                    SessionStructure structure = new SessionStructure();
                    structure.SessionID = sesssionId;
                    structure.SessionBelongTo = sesssionId;
                    dataContext.SessionStructures.InsertOnSubmit(structure);
                    foreach (long item in allParent)
                    {
                        structure = new SessionStructure();
                        structure.SessionID = sesssionId;
                        structure.SessionBelongTo = item;
                        dataContext.SessionStructures.InsertOnSubmit(structure);
                    }
                    dataContext.SubmitChanges();
                }
                else
                {
                    model.SessionBelongto = dataContext.SessionMasters.Where(x => x.SessionBelongto == -1).FirstOrDefault().SessionID; 
                    dataContext.SessionMasters.InsertOnSubmit(model);
                    dataContext.SubmitChanges();
                    //Insert into session structure
                    sesssionId = model.SessionID;
                    SessionStructure structure = new SessionStructure();
                    structure.SessionID = sesssionId;
                    structure.SessionBelongTo = sesssionId;
                    dataContext.SessionStructures.InsertOnSubmit(structure);
                    dataContext.SubmitChanges();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Get all parent of session
        public List<long> GetParent(long sessionID)
        {
            List<long> allParent = dataContext.SessionStructures.Where(x => x.SessionID == sessionID).Select(x=>x.SessionBelongTo).ToList<long>();
            return allParent;
        }

        public List<SessionStructureItem> FindAllChildren(long sessionID)
        {
            List<SessionStructureItem> allChild = dataContext.SessionStructures.Where(x => x.SessionID == sessionID).Select(x=>new SessionStructureItem(x.SessionID,x.SessionBelongTo)).ToList<SessionStructureItem>();
            return allChild;
        }
        
        public List<SessionStructureItem> FindAllParent(long sessionID)
        {
            List<SessionStructureItem> allChild = dataContext.SessionStructures.Where(x => x.SessionBelongTo == sessionID).Select(x => new SessionStructureItem(x.SessionID, x.SessionBelongTo)).ToList<SessionStructureItem>();
            return allChild;
        }
      
        public bool DeleteSession(long sessionId)
        {
            try
            {
                //Step 1 :Delete from session structure
                //1 : Delete all children
                List<SessionStructureItem> allChild = FindAllChildren(sessionId);
                if (allChild.Count != 0)
                {
                    foreach (SessionStructureItem item in allChild)
                    {
                        SessionStructure st = dataContext.SessionStructures.Where(x => x.SessionID == item.SessionID && x.SessionBelongTo == item.SessionBelongTo).FirstOrDefault();
                        dataContext.SessionStructures.DeleteOnSubmit(st);
                    }
                    dataContext.SubmitChanges();
                }
                //2 : Delete all parent
                List<SessionStructureItem> allParent = FindAllParent(sessionId);

                if (allParent.Count != 0)
                {
                    foreach (SessionStructureItem item in allParent)
                    {
                        SessionStructure st = dataContext.SessionStructures.Where(x => x.SessionID == item.SessionID && x.SessionBelongTo == item.SessionBelongTo).FirstOrDefault();
                        dataContext.SessionStructures.DeleteOnSubmit(st);
                    }
                    dataContext.SubmitChanges();
                }
                SessionMaster session = dataContext.SessionMasters.Where(x => x.SessionID == sessionId).FirstOrDefault();
                dataContext.SessionMasters.DeleteOnSubmit(session);
                dataContext.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool UpdateSession(SessionMaster model)
        {
            try
            {
                //Step 1 :Delete from session structure
                //1 : Delete all children
                List<SessionStructureItem> allChild = FindAllChildren(model.SessionID);
                if (allChild.Count != 0)
                {
                    foreach (SessionStructureItem item in allChild)
                    {
                        SessionStructure st = dataContext.SessionStructures.Where(x => x.SessionID == item.SessionID && x.SessionBelongTo == item.SessionBelongTo).FirstOrDefault();
                        dataContext.SessionStructures.DeleteOnSubmit(st);
                    }
                    dataContext.SubmitChanges();
                }
                //2 : Delete all parent
                List<SessionStructureItem> allParent = FindAllParent(model.SessionID);

                if (allParent.Count != 0)
                {
                    foreach (SessionStructureItem item in allParent)
                    {
                        SessionStructure st = dataContext.SessionStructures.Where(x => x.SessionID == item.SessionID && x.SessionBelongTo == item.SessionBelongTo).FirstOrDefault();
                        dataContext.SessionStructures.DeleteOnSubmit(st);
                    }
                    dataContext.SubmitChanges();
                }
                //Insert new session structure
                long sesssionId = 0;
                if (model.SessionBelongto.HasValue)
                {
                    List<long> allParents = GetParent(model.SessionBelongto.Value);
                    SessionMaster master = dataContext.SessionMasters.Where(x => x.SessionID == model.SessionID).FirstOrDefault();
                    master.SessionName = model.SessionName;
                    master.SessionBelongto = model.SessionBelongto;
                    dataContext.SubmitChanges();
                    sesssionId = model.SessionID;
                    SessionStructure structure = new SessionStructure();
                    structure.SessionID = sesssionId;
                    structure.SessionBelongTo = sesssionId;
                    dataContext.SessionStructures.InsertOnSubmit(structure);
                    foreach (long item in allParents)
                    {
                        structure = new SessionStructure();
                        structure.SessionID = sesssionId;
                        structure.SessionBelongTo = item;
                        dataContext.SessionStructures.InsertOnSubmit(structure);
                    }
                    dataContext.SubmitChanges();
                }
                else
                {
                   
                    //Insert into session structure
                    sesssionId = model.SessionID;
                    SessionStructure structure = new SessionStructure();
                    structure.SessionID = sesssionId;
                    structure.SessionBelongTo = sesssionId;
                    dataContext.SessionStructures.InsertOnSubmit(structure);
                    dataContext.SubmitChanges();
                    //Update session master
                    SessionMaster master = dataContext.SessionMasters.Where(x => x.SessionID == model.SessionID).FirstOrDefault();
                    master.SessionName = model.SessionName;
                    master.SessionBelongto = dataContext.SessionMasters.Where(x => x.SessionBelongto == -1).FirstOrDefault().SessionID; 
                    dataContext.SubmitChanges();

                }
               
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<TableMaster> GetAllTable()
        {
            return dataContext.TableMasters.ToList();
        }

        public List<TableLevel> GetType(){
            List<TableLevel> lst = new List<TableLevel>();
            TableLevel lv = new TableLevel();
            lv.TableValue = "Vip";
            lv.TableDisplay = "Vip";
            lst.Add(lv);
            lv = new TableLevel();
            lv.TableValue = "Normal";
            lv.TableDisplay = "Normal";
            lst.Add(lv);
            return lst;
        }

        public bool CreateTable(TableMaster table)
        {
            try
            {
                dataContext.TableMasters.InsertOnSubmit(table);
                dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public TableMaster GetTableById(long tableId)
        {
            return dataContext.TableMasters.Where(x => x.TableID == tableId).FirstOrDefault();

        }
        public bool UpdateTable(TableMaster model)
        {
            try
            {
                TableMaster table = dataContext.TableMasters.Where(x => x.TableID == model.TableID).FirstOrDefault();
                table.TableName = model.TableName;
                table.SessionID = model.SessionID;
                table.IsReserve = model.IsReserve;
                table.Type = model.Type;
                dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteTable(long id)
        {
            try
            {
                TableMaster table = dataContext.TableMasters.Where(x => x.TableID == id).FirstOrDefault();
                dataContext.TableMasters.DeleteOnSubmit(table);
                dataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        
        public List<TreeViewNode> GetTreeViewList()
        {
            List<TreeViewNode> listRootNode = (from src in dataContext.SessionMasters
                                       where src.SessionBelongto == -1
                                       select new TreeViewNode()
                                       {
                                           SessionID = src.SessionID,
                                           SessioName = src.SessionName,
                                           SessionBelongTo = src.SessionBelongto.Value
                                       }).ToList<TreeViewNode>();
            List<TreeViewNode> finalTree = new List<TreeViewNode>();
            foreach (var item in listRootNode)
            {
                finalTree.Add(item);
                BuildChildNode(item, ref finalTree);
            }
            return finalTree;
        }
        //Build session master treeview
        private void BuildChildNode(TreeViewNode rootNode, ref List<TreeViewNode> listRootNode)
        {
            if (rootNode != null)
            {
                List<TreeViewNode> chidNode = (from src in dataContext.SessionMasters
                                                 where src.SessionBelongto.Value == rootNode.SessionID
                                                 select new TreeViewNode()
                                                 {
                                                     SessionID = src.SessionID,
                                                     SessioName = src.SessionName,
                                                     SessionBelongTo =src.SessionBelongto.Value
                                                 }).ToList<TreeViewNode>();
                if (chidNode.Count > 0)
                {
                    foreach (var childRootNode in chidNode)
                    {
                        BuildChildNode(childRootNode, ref listRootNode);
                        listRootNode.Add(childRootNode);
                    }
                }
            }
        } 
    }
}