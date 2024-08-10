public interface IPanelSection
{
    public delegate void Event(EventController.Callback callback);

    public EventController EventController { get; }
    public Event[] Events { get; }

    public void ChooseRandomEvent(EventController.Callback callback)
    {
        var randomEvent = Events.SelectRandomElement();
        randomEvent(callback);
    }
}
