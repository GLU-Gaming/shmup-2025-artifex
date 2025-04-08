using TMPro;
using UnityEngine;

public class GiveValue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score;

    public SaveHighScore HighScore;

    void Start()    
    {

        string newText = StaticData.valueToKeep;
        Score.text = newText;

        int newNumber = StaticData.NumberToKeep;
        HighScore.Sscore = newNumber;

        int NewHighScore = StaticData.HighScoreToKeep;
        HighScore.highScore = NewHighScore;

        Debug.Log(HighScore.Sscore);
        Debug.Log(HighScore.highScore);

        HighScore = FindFirstObjectByType<SaveHighScore>();
    }

}
