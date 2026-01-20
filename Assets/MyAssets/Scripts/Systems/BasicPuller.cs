using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class BasicPuller : MonoBehaviour
{
static public BasicPuller instance;
[SerializeField] GameObject prefabFallback;
[SerializeField] List <GameObject> activeList;
[SerializeField] List <GameObject> inActiveList;

    void Awake()
    { 
        activeList = new List<GameObject> ();
        inActiveList = new List<GameObject> ();



        if(instance == null) instance = this;
        else Destroy(gameObject);
    }

// interfaces with our pooling system.
    void MoveToActiveList(GameObject obj)
    {
        print("start move to active");
        if(inActiveList.Contains(obj))
        {
            activeList.Remove(obj);
        }
            inActiveList.Add(obj);
            obj.SetActive(true);
    }
#region // handles pooling lists.
// interfaces with our pooling system.
    void MoveToInactiveList(GameObject obj)
    {
        if (activeList.Contains(obj))
        {
            activeList.Remove(obj);
        }
            inActiveList.Add(obj);
            obj.SetActive(false);
    }

        GameObject GetAvailableObject(GameObject obj)
    {
        if(inActiveList.Count > 0 && inActiveList != null)
        {
            return inActiveList[0];
        }
        else
        {
            GameObject tempObj = GameObject.Instantiate(obj);
            tempObj.transform.SetParent(transform);
            return tempObj;
        }
    }
    #endregion
    #region
// First looks for an avaiable object in the inactivelist, if non exists, instantiate new and move to active.
    public GameObject Instantiate(GameObject obj)
    {
        GameObject objCache = null;
        if(obj == null)
        {
            objCache = GetAvailableObject(prefabFallback);
        }
        else
        {
            objCache = GetAvailableObject(obj);
        }
            MoveToActiveList(objCache);
            return objCache;
    }

        public GameObject Instantiate(GameObject obj, Transform parent)
    {
        GameObject objCache = null;
        if(obj == null)
        {
            objCache = GetAvailableObject(prefabFallback);
        }
        else
        {
            objCache = GetAvailableObject(obj);
        }
            objCache.transform.SetParent(parent);
            MoveToActiveList(objCache);
            return objCache;
    }

        public GameObject Instantiate(GameObject obj, Vector3 position)
    {
        GameObject objCache = null;
        if(obj == null)
        {
            objCache = GetAvailableObject(prefabFallback);
        }
        else
        {
            objCache = GetAvailableObject(obj);
        }
            objCache.transform.position = position;
            MoveToActiveList(objCache);
            return objCache;
    }

        public GameObject Instantiate(GameObject obj, Vector3 position, Quaternion rotation)
    {
        GameObject objCache = null;
        if(obj == null)
        {
            objCache = GetAvailableObject(prefabFallback);
        }
        else
        {
            objCache = GetAvailableObject(obj);
        }
            objCache.transform.position = position;
            objCache.transform.rotation = rotation;
            MoveToActiveList(objCache);
            return objCache;
    }

        public GameObject Instantiate(GameObject obj, Transform parent, Vector3 position, Quaternion rotation)
    {
        GameObject objCache = null;
        if(obj == null)
        {
            objCache = GetAvailableObject(prefabFallback);
        }
        else
        {
            objCache = GetAvailableObject(obj);
        }
            objCache.transform.position = position;
            objCache.transform.rotation = rotation;
            objCache.transform.SetParent(parent);
            MoveToActiveList(objCache);
            return objCache;
    }
#endregion
// Moves object to inactive list.
    public void Destroy(GameObject obj)
    {
        MoveToInactiveList(obj);
    }

    // Checks if a new instantiation is needed, if not get first object in inActiveList.

}
