using UnityEngine;
using UnityEngine.UI; // ✅ Required for Button

namespace MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("MRTK/Examples/Plant Manager")]
    internal class TotManager : MonoBehaviour
    {
        private bool hasBeenDestroyed = false;

        public void DestroySelf()
        {
            if (hasBeenDestroyed) return;

            Debug.Log("TotManager: Destroy button pressed.");
            hasBeenDestroyed = true;
            Destroy(gameObject);
        }
    }
}
