namespace Assignment2EF.Models
{
    public interface IWorkshopRepo
    {
        IQueryable<Workshop> GetWorkshops { get; }
        IQueryable<Enrollement> GetEnrollements { get; }
        //void GetEnrollementByEmail(string email);
        void AddEnrollement(Enrollement enrollement, int workId);
        void Save();

    }
}
