using UnityEngine;

namespace MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("MRTK/Examples/Dispose")]
    internal class Dispose : MonoBehaviour
    {
        private bool hasSpawnedOrDestroyed = false;

        public void DestroySelf()
        {
            if (hasSpawnedOrDestroyed) return;

            Debug.Log("Dispose: Destroy button pressed.");
            hasSpawnedOrDestroyed = true;
            Destroy(gameObject);
        }
    }
}
