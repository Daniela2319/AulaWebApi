using AulaWebApi.Models;

namespace AulaWebApi.WebApi.ViewModel
{
    public class UserViewModel: BaseViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int PersonId { get; set; }
        //Foreign Key para person - POO Composição
        public Person Person { get; set; }
    }
}
