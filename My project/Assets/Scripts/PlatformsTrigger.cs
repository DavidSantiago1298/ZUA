using UnityEngine;
using UnityEngine.Events;

public class PlatformsTrigger : MonoBehaviour
{
    [SerializeField]

    private UnityEvent onPlatformsTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Destroy(other.gameObject);
            onPlatformsTriggered?.Invoke();
        }
    }
}
