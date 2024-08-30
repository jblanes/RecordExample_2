using BC.RecordUseExample.Backend.App.Commands;
using Microsoft.Extensions.Localization;

namespace BC.RecordUseExample.UI.Razor.Extensions
{
    public static class ModelStateExtensions
    {
        public static void SetErrors<T>(
            this Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState,
            IStringLocalizer<T> localizer, 
            string viewModelName, 
            CommandResult result)
        {
            var errors = result.GetErrorMessages();
            errors.ForEach(error => modelState.AddModelError($"{viewModelName}.{error.FieldName}", localizer[error.Text]));
        }
    }
}
