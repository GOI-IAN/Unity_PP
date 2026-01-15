using UnityEngine;

public class Talk : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.SayHello();
    }
}
