# Hangfire Schedule Configuration

Hangfire schedule configuration from app.config / web.config

Sample web.config

<configuration>
  <configSections>
    <section name="scheduledTasks" type="Hangfire.ScheduleConfiguration.TaskSection" />
    <section name="startupTasks" type="Hangfire.ScheduleConfiguration.TaskSection" />
  </configSections>
  <scheduledTasks>
    <tasks>
      <add name="My Scheduled Task 1" method="TaskMethodName" cron="15 3 * * *" type="Namespace.ClassName1, Dll.Namespace" />
      <add name="My Scheduled Task 2" method="TaskMethodName" cron="20 3 * * *" type="NameSpace.ClassName2, Dll.Namespace" />
    </tasks>
  </scheduledTasks>
  <startupTasks>
    <tasks>
      <add name="My Startup Task 1" method="TaskMethodName" type="Namespace.ClassName3, Dll.Namespace" />
    </tasks>
  </startupTasks>
</configuration>
