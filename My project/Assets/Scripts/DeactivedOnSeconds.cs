using UnityEngine;
using UnityEngine.Events;

public class DeactivedOnSeconds : MonoBehaviour
{
    [SerializeField]

    private float secondsToDesactivate = 5f;

    

    private void OnEnable()
    {
        Invoke("DeactivatedObject", secondsToDesactivate);
    }
        

    private void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

    

}
