namespace AulaWebApi.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAd { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{this.Id} - {this.CreatedAd}";
        }
    }
}
