using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioApp.Models;

namespace PortfolioApp.Controllers.Feedback
{
    public class FakeFeedbackRepository : IFeedbackRepository
    {
        public void SendFeedback(Contact feedback)
        {
            // placeholder
        }
    }
}
