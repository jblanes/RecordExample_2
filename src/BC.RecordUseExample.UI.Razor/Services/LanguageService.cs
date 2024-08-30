using Microsoft.AspNetCore.Localization;

namespace BC.RecordUseExample.UI.Razor.Services
{
    public class LanguageService(IHttpContextAccessor contextAccessor)
    {
        private readonly IHttpContextAccessor _contextAccessor = contextAccessor;

        public void SetBrowserLanguage(string newCultureName)
        {
            if (string.IsNullOrWhiteSpace(newCultureName))
            {
                var currentCultureName = BrowserCulture();
                newCultureName = currentCultureName == "en" ? "es" : "en";
            }

            _contextAccessor.HttpContext!.Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);
            _contextAccessor.HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(newCultureName)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(15) }
                );
        }

        private string BrowserCulture()
        {
            var cultureFeature = _contextAccessor.HttpContext!.Features.Get<IRequestCultureFeature>();
            return cultureFeature!.RequestCulture.UICulture.Name[..2];
        }
    }
}
