using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioApp.Controllers.Feedback;
using PortfolioApp.Data.Migrations;
using PortfolioApp.Models;

namespace PortfolioApp.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public ContactModel(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _feedbackRepository.SendFeedback(Contact);
            return RedirectToPage("Index");
        }
    }
}