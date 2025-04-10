using TMPro;
using Unity.VisualScripting;
using UnityEngine;



enum HighScores
{
    Idle,
    Attack,
    Reset
}

public class SaveHighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score;

    public float PlayTime;

    public float PlayTimeSafer = 0;

    public int Sscore;

    private HighScores State;

    public int highScore = 0;

    public int SceneCount;

    public playButton PlayButton;

    [SerializeField] private TextMeshProUGUI WinOrLoseText;

    [SerializeField] private TextMeshProUGUI PlayTimer;

    [SerializeField] TextMeshProUGUI HighScore;

    [SerializeField] GameObject GameOverScoreHolder;
    [SerializeField] GameObject WinScoreHolder;

    [SerializeField] GameObject PlayButtonPress;
    [SerializeField] GameObject ReturnButton;
    [SerializeField] GameObject ReturnButton1;




    public int BossLiveCount = 0;
    void Start()
    {
        PlayButton = FindFirstObjectByType<playButton>();
        State = HighScores.Idle;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Sscore > highScore)
        {
            
                HighScore.text = Score.text;
                highScore = Sscore;
                
            
        }

        

        if (Sscore <= highScore)
        {
            if (State == HighScores.Idle)
            {
                HighScore.text = "" + highScore;
                
                State = HighScores.Attack;
                
            }
        }

        PlayButton.SceneCounter = SceneCount;

        
        if(PlayTimeSafer < PlayTime)
        {
            
            PlayTimeSafer = PlayTime;
            PlayTimer.text = "" + Mathf.RoundToInt(PlayTime);
        }
        

        if (BossLiveCount <= 0)
        {
            GameOverScoreHolder.SetActive(false);
            WinScoreHolder.SetActive(true);

            ReturnButton.SetActive(false);
            ReturnButton1.SetActive(true);
            
            WinOrLoseText.text = "You Win! You Defeated The Boss!";
        }
        else if (BossLiveCount > 0)
        {
            GameOverScoreHolder.SetActive(true);
            WinScoreHolder.SetActive(false);

            ReturnButton.SetActive(true);
            ReturnButton1.SetActive(false);

            WinOrLoseText.text = "Your Ship Was destroyed!";
        }
    }
}
