using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetValue : MonoBehaviour
{
    public GameManager game;

    [SerializeField] TextMeshProUGUI myText;

    public MainBossMechanics MainBoss;
    public void LoadSceneAndKeepValue()
    {
        
        string dataToKeep = myText.text;
        int score = game.score;
        int HighScore = game.HighScore;
        int SceneCount = game.SceneCount;
        int SceneCounter = game.SceneCount;
        int BossLiveCount = MainBoss.MainBossLives;
        float gameTime = game.Timer;

        StaticData.valueToKeep = dataToKeep;
        StaticData.HighScoreToKeep = HighScore;
        StaticData.NumberToKeep = score;
        StaticData.SceneCount = SceneCount;
        StaticData.SceneCounter = SceneCounter;
        StaticData.BossLives = BossLiveCount;
        StaticData.GameTime = gameTime;


    }

    private void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        MainBoss = FindFirstObjectByType<MainBossMechanics>();
    }
}
