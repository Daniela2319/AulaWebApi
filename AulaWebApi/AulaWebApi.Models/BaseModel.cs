namespace AulaWebApi.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}
