using UnityEngine;

public class GetValueStart : MonoBehaviour
{
    public playButton PlayButton;


    public void LoadSceneAndKeepValue()
    {
        int HighScore = PlayButton.HighScore;
        StaticData.HighScoreToKeep = HighScore;

        int SceneCount = PlayButton.SceneCounter;
        StaticData.SceneCounter = SceneCount;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        PlayButton = FindFirstObjectByType<playButton>();

    }

}
