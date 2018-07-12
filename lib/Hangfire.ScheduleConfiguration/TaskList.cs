using System.Configuration;

namespace Hangfire.ScheduleConfiguration
{
    public class TaskList : ConfigurationElement
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public TaskCollection Items
        {
            get { return (TaskCollection) this[string.Empty]; }

            set { this[string.Empty] = value; }
        }
    }
}