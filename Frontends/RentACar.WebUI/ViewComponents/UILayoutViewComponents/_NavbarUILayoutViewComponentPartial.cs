using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
