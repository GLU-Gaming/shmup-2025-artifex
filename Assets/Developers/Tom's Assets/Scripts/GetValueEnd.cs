using Unity.VisualScripting;
using UnityEngine;

public class GetValueEnd : MonoBehaviour
{
    public SaveHighScore saveHighScore;
    public returnButton ReturnButton;
    public playButton PlayButton;

    public void LoadSceneAndKeepValue()
    {
        int HighScore = saveHighScore.highScore;
        StaticData.HighScoreToKeep = HighScore;

        int SceneCount = ReturnButton.SceneCount;
        StaticData.SceneCounter = SceneCount;

        int SceneCounter = saveHighScore.SceneCount;
        StaticData.SceneCount = SceneCounter;

    }

    void Start()
    {
        saveHighScore = FindFirstObjectByType<SaveHighScore>();
        PlayButton = FindFirstObjectByType<playButton>();
        ReturnButton = FindFirstObjectByType<returnButton>();
    }

}
