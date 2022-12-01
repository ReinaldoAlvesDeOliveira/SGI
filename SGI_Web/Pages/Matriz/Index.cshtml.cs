using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SGI_Web.Pages.Matriz
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;

        public IndexModel(IConfiguration config)
        {
            _config = config;
        }

        public void OnGet()
        {
            ViewData.Add("URL_API", _config.GetValue<string>("SGI_API"));
        }
    }
}
