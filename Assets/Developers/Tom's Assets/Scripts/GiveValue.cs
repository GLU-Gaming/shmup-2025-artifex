using TMPro;
using UnityEngine;

public class GiveValue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score;

    public SaveHighScore HighScore;

    public playButton PlayButton;

    void Start()    
    {

        string newText = StaticData.valueToKeep;
        Score.text = newText;

        int newNumber = StaticData.NumberToKeep;
        HighScore.Sscore = newNumber;

        int NewHighScore = StaticData.HighScoreToKeep;
        HighScore.highScore = NewHighScore;

        int NewSceneCounter = StaticData.SceneCount;
        HighScore.SceneCount = NewSceneCounter;

        int newBossLiveCount = StaticData.BossLives;
        HighScore.BossLiveCount = newBossLiveCount;

        

        HighScore = FindFirstObjectByType<SaveHighScore>();

        PlayButton = FindFirstObjectByType<playButton>();
    }

}
