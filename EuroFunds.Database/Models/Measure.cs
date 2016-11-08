namespace EuroFunds.Database.Models
{
    public class Measure
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SubmeasureId { get; set; }
        public int PriorityId { get; set; }
    }
}
