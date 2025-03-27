using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    [SerializeField]

    private float shakeDuration = 0.5f;

    [SerializeField]

    private float shakeMagnitudex = 0.1f;

    [SerializeField]

    private float shakeMagnitudey = 0.1f;



    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
        
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitudex;
            float y = Random.Range(-1f, 1f) * shakeMagnitudey;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null;


        }

        transform.localPosition = originalPosition;
    }
}
