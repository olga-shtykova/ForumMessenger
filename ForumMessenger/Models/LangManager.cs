using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace ForumMessenger.Models
{
    public class LangManager
    {
        public static List<Languages> AvailableLanguages = new List<Languages>
        {
            new Languages {LanguageFullName = "Русский", LanguageCultureName = "ru"},
            new Languages {LanguageFullName = "English", LanguageCultureName = "en"},
        };

        public bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguages.Where(a => a.LanguageCultureName.Equals(lang)).
                FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return AvailableLanguages[0].LanguageCultureName;
        }

        public void SetLanguage(string lang)
        {
            try
            {
                if (!IsLanguageAvailable(lang))
                {
                    lang = GetDefaultLanguage();
                }

                // Initialize a new instance of the CultureInfo class based on the culture specified by name.
                var cultureInfo = new CultureInfo(lang);

                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);

                HttpCookie langCookie = new HttpCookie("culture", lang);
                langCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(langCookie);
            }
            catch (Exception) {}
           
        }
    }
}