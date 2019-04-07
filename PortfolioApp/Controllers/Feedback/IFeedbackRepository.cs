using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioApp.Models;

namespace PortfolioApp.Controllers.Feedback
{
    public interface IFeedbackRepository
    {
        void SendFeedback(Contact feedback);
    }
}
