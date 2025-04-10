using TMPro;
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

    public int Sscore;

    private HighScores State;

    public int highScore = 0;

    public int SceneCount;

    public playButton PlayButton;

    [SerializeField] private TextMeshProUGUI WinOrLoseText;

    [SerializeField] TextMeshProUGUI HighScore;

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


        if (BossLiveCount <= 0)
        {
            WinOrLoseText.text = "You Win! You Defeated The Boss!";
        }
        else if (BossLiveCount >= 0)
        {
            WinOrLoseText.text = "Your Ship Was destroyed!";
        }
    }
}
