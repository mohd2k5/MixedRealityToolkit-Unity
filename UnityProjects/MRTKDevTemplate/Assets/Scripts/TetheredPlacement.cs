using UnityEngine;

namespace MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("MRTK/Examples/Tethered Placement")]
    internal class TetheredPlacement : MonoBehaviour
    {
        [SerializeField, Tooltip("The prefab to spawn when respawning.")]
        private GameObject objectPrefab;

        [SerializeField, Tooltip("The distance from the GameObject's spawn position that will trigger a respawn.")]
        private float distanceThreshold = 20.0f;

        private Vector3 localRespawnPosition;
        private Quaternion localRespawnRotation;
        private float distanceThresholdSquared;

        private void Start()
        {
            localRespawnPosition = transform.localPosition;
            localRespawnRotation = transform.localRotation;
            distanceThresholdSquared = distanceThreshold * distanceThreshold;
        }

        private void LateUpdate()
        {
            float distanceSqr = (localRespawnPosition - transform.localPosition).sqrMagnitude;

            if (distanceSqr > distanceThresholdSquared)
            {
                Debug.Log("TetheredPlacement: Distance exceeded, respawning.");
                RespawnNewObject();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("TetheredPlacement: Collision with " + collision.gameObject.name);

            if (collision.gameObject.CompareTag("Pot"))
            {
                Debug.Log("TetheredPlacement: Collided with Pot.");

                RespawnNewObject();
            }
        }

        private void RespawnNewObject()
        {
            if (objectPrefab != null)
            {
                Transform parent = transform.parent;
                GameObject newObj = Instantiate(objectPrefab, parent);
                newObj.transform.localPosition = localRespawnPosition;
                newObj.transform.localRotation = localRespawnRotation;
                Debug.Log("TetheredPlacement: Spawned new object.");
            }
            else
            {
                Debug.LogWarning("TetheredPlacement: objectPrefab not assigned!");
            }

            Destroy(gameObject);
        }
    }
}
