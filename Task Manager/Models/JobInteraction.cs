using Microsoft.EntityFrameworkCore;

namespace Task_Manager.Models
{
    public class JobInteraction : IJobInteraction
    {
        private readonly TaskManagerDbContext _taskManagerDbContext;
        public List<JobInfo>? JobInfos { get; set; }
        public string? SessionId { get; set; }

        public JobInteraction(TaskManagerDbContext taskManagerDbContext)
        {
            _taskManagerDbContext = taskManagerDbContext;
        }

        public static JobInteraction GetSession(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            TaskManagerDbContext context = services.GetService<TaskManagerDbContext>() ?? throw new Exception("Error initalizing");
            string sessionId = session?.GetString("SessionId") ?? Guid.NewGuid().ToString();
            session?.SetString("SessionId", sessionId);
            return new JobInteraction(context) { SessionId = sessionId };
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
            return JobInfos ?? _taskManagerDbContext.JobInfos
                .Where(j => j.SessionId == SessionId)
                .ToList();
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

        public void EditJob(JobInfo jobInfo)
        {
            JobInfo? job = default;

            if (JobInfos is not null)
                job = JobInfos.FirstOrDefault(j => j.Id == jobInfo.Id);
            if (job is not null)
            {
                jobInfo.SessionId = SessionId;
                _taskManagerDbContext.Entry(job).State = EntityState.Detached;
                _taskManagerDbContext.Update(jobInfo);
                _taskManagerDbContext.SaveChanges();
            }
        }
    }
}
