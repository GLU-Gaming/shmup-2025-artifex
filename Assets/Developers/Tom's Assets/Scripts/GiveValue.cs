using TMPro;
using UnityEngine;

public class GiveValue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI myText;

    public SaveHighScore HighScore;

    void Start()    
    {
        
        string newText = StaticData.valueToKeep;
        myText.text = newText;

        int newNumber = StaticData.NumberToKeep;
        HighScore.Sscore = newNumber;

        int NewHighScore = StaticData.HighScoreToKeep;
        HighScore.highScore = NewHighScore;

        Debug.Log(HighScore.Sscore);
        Debug.Log(HighScore.highScore);

        HighScore = FindFirstObjectByType<SaveHighScore>();
    }

}
