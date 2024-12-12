using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _DirectoryAlertUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
