using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    [SerializeField]

    private GameObject _objectToInstantiate;

    public void InstantiateObjectAtPosition(Transform asset)
    {
        Instantiate (_objectToInstantiate, asset.position, Quaternion.identity);
    }
}
