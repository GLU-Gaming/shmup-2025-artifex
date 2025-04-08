using UnityEngine;

public class GetValueEnd : MonoBehaviour
{
    public SaveHighScore saveHighScore;
    public returnButton ReturnButton;

    public void LoadSceneAndKeepValue()
    {
        int HighScore = saveHighScore.highScore;
        StaticData.HighScoreToKeep = HighScore;

        int SceneCount = ReturnButton.SceneCount;
        StaticData.SceneCounter = SceneCount;

    }

    void Start()
    {
        saveHighScore = FindFirstObjectByType<SaveHighScore>();
        ReturnButton = FindFirstObjectByType<returnButton>();
    }

}
