using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SGI_Web.Pages.Membro
{
    public class AtualizarModel : PageModel
    {
        private readonly IConfiguration _config;

        public AtualizarModel(IConfiguration config)
        {
            _config = config;
        }

        public void OnGet(int id)
        {
            ViewData.Add("URL_API", _config.GetValue<string>("SGI_API"));
            ViewData.Add("Id", id);
        }
    }
}
