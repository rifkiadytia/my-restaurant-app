using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERestaurant.Models;

namespace ERestaurant.Dataservice
{
    public class DataConnection
    {
        private static volatile RestaurantDataContext instance;
        private static object syncRoot = new Object();

        private DataConnection() { }

        public static RestaurantDataContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new RestaurantDataContext();
                    }
                }
                return instance;
            }
        }
    }
}