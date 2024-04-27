using Task_Manager.Models;

namespace Task_Manager.ViewModels
{
    public class HomeViewModel
    {
        public JobInfo JobInfo { get; set; } = new();
        public List<JobInfo> JobInfos { get; }

        public HomeViewModel(List<JobInfo> jobInfos)
        {
            JobInfos = jobInfos;
        }
    }
}
