using UnityEngine;

public class MainGiveValue : MonoBehaviour
{
    public GameManager game;
    
    void Start()
    {

        int newHighScore = StaticData.HighScoreToKeep;
        game.HighScore = newHighScore;

        int NewSceneCount = StaticData.SceneCounter;
        game.SceneCount = NewSceneCount;

        int NewsceneCount = StaticData.SceneCount;
        game.SceneCount += NewSceneCount = NewsceneCount;

        Debug.Log(game.HighScore);

        game = FindFirstObjectByType<GameManager>();
    }

    
}
