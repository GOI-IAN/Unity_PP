using UnityEngine;

public class CubeLife : MonoBehaviour
{
    [SerializeField] float maxDelay = 4f;
    void Update()
    {
     Invoke("DestroyMyself", Random.Range(0.1f, maxDelay)); 
    }

    void DestroyMyself()
    {
        BasicPuller.instance.Destroy(gameObject);
    }

    
}
