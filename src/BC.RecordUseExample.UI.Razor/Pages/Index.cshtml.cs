using BC.RecordUseExample.Backend.App.Commands;
using BC.RecordUseExample.UI.Razor.Extensions;
using BC.RecordUseExample.UI.Razor.Services;
using BC.RecordUseExample.UI.Razor.ViewModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace BC.RecordUseExample.UI.Razor.Pages
{
    public class IndexModel(
        ILogger<IndexModel> logger, 
        SystemCommands systemCommands, 
        IStringLocalizer<SharedResource> localizer, 
        LanguageService languageService) : PageModel
    {
        private readonly LanguageService _languageService = languageService;
        private readonly ILogger<IndexModel> _logger = logger;
        private readonly SystemCommands _systemCommands = systemCommands;
        private readonly IStringLocalizer<SharedResource> _localizer = localizer;

        [BindProperty]
        public EmployeeViewModel EmployeeData { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPostEnglish()
        {
            // Cambio lenguaje a inglés
            _languageService.SetBrowserLanguage("en");
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostSpanish()
        {
            // Cambio lenguaje a español
            _languageService.SetBrowserLanguage("es");
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // Los datos entrados por el usuario se convierten a un comando, en este caso para crear un nuevo empleado, y el comando se envía para ejecución
                // El comando solo se ejecutará si los datos entrados son válidos. 
                // Aquí usamos nuestro SystemCommands en lugar de la librería MediatR (para SystemCommands ver el proyecto de Backend.App en esta solución)
                var result = await _systemCommands.ProcessAsync(EmployeeData);

                // Actualizar el ModelState con los posibles errores al procesar el comando
                if (result.IsFailure)
                {
                    // SetErrors es una extensión nuestra para facilitar el proceso de generar los mensajes,
                    // solo requiere el localizer para traducción, el nombre de la variable del ViewModel y el 
                    // resultado de la ejecución del comando
                    ModelState.SetErrors(_localizer, nameof(EmployeeData), result); 
                }

                // Regresar si hay errores
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                // En caso de no haber errores, redireccionar a página de éxito,
                // en este ejemplo un simple mensaje, pero normalmente algún tipo de listado que muestre la nueva entrada
                return RedirectToPage("/EmployeeCreated");
            }
            catch (Exception ex)  //En caso de errores graves (generalmente por pérdida de conexión a DB)
            {
                // log el error y relanzar para que se presente la página de error genérica (/Error)
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
