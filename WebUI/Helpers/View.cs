using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Mvc;
using WebUI.App_LocalResources;

namespace WebUI.Helpers
{
    public static class View
    {
        public static string GetStringGlobalResource(string key)
        {
            ResourceManager rm_global = new ResourceManager(typeof(GlobalResource));
            return rm_global.GetString(key, CultureInfo.CurrentCulture);
        }

        public static string GetStringMenuResource(string key)
        {
            ResourceManager rm_menu = new ResourceManager(typeof(MenuResource));
            return rm_menu.GetString(key, CultureInfo.CurrentCulture);
        }

        public static string GetStringBF9UnloadBunkerResource(string key)
        {
            ResourceManager BF9UnloadBunker = new ResourceManager(typeof(BF9UnloadBunkerResource));
            return BF9UnloadBunker.GetString(key, CultureInfo.CurrentCulture);
        }
        #region html

        #region Станции
        /// <summary>
        /// Вернуть название станции по id КИС
        /// </summary>
        /// <param name="html"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MvcHtmlString GetActionMenuTitle(this HtmlHelper html, string action)
        {
            return MvcHtmlString.Create(GetStringMenuResource(action).ToString());
        }

        #endregion

        #endregion
    }
}