using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
