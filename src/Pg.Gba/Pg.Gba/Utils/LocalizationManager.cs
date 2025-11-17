using System.Globalization;
using System.Resources;
using System.Threading;

namespace Pg.Gba.Localization
{
    public static class LocalizationManager
    {
        private static ResourceManager _resourceManager = new ResourceManager("Pg.Gba.Resources.Resources", typeof(LocalizationManager).Assembly);

        public static void SetLanguage(string cultureName)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
        }

        public static string GetString(string key)
        {
            return _resourceManager.GetString(key);
        }
    }
}