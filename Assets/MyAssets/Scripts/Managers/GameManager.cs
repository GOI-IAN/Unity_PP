using UnityEngine;

public class GameManager : MonoBehaviour
{

    static public GameManager instance;

    int score = 0;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }




    public void SayHello()
    {
        print("Hello world. Love gm.");
    }

    public void  AddScore(int addValue)
    {
        int oldScore = score;
        score += addValue;
        print($"Score({oldScore}) + ({addValue} = result({score})");
    }

        public void  SubtractScore(int subtractValue)
    {
        int oldScore = score;
        score -= subtractValue;
        print($"Score({oldScore}) - ({subtractValue} = result({score})");
    }
    public int GetScore()
    {
        print($"The current score is {score}");
        return score;
    }
}
