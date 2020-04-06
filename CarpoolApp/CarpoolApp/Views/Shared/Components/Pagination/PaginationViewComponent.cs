using CarpoolApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
namespace CarpoolApp.Views.Shared.Components.Pagination
{

    public class PaginationViewComponent : ViewComponent
    {
        public PaginationViewComponent()
        {
        }

        public IViewComponentResult Invoke(IPagingList pagingList)
        {
            var previousPage = -1;
            var nextPage = -1;

            if (pagingList.PageCount > 1)
                previousPage = pagingList.PageIndex - 1;

            if (pagingList.PageIndex < pagingList.PageCount)
                nextPage = pagingList.PageIndex + 1;


            var model = new PaginationVM
            {
                StartPageIndex = pagingList.StartPageIndex,
                StopPageIndex = pagingList.StopPageIndex,
                NextPage = nextPage,
                PreviousPage = previousPage,
                PageCount = pagingList.PageCount,
                PageIndex = pagingList.PageIndex
            };

            return View("Pagination", model);
        }
    }
}

