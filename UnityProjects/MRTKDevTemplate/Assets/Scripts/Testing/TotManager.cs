using UnityEngine;

namespace MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("MRTK/Examples/Plant Manager")]
    internal class TotManager : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Trash"))
            {
                Destroy(gameObject);
            }
        }
    }
}
