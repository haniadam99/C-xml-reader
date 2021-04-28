namespace Podcast.BusinessLayer
{
    public abstract class ScheduleServiceBase
    {
        public abstract void Start();
        public virtual void Stop(){}
    }
}
