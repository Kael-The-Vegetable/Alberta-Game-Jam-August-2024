using UnityEngine;

namespace Sections
{
    public class A05 : MonoBehaviour, IPanelSection
    {
        public EventController EventController { get; set; }

        public IPanelSection.Event[] Events { get; set; }
    }
}
