using UnityEngine;

namespace Sections
{
    // There is no A01
    public class A02 : MonoBehaviour, IPanelSection
    {
        public EventController EventController { get; set; }

        public IPanelSection.Event[] Events { get; set; }
    }
}
