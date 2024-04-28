namespace Task_Manager.Models
{
    public interface IJobInteraction
    {
        List<JobInfo>?  JobInfos { get; set; }
        string? SessionId { get; set; }
        void AddJob(JobInfo job);
        void EditJob(JobInfo job);
        void RemoveJob(int? id);
        void ClearJob();
        List<JobInfo> GetJobInfos();
    }
}
