using ForumMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumMessenger.Controllers
{
    public class LangController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string lang = null;

            // Получаем куки пользователя
            // Сохраняем выбранную культуру в куки
            HttpCookie langCookie = Request.Cookies["culture"];

            // если куки уже установлено, то обновляем значение
            if (langCookie != null)
            {
                lang = langCookie.Value;
            }
            else
            {
                // Получает отсортированный массив языковых предпочтений пользователя
                var userLanguage = Request.UserLanguages;

                var userlang = userLanguage != null ? userLanguage[0] : "";

                if (userlang != "")
                {
                    lang = userlang;
                }
                else
                {
                    lang = LangManager.GetDefaultLanguage();
                }
            }

            new LangManager().SetLanguage(lang);

            return base.BeginExecuteCore(callback, state);
        }

    }
}