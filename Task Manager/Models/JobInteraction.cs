namespace Task_Manager.Models
{
    public class JobInteraction : IJobInteraction
    {
        private readonly TaskManagerDbContext _taskManagerDbContext;
        public List<JobInfo> JobInfos { get; set; }

        public JobInteraction(TaskManagerDbContext taskManagerDbContext)
        {
            _taskManagerDbContext = taskManagerDbContext;
        }

        public void AddJob(JobInfo job)
        {
            if (job is not null)
            {
                _taskManagerDbContext.Add(job);
                _taskManagerDbContext.SaveChanges();
            }
        }

        public List<JobInfo> GetJobInfos()
        {
            return JobInfos ?? _taskManagerDbContext.JobInfos.ToList();
        }

        public void RemoveJob(JobInfo job)
        {
            if (job is null)
                throw new ArgumentNullException(nameof(job));
            
            var jobInfos = _taskManagerDbContext.JobInfos.Find(job.Id);

            if (jobInfos is not null)
            {
                _taskManagerDbContext.Remove(job);
                _taskManagerDbContext.SaveChanges();
            }
        }

        public void ClearJob()
        {
            if (JobInfos.Count != 0)
            {
                _taskManagerDbContext.RemoveRange(JobInfos);
                _taskManagerDbContext.SaveChanges();
            }
        }
    }
}
