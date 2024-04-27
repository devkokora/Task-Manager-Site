using Task_Manager.Models;

namespace Task_Manager.ViewModels
{
    public class HomeViewModel
    {
        public JobInfo JobInfo { get; set; } = new();
        public IJobInteraction JobInteraction { get; }

        public HomeViewModel(IJobInteraction jobInteraction)
        {
            JobInteraction = jobInteraction;
        }
    }
}
