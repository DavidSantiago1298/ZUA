using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField]

    private UnityEvent onPlayerLose;

    [SerializeField]

    private UnityEvent<Transform> onObstacleDestroyed;

    [SerializeField]

    private UnityEvent<Transform> onCollisionDie;

    private Dash dash;

    private Collider col; // Para almacenar el Collider

    


    private void Start()
    {
        dash = GetComponent<Dash>();
        col = GetComponent<Collider>(); // Obtiene el Collider
        if (col != null)
        {
            col.enabled = false; // Desactiva el Collider
            StartCoroutine(EnableColliderAfterDelay(1f)); // Activa después de 2 segundos
        }

        IEnumerator EnableColliderAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay); // Espera el tiempo especificado
            col.enabled = true; // Reactiva el Collider
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (dash.IsDashing)
            {
                onObstacleDestroyed?.Invoke(transform);
                Destroy(collision.gameObject);
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
        
    }
}
