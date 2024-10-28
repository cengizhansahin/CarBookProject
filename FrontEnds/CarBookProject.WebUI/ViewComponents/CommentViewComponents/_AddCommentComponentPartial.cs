using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.CommentViewComponents
{
    public class _AddCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
