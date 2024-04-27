using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Task_Manager.Models;
using Task_Manager.ViewModels;

namespace Task_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobInteraction _jobInteraction;

        //[BindProperty]
        //public JobInfo jobInfo { get; set; }

        public HomeController(IJobInteraction jobInteraction)
        {
            _jobInteraction = jobInteraction;
        }

        public IActionResult Index()
        {
            var jobs = _jobInteraction.GetJobInfos();
            _jobInteraction.JobInfos = jobs;

            return View(new HomeViewModel(_jobInteraction));
        }

        [HttpPost]
        public IActionResult CreateJob(JobInfo jobInfo)
        {
            if (ModelState.IsValid)
            {
                _jobInteraction.AddJob(jobInfo);
            }
            return RedirectToAction("Index");
        }
    }
}
