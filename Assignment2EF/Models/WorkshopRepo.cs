using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Assignment2EF.Models
{
    public class WorkshopRepo : IWorkshopRepo
    {
        private WA_Context _context;
        public WorkshopRepo(WA_Context context)
        {
            _context = context;
        }
        //public IQueryable<Workshop> GetWorkshops => _context.Workshops;
        
        public IQueryable<Workshop> GetWorkshops =>
            _context.Workshops
            .Include(w => w.Enrollements);

        public IQueryable<Enrollement> GetEnrollements =>
            _context.Enrollements
            .Include(e => e.Workshops);

        /*
        public void GetEnrollementByEmail(string email)
        {
            _context.Enrollements.Include(w => w.Workshops).Where(e => e.Email == email);
        }*/

        public void AddEnrollement(Enrollement enrollement, int workId)
        {
            
            var workshops = _context.Workshops.Include(e=>e.Enrollements).Single(w=>w.WorkshopId == workId);
            var enrollements = _context.Enrollements;

            workshops.Enrollements.Add(enrollement);

            if(workshops.Enrollements == null)
            {
                workshops.Enrollements = new List<Enrollement>();
            }
            

        }
        
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
