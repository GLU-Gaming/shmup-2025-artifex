using TMPro;
using UnityEngine;

public class SaveHighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score;

    public int Sscore;

    public int highScore = 0;

    [SerializeField] TextMeshProUGUI HighScore;
    void Start()
    {
       

        if(Sscore >= highScore)
        {
            highScore = Sscore;
            HighScore.text = Score.text;

        }

        if(Sscore < highScore)
        {
            HighScore.text = "" + highScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
