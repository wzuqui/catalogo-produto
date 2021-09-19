using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CatalogoProduto.Api.Filters
{
    public class ModelStateFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext pContext)
        {
            if (!pContext.ModelState.IsValid)
                pContext.Result = new BadRequestObjectResult(pContext.ModelState);
        }

        public void OnActionExecuted(ActionExecutedContext pContext)
        {
            // ignored
        }
    }
}