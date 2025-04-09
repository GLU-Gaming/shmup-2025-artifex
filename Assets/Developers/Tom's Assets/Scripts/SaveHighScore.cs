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

    [SerializeField] TextMeshProUGUI HighScore;
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
    }
}
