using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetValue : MonoBehaviour
{
    public GameManager game;

    [SerializeField] TextMeshProUGUI myText;

    public void LoadSceneAndKeepValue()
    {
        
        string dataToKeep = myText.text;
        int score = game.score;
        int HighScore = game.HighScore;
        int SceneCount = game.SceneCount;

        StaticData.valueToKeep = dataToKeep;
        StaticData.HighScoreToKeep = HighScore;
        StaticData.NumberToKeep = score;
        StaticData.SceneCount = SceneCount;
        
    }

    private void Start()
    {
        game = FindFirstObjectByType<GameManager>();
    }
}
