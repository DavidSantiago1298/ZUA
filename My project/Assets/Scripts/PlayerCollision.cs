using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.Rendering;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField]

    private UnityEvent onPlayerLose;

    [SerializeField]

    private UnityEvent<Transform> onObstacleDestroyed;

    [SerializeField]

    private UnityEvent<Transform> onCollisionDie;

    [SerializeField]

    private UnityEvent onCoinCollected;

    private Dash dash;

    private void Start()
    {
        dash = GetComponent<Dash>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (dash.IsDashing)
            {
                onObstacleDestroyed?.Invoke(transform);
               collision.gameObject.SetActive(false);
            }
            else
            {
                onCollisionDie?.Invoke(transform);
                onPlayerLose.Invoke();
                SoundManager.instance.Play("Damage");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeathZone"))
        {
            onCollisionDie?.Invoke(transform);
            onPlayerLose?.Invoke();
        }

        else if (other.CompareTag(("Coin")))
        {
            other.gameObject.SetActive(false);
            onCoinCollected?.Invoke();
        }
        
    }
}
