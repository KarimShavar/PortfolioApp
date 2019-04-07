using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioApp.Data;
using PortfolioApp.Models;

namespace PortfolioApp.Controllers.Feedback
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SendFeedback(Contact feedback)
        {
            _context.Contacts.Add(feedback);
            _context.SaveChanges();
        }
    }
}
