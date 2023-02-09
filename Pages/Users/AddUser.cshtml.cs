using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NiceLIA.Data;
using NiceLIA.Models.Domain;
using NiceLIA.Models.ViewModel;

namespace NiceLIA.Pages.Users
{
    public class AddUserModel : PageModel
    {
        private readonly UserDBContext dbcontext;

        [BindProperty]
        public AddUserViewModel AddUserRequest { get; set; }

        public AddUserModel(UserDBContext dbcontext)
        {
            this.dbcontext = dbcontext; 
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var userDomainModel = new User
            {
                Name = AddUserRequest.Name,
                Email = AddUserRequest.Email,
                Education= AddUserRequest.Education,
                Location= AddUserRequest.Location,
                PhoneNr= AddUserRequest.PhoneNr,
                School = AddUserRequest.School
            };

            dbcontext._Users.Add(userDomainModel);
            dbcontext.SaveChanges();
        }
    }
}
