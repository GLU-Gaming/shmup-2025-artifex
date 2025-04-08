using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    

    public int score;

    public int Live = 3;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] public TextMeshProUGUI Score;

    [SerializeField] private TextMeshProUGUI LiveText;

    //Playership variables
    [SerializeField] public playerController player;
    [SerializeField] public Transform playerPosition;
    [SerializeField] public ParticleSystem Sparks;

    public int HighScore = 0;


    public GetValue getValue;

    void Start()
    {
        
        scoreText.text = "Score: " + score;

        Score.text = "" + score;

        LiveText.text = "Lives: " + Live;

        getValue = FindFirstObjectByType<GetValue>();
    }
    void Update()
    {
        //Game over
        if (player.playerHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        //Explosion
        Debug.Log("Death");
        getValue.LoadSceneAndKeepValue();
        SceneManager.LoadScene("endScene");
        
    }

    public void AddScore(int amount)
    {
        score = score + amount;

        scoreText.text = "Score: " + score;

        Score.text = "" + score;
    }

    

    public void RemoveLive(int amount)
    {
        Live = Live - amount;

        LiveText.text = "Lives: " + Live;
    }

    
}
