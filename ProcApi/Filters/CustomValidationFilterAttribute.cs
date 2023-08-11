using Microsoft.AspNetCore.Mvc.Filters;
using ProcApi.ViewModels;

namespace ProcApi.Filters
{
    public class CustomValidationFilterAttribute : ActionFilterAttribute
    {
        public CustomValidationFilterAttribute()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = new List<ErrorViewModel>();

                foreach (var error in context.ModelState.Values)
                {

                }
            }

            base.OnActionExecuting(context);
        }
    }
}
