using System.Configuration;

namespace Hangfire.ScheduleConfiguration
{
    public class TaskCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TaskEntry();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TaskEntry) element).Name;
        }
    }
}