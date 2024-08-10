using UnityEngine;

public abstract class Section : MonoBehaviour, IPanelSection
{
    public EventController EventController => throw new System.NotImplementedException();

    public IPanelSection.Event[] Events => throw new System.NotImplementedException();
}