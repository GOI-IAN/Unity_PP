using UnityEngine;

public class SpawnGameManager : MonoBehaviour
{

    [SerializeField] GameObject gameManagerPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
        if (!CheckIfManagerExists()) Instantiate(gameManagerPrefab);
    }

bool CheckIfManagerExists()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("GameManager");
        if (go.Length == 0) return false;
        else return true;
    }
    
}
