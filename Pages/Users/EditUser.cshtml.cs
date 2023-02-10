using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NiceLIA.Data;
using NiceLIA.Models.ViewModel;

namespace NiceLIA.Pages.Users
{
    public class EditUserModel : PageModel
    {
        private readonly UserDBContext dbContext;
        [BindProperty]
        public EditUserViewModel _EditUser { get; set; }

        public EditUserModel(UserDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(Guid id)
        {
            var user = dbContext._Users.Find(id);

            if(user != null)
            {
                _EditUser = new EditUserViewModel()
                {
                    Id = user.Id,
                    Education = user.Education,
                    Email = user.Email,
                    Location = user.Location,
                    Name = user.Name,
                    PhoneNr = user.PhoneNr,
                    School = user.School
                };

            }


        }

        public IActionResult OnPostUpdate()
        {
            var user = dbContext._Users.Find(_EditUser.Id);
            if(user != null)
            {
                user.Name = _EditUser.Name;
                user.PhoneNr = _EditUser.PhoneNr;
                user.Location = _EditUser.Location;
                user.Email = _EditUser.Email;
                user.Education= _EditUser.Education;
                user.School= _EditUser.School;

                dbContext.SaveChanges();
                return RedirectToPage("/Users/ListUsers");
            }
            return Page();
        }


        public IActionResult OnPostDelete()
        {

            var user = dbContext._Users.Find(_EditUser.Id);
            if(user != null)
            {
                dbContext._Users.Remove(user);
                dbContext.SaveChanges();
                return RedirectToPage("/Users/ListUsers");
            }
            return Page();
        }
    }
}
