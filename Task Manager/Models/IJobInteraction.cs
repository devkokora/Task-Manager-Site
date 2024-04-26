namespace Task_Manager.Models
{
    public interface IJobInteraction
    {
        List<JobInfo>  JobInfos { get; set; }
        void AddJob(JobInfo job);
        void RemoveJob(JobInfo job);
        void ClearJob();
        List<JobInfo> GetJobInfos();
    }
}
