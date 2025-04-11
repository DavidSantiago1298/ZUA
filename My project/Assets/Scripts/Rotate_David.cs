using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] 

    private Vector3 rotationAxis = new Vector3(0, 1, 0); // Eje de rotación
    [SerializeField] 

    private float rotationSpeed = 100f; // Velocidad editable desde el Inspector

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}