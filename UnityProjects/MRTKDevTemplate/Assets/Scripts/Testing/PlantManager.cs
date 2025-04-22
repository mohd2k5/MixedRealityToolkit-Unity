using UnityEngine;
using TMPro; // ✅ For TextMeshPro

namespace MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("MRTK/Examples/Plant Manager")]
    internal class PlantManager : MonoBehaviour
    {
        [SerializeField, Tooltip("Prefab to spawn when colliding with a 'Water' tag.")]
        private GameObject objectToSpawn;

        [SerializeField, Tooltip("Delay before plant can be watered (in seconds).")]
        private float wateringDelay = 15f;

        [SerializeField, Tooltip("Text element to show the countdown.")]
        private TextMeshProUGUI countdownText;

        [SerializeField, Tooltip("Object to destroy when the plant is watered.")]
        private GameObject objectToDestroy;  // Reference to another object to destroy

        private bool hasSpawnedOrDestroyed = false;
        private float timer = 0f;
        private bool isReadyToWater => timer >= wateringDelay;

        private void Update()
        {
            if (!isReadyToWater)
            {
                timer += Time.deltaTime;

                float remainingTime = Mathf.Clamp(wateringDelay - timer, 0, wateringDelay);
                if (countdownText != null)
                {
                    countdownText.text = $"Ready in: {remainingTime:F1}s";
                }
            }
            else if (countdownText != null && countdownText.gameObject.activeSelf)
            {
                countdownText.text = "Ready!";
                Invoke(nameof(HideCountdown), 1f);
            }
        }

        private void HideCountdown()
        {
            if (countdownText != null)
            {
                countdownText.gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (hasSpawnedOrDestroyed)
                return;

            if (!collision.gameObject.CompareTag("Water"))
                return;

            if (!isReadyToWater)
            {
                Debug.Log("PlantManager: Tried watering too early.");
                return;
            }

            Debug.Log("PlantManager: Collided with Water.");

            // Spawn the prefab if assigned
            if (objectToSpawn != null)
            {
                Instantiate(objectToSpawn, transform.position, transform.rotation, null);
                Debug.Log("PlantManager: Spawned new object.");
            }
            else
            {
                Debug.LogWarning("PlantManager: objectToSpawn is not assigned.");
            }

            // Destroy another object, if assigned
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
                Debug.Log("PlantManager: Destroyed the specified object.");
            }
            else
            {
                Debug.LogWarning("PlantManager: objectToDestroy is not assigned.");
            }

            hasSpawnedOrDestroyed = true;
            Destroy(gameObject); // Optionally, you can still destroy the PlantManager itself
        }
    }
}
