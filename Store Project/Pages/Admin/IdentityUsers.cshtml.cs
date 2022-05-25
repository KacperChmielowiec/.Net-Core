using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Admin
{
    [Authorize]
    public class IdentityUsersModel :PageModel
    {
        private UserManager<IdentityUser> userManager;
        public IdentityUsersModel(UserManager<IdentityUser> mgr)
        {
            userManager = mgr;
        }
        [BindProperty(SupportsGet = true)]
        public IdentityUser AdminUser { get; set; }
        public async Task OnGetAsync()
        {
            AdminUser = await userManager.FindByNameAsync("Admin");
        }
        public void OnGet()
        {

        }
        
    
    }
}
