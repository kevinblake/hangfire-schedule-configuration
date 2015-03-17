using System.Configuration;

namespace Hangfire.ScheduleConfiguration
{
    public class TaskEntry : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string) base["name"]; }

            set { base["name"] = value; }
        }

        [ConfigurationProperty("type", IsKey = false, IsRequired = true)]
        public string ServiceType
        {
            get { return (string)base["type"]; }

            set { base["type"] = value; }
        }

        [ConfigurationProperty("cron", IsKey = false, IsRequired = true)]
        public string Cron
        {
            get { return (string) base["cron"]; }

            set { base["cron"] = value; }
        }

        [ConfigurationProperty("method", IsKey = false, IsRequired = true)]
        public string Method
        {
            get { return (string) base["method"]; }

            set { base["method"] = value; }
        }
    }
}