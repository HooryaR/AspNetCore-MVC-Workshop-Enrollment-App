namespace Assignment2EF.Models
{
    public class Workshop
    {
        public int WorkshopId { get; set; }
        public String? Title { get; set; }
        public String? Information { get; set; }
        public int Capacity { get; set; }
        public virtual ICollection<Enrollement> Enrollements { get; set; }
        public bool? IsFull
        {
            get
            {
                if(Enrollements.Count() == Capacity)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
