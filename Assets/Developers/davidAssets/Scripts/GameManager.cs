using System.Collections.Generic;
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

    [SerializeField] public List<GameObject> BossEnemies = new List<GameObject>();

    [SerializeField] private GameObject LightEnemy;
    [SerializeField] private GameObject LightEnemy1;

    //Playership variables
    [SerializeField] public playerController player;
    [SerializeField] public Transform playerPosition;
    [SerializeField] public ParticleSystem Sparks;

    public int HighScore = 0;

    public float BossTimer = 1;
    

    public int SceneCount;

    public MainBossMechanics MainBoss;

    public GetValue getValue;

    void Start()
    {
        BossEnemies.Add(LightEnemy);

        scoreText.text = "" + score;

        Score.text = "" + score;

        LiveText.text = "" + Live;

        getValue = FindFirstObjectByType<GetValue>();
        MainBoss = FindFirstObjectByType<MainBossMechanics>();
    }
    void Update()
    {
        //Game over
        if (player.playerHealth <= 0)
        {
            PlayerDeath();
        }

        if (BossEnemies.Count <= 0)
        {
            
            if(MainBoss.MainBossLives == 2)
            {
                BossTimer = 0;
            }
           
        }

        
        if (BossTimer <= 0) 
        { 
        
            StartNewBossRound();
            BossTimer = 1;
        }

        
    }

    private void StartNewBossRound()
    {
        if (MainBoss.MainBossLives >= 2)
        {
            if (BossTimer < 0)
            {

                BossEnemies.Add(LightEnemy1);

            }
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

        scoreText.text = "" + score;

        Score.text = "" + score;
    }

    

    public void RemoveLive(int amount)
    {
        Live = Live - amount;

        LiveText.text = "" + Live;
    }


    public void RemoveBossEnemies(GameObject BossEnemiesToRemove)
    {
        

        BossEnemies.Remove(BossEnemiesToRemove);

        Destroy(BossEnemiesToRemove);
    }

}
