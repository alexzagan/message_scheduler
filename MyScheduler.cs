using System;
public static class MyScheduler
{
    public static void IntervalInMinutes(int hour, int min, double interval, Action task)
    {
        interval = interval / 60;
        SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
    }

}