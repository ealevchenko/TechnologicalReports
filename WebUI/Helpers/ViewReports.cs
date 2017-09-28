using EFBF9.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Helpers
{
    public static class ViewReports
    {

        #region html

        #region ДЦ-2
        /// <summary>
        /// Вернуть название станции по id КИС
        /// </summary>
        /// <param name="html"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MvcHtmlString GetUgolLotka(this HtmlHelper html, UnloadBunker item, int position)
        {
            List<double> list = new List<double>();
            if (item.Отработанный_угол_лотка_11>0){ list.Add((double)item.Отработанный_угол_лотка_11);}
            if (item.Отработанный_угол_лотка_10>0){ list.Add((double)item.Отработанный_угол_лотка_10);}
            if (item.Отработанный_угол_лотка_9>0){ list.Add((double)item.Отработанный_угол_лотка_9);}
            if (item.Отработанный_угол_лотка_8>0){ list.Add((double)item.Отработанный_угол_лотка_8);}
            if (item.Отработанный_угол_лотка_7>0){ list.Add((double)item.Отработанный_угол_лотка_7);}
            if (item.Отработанный_угол_лотка_6>0){ list.Add((double)item.Отработанный_угол_лотка_6);}
            if (item.Отработанный_угол_лотка_5>0){ list.Add((double)item.Отработанный_угол_лотка_5);}
            if (item.Отработанный_угол_лотка_4>0){ list.Add((double)item.Отработанный_угол_лотка_4);}
            if (item.Отработанный_угол_лотка_3>0){ list.Add((double)item.Отработанный_угол_лотка_3);}
            if (item.Отработанный_угол_лотка_2>0){ list.Add((double)item.Отработанный_угол_лотка_2);}
            if (item.Отработанный_угол_лотка_1>0){ list.Add((double)item.Отработанный_угол_лотка_1);}
            int start = 0;
            if (start == 0  & item.Выгружено_в_позицию_1>0) {start=1;};
            if (start == 0  & item.Выгружено_в_позицию_2>0) {start=2;};
            if (start == 0  & item.Выгружено_в_позицию_3>0) {start=3;};
            if (start == 0  & item.Выгружено_в_позицию_4>0) {start=4;};
            if (start == 0  & item.Выгружено_в_позицию_5>0) {start=5;};
            if (start == 0  & item.Выгружено_в_позицию_6>0) {start=6;};
            if (start == 0  & item.Выгружено_в_позицию_7>0) {start=7;};
            if (start == 0  & item.Выгружено_в_позицию_8>0) {start=8;};
            if (start == 0  & item.Выгружено_в_позицию_9>0) {start=9;};
            if (start == 0  & item.Выгружено_в_позицию_10>0) {start=10;};
            if (start == 0  & item.Выгружено_в_позицию_11>0) {start=11;};
            int index = position - start;
            return MvcHtmlString.Create(index>=0 & index<list.Count() ? list[index].ToString("0.00") : "");
        }
        /// <summary>
        /// Вернуть режим работы
        /// </summary>
        /// <param name="html"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static MvcHtmlString GetMode(this HtmlHelper html, int mode)
        {
            return MvcHtmlString.Create(mode==0 ? View.GetStringBF9UnloadBunkerResource("mode_auto"): View.GetStringBF9UnloadBunkerResource("mode_remote"));
        }
        /// <summary>
        /// Режим управления
        /// </summary>
        /// <param name="html"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static MvcHtmlString GetControlMode(this HtmlHelper html, int mode)
        {
            return MvcHtmlString.Create(mode == 0 ? View.GetStringBF9UnloadBunkerResource("control_mode_time") : View.GetStringBF9UnloadBunkerResource("control_mode_mass"));
        }
        /// <summary>
        /// Режим работы
        /// </summary>
        /// <param name="html"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static MvcHtmlString GetUnloadMode(this HtmlHelper html, UnloadBunker item)
        {
            int mode = (int)item.Дистанция_при_переводе_лотка_на_угол_1 +
                (int)item.Дистанция_при_переводе_лотка_на_угол_2 +
                (int)item.Дистанция_при_переводе_лотка_на_угол_3 +
                (int)item.Дистанция_при_переводе_лотка_на_угол_4 +
                (int)item.Дистанция_при_переводе_лотка_на_угол_5 +
                (int)item.Дистанция_при_переводе_лотка_на_угол_6 +
                (int)item.Дистанция_при_переводе_лотка_на_угол_7 +
                (int)item.Дистанция_при_переводе_лотка_на_угол_8 +
                (int)item.Дистанция_при_переводе_лотка_на_угол_9 +
                (int)item.Дистанция_при_переводе_лотка_на_угол_10 +
                (int)item.Дистанция_при_переводе_лотка_на_угол_11;
            return MvcHtmlString.Create(mode == 0 ? View.GetStringBF9UnloadBunkerResource("mode_auto_full") : View.GetStringBF9UnloadBunkerResource("mode_remote_full"));
        }

        #endregion

        #endregion
    }
}