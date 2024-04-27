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

        public void RemoveJob(int? id)
        {
            if (id == 0 || id is null)
                throw new ArgumentException("id is wrong.");

            var job = _taskManagerDbContext.JobInfos.Find(id);

            if (job is not null)
            {
                _taskManagerDbContext.Remove(job);
                _taskManagerDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("Not found job.");
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
