using UnityEngine;
using System.Collections.Generic;
using System.Dynamic;

public class InstantiateObject : MonoBehaviour
{
    [SerializeField]

    private GameObject _objectToInstantiate;

    [SerializeField]

    private Stack<GameObject> _objectPool = new Stack<GameObject> ();

public GameObject ObjectToInstantiate => _objectToInstantiate;

public void  InstantiateObjectAtPosition(Transform asset)
{
    GameObject obj = CreateInstance();
    obj.transform.position = asset.position;
}

    public GameObject CreateInstance()
    {
        GameObject obj;
        if (_objectPool.Count > 0)
        {
            obj = _objectPool.Pop();
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(_objectToInstantiate, transform.position, Quaternion.identity);
            obj.GetComponent<ObjectFromPool>().onDeactivate.AddListener(onObjectDeactivated);
        }
        return obj;
    }

    public void onObjectDeactivated(GameObject obj)
    {
        _objectPool.Push(obj);
    }
}
