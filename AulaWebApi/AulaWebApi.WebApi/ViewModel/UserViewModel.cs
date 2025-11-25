using AulaWebApi.Models;

namespace AulaWebApi.WebApi.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        public string Email { get; set; } = string.Empty;
        //Foreign Key para person - POO Composição
        public Person Person { get; set; } = new Person();
    }
}
