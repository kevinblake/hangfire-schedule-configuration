using System;
using System.Configuration;
using System.Linq.Expressions;
using Hangfire.Common;

namespace Hangfire.ScheduleConfiguration
{
    public class TaskSection : ConfigurationSection
    {
        [ConfigurationProperty("tasks", IsRequired = true)]
        public TaskList Tasks
        {
            get { return (TaskList) this["tasks"]; }

            set { this["tasks"] = value; }
        }

        public void Initialise()
        {
            var manager = new RecurringJobManager();

            foreach (TaskEntry task in this.Tasks.Items)
            {
                var type = Type.GetType(task.ServiceType);
                if (type != null)
                {
                    var method = type.GetMethod(task.Method);
                    var job = new Job(type, method);

                    manager.AddOrUpdate(task.Name, job, task.Cron);
                }
            }
        }

        public void Enqueue()
        {
            var server = new BackgroundJobClient(JobStorage.Current);

            foreach (TaskEntry task in this.Tasks.Items)
            {
                var type = Type.GetType(task.ServiceType);
                if (type != null)
                {
                    var method = type.GetMethod(task.Method);

                    var action = Expression.Lambda<Action>(Expression.Call(Expression.New(type), method));

                    server.Enqueue(action);
                }
            }
        }
    }
}