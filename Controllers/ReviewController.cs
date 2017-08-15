using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using restauranter.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace restauranter.Controllers
{
    public class ReviewController : Controller
    {
        private RestaurantContext _context;

        public ReviewController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("AddReview")]
        public IActionResult AddReview(Review thisReview)
        {
            if (ModelState.IsValid)
            {
                Review newReview = new Review
                {
                    Reviewer = thisReview.Reviewer,
                    Restaurant = thisReview.Restaurant,
                    VisitedAt = thisReview.VisitedAt,
                    ReviewText = thisReview.ReviewText,
                    Stars = thisReview.Stars,
                    Helpful = 0,
                    Unhelpful = 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                _context.Reviews.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            else
            {
                return View("Index", thisReview);
            }
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews()
        {
            ViewBag.Reviews = _context.Reviews
            .OrderByDescending(review => review.CreatedAt)
            .ToList();
            return View();
        }

        [HttpGet]
        [Route("Helpful/{ReviewId}")]
        public IActionResult Helpful(int ReviewId)
        {
            Review HelpfulReview = _context.Reviews.SingleOrDefault(review => review.ReviewId == ReviewId);
            HelpfulReview.Helpful = HelpfulReview.Helpful + 1;
            _context.SaveChanges();
            return RedirectToAction("Reviews");
        }

        [HttpGet]
        [Route("Unhelpful/{ReviewId}")]
        public IActionResult Unhelpful(int ReviewId)
        {
            Review UnhelpfulReview = _context.Reviews.SingleOrDefault(review => review.ReviewId == ReviewId);
            UnhelpfulReview.Unhelpful = UnhelpfulReview.Unhelpful + 1;
            _context.SaveChanges();
            return RedirectToAction("Reviews");
        }
    }
}
