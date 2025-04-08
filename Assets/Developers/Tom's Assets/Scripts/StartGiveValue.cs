using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class StartGiveValue : MonoBehaviour
{
    public playButton PlayButton;
    
    void Start()
    {

        int NewHighScore = StaticData.HighScoreToKeep;
        PlayButton.HighScore = NewHighScore;

        int NewSceneCount = StaticData.SceneCounter;
        PlayButton.SceneCounter = NewSceneCount;


        PlayButton = FindFirstObjectByType<playButton>();
        
    }

    
    void Update()
    {
        
    }
}
