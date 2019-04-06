using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PortfolioApp.Pages
{
    public class BlogModel : PageModel
    {
        public string BackgroundImage = @"assets/boxed-water-is-better-1464044-unsplash.jpg";

        public void OnGet()
        {

        }
    }
}