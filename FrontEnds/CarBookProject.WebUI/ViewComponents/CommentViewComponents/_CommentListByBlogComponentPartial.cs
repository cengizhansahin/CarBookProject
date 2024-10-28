using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
