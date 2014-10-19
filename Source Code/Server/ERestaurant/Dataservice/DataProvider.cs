using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERestaurant.Models;
using DevExpress.Web.Mvc;
namespace ERestaurant.Dataservice
{
    public class DataProvider
    {
        public static DataProvider dataProvider;
        public RestaurantDataContext context = DataConnection.Instance;
        private DataProvider()
        {
        }
        public List<Role> GetAllRole()
        {
            return context.Roles.ToList<Role>();
        }
        public List<Role> GetRoleByUser(long ID)
        {
            return context.Roles.ToList<Role>();
        }
        public static DataProvider GetInstance
        {
            get
            {
                if (dataProvider == null)
                {
                    dataProvider = new DataProvider();
                }
                return dataProvider;
            }
        }

        public IQueryable<PositionMaster> GetPostion()
        {
            return context.PositionMasters; 
        }
        public IEnumerable<SessionMaster> GetAllSession()
        {
            return context.SessionMasters.ToList();
        }
        public IEnumerable<SessionMaster> GetAllSessionForTable()
        {
            return context.SessionMasters.ToList();
        }
        public IEnumerable<FoodCategoryMaster> GetFoodCategory()
        {
            return context.FoodCategoryMasters.ToList();
        }
        public List<TableLevel> GetType()
        {
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
        public  IQueryable<Role> Roles { get { return context.Roles; } }
        public IQueryable<UserInfo> UserInfo { get { return context.UserInfos; } }
        public IQueryable<FoodCategoryMaster> FoodCategory { get { return context.FoodCategoryMasters; } }
        public IQueryable<TableMaster> Table { get { return context.TableMasters; } }
        public IQueryable<TableMaster> TableTree(long nodeId)
        {
            List<SessionStructureItem> allChild = context.SessionStructures.Where(x => x.SessionBelongTo == nodeId).Select(x => new SessionStructureItem(x.SessionID, x.SessionBelongTo)).ToList<SessionStructureItem>();
            
            if (allChild.Count != 0)
            {
                IQueryable<TableMaster> result = from c in context.TableMasters
                         where allChild.Select(z => z.SessionID).Contains(c.SessionID)
                         select c;

                return result;
            }
            return context.TableMasters.Take(0) ;

        }
        public IQueryable<SessionMaster> Session { get { return context.SessionMasters.Where(x=>x.SessionBelongto != -1); } }
        public IQueryable<FoodMaster> Food { get { return context.FoodMasters; } }
        
        public void CreateTreeViewNodesRecursive(List<TreeViewNode> model, MVCxTreeViewNodeCollection nodesCollection, long parentID)
        {
            var rows = model.Where(x=>x.SessionBelongTo == parentID);

            foreach (var item in rows)
            {
                MVCxTreeViewNode node = nodesCollection.Add(item.SessioName, item.SessionID.ToString());
                CreateTreeViewNodesRecursive(model, node.Nodes, item.SessionID);
            }
        }
    }
}