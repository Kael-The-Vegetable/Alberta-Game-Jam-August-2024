public interface IGameEvent
{
    public GameEventTrigger Trigger { get; }

    public void OnEventStart();
    public void OnEventUpdate();
    public void OnEventEnd();
}