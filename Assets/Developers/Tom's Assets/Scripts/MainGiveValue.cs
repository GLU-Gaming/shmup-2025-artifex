using UnityEngine;

public class MainGiveValue : MonoBehaviour
{
    public GameManager game;
    
    void Start()
    {

        int newHighScore = StaticData.HighScoreToKeep;
        game.HighScore = newHighScore;

        Debug.Log(game.HighScore);

        game = FindFirstObjectByType<GameManager>();
    }

    
}
