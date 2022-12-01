using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SGI_Web.Pages.Lancamento
{
    public class AdicionarModel : PageModel
    {
        private readonly IConfiguration _config;

        public AdicionarModel(IConfiguration config)
        {
            _config = config;
        }

        public void OnGet()
        {
            ViewData.Add("URL_API", _config.GetValue<string>("SGI_API"));
        }
    }
}
