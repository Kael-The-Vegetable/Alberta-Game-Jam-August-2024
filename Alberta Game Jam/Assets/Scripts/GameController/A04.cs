using UnityEngine;

namespace Sections
{
    public class A04 : MonoBehaviour, IPanelSection
    {
        public EventController EventController { get; set; }

        public IPanelSection.Event[] Events { get; set; }
    }
}
