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
            // Cambio lenguaje a ingl�s
            _languageService.SetBrowserLanguage("en");
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostSpanish()
        {
            // Cambio lenguaje a espa�ol
            _languageService.SetBrowserLanguage("es");
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // Los datos entrados por el usuario se convierten a un comando, en este caso para crear un nuevo empleado, y el comando se env�a para ejecuci�n
                // El comando solo se ejecutar� si los datos entrados son v�lidos. 
                // Aqu� usamos nuestro SystemCommands en lugar de la librer�a MediatR (para SystemCommands ver el proyecto de Backend.App en esta soluci�n)
                var result = await _systemCommands.ProcessAsync(EmployeeData);

                // Actualizar el ModelState con los posibles errores al procesar el comando
                if (result.IsFailure)
                {
                    // SetErrors es una extensi�n nuestra para facilitar el proceso de generar los mensajes,
                    // solo requiere el localizer para traducci�n, el nombre de la variable del ViewModel y el 
                    // resultado de la ejecuci�n del comando
                    ModelState.SetErrors(_localizer, nameof(EmployeeData), result); 
                }

                // Regresar si hay errores
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                // En caso de no haber errores, redireccionar a p�gina de �xito,
                // en este ejemplo un simple mensaje, pero normalmente alg�n tipo de listado que muestre la nueva entrada
                return RedirectToPage("/EmployeeCreated");
            }
            catch (Exception ex)  //En caso de errores graves (generalmente por p�rdida de conexi�n a DB)
            {
                // log el error y relanzar para que se presente la p�gina de error gen�rica (/Error)
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
