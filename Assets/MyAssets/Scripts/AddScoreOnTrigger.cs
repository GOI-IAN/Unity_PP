using UnityEngine;

public class AddScoreOnTrigger : MonoBehaviour
{
    [SerializeField] int scoreToAdd = 10;
    
    // als "Player" het object aanraakt dan add score.
    void OnTriggerEnter(Collider col)
    {
       if (col.CompareTag("Player")) GameManager.instance.AddScore(scoreToAdd);
    }
}