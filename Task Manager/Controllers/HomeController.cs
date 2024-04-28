using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Task_Manager.Models;
using Task_Manager.ViewModels;

namespace Task_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobInteraction _jobInteraction;

        public HomeController(IJobInteraction jobInteraction)
        {
            _jobInteraction = jobInteraction;
            _jobInteraction.JobInfos = jobInteraction.GetJobInfos();
        }

        public IActionResult Index()
        {
            return View(new HomeViewModel(_jobInteraction.JobInfos));
        }

        [HttpPost]
        public IActionResult CreateJob(JobInfo jobInfo)
        {
            if (ModelState.IsValid)
            {
                _jobInteraction.AddJob(jobInfo);
                return RedirectToAction("Index");
            }
            return View("Index", new HomeViewModel(_jobInteraction.JobInfos));
        }

        public IActionResult DeleteJob(int? id)
        {
            try
            {
                _jobInteraction.RemoveJob(id);
            }
            catch
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _jobInteraction.ClearJob();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var job = _jobInteraction.JobInfos.Find(i => i.Id == id);
            if (job == null)
                return NotFound();

            return View(job);
        }

        [HttpPost]
        public IActionResult Edit(JobInfo jobInfo)
        {
            if (ModelState.IsValid)
            {
                _jobInteraction.EditJob(jobInfo);
                return RedirectToAction("Index");
            }
            return View(jobInfo);
        }
    }
}
