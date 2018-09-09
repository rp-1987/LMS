using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LMS_BL.Utilities;

namespace LMS_UI.Models
{
    public class MenuViewModel
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public int ParentMenuID { get; set; }
        public string MenuUrl { get; set; }


        public IEnumerable<MenuViewModel> GetAllMenus(string RoleName)
        {
            Utilities obj = new Utilities();
            DataTable dt = obj.GetMenuItems(RoleName);
            var menuItems = from menus in dt.AsEnumerable()
                            select new MenuViewModel { 
                                MenuID = menus.Field<int>("MenuID"),
                                MenuName = menus.Field<string>("MenuName"),
                                ParentMenuID = menus.Field<int>("ParentMenuID"),
                                MenuUrl = menus.Field<string>("MenuUrl")
                            };
            return menuItems;
        }
    }
}