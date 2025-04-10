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

    //Phase 1 Enemies
    [SerializeField] private GameObject LightEnemy1Phase1;
    [SerializeField] private GameObject LightEnemy2Phase1;
    [SerializeField] private GameObject LightEnemy3Phase1;
    [SerializeField] private GameObject MediumEnemy1Phase1;
    [SerializeField] private GameObject MediumEnemy2Phase1;
    [SerializeField] private GameObject MediumEnemy3Phase1;

    //Phase 2 Enemies
    [SerializeField] private GameObject LightEnemy1Phase2;
    [SerializeField] private GameObject LightEnemy2Phase2;
    [SerializeField] private GameObject MediumEnemy1Phase2;
    [SerializeField] private GameObject MediumEnemy2Phase2;
    [SerializeField] private GameObject HeavyEnemy1Phase2;
    

    //Phase 3 Enemies
    
    [SerializeField] private GameObject HeavyEnemy1Phase3;
    [SerializeField] private GameObject HeavyEnemy2Phase3;
    [SerializeField] private GameObject HeavyEnemy3Phase3;


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
        BossEnemies.Add(LightEnemy1Phase1);
        BossEnemies.Add(LightEnemy2Phase1);
        BossEnemies.Add(LightEnemy3Phase1);
        BossEnemies.Add(MediumEnemy1Phase1);
        BossEnemies.Add(MediumEnemy2Phase1);
        BossEnemies.Add(MediumEnemy3Phase1);


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


        
        if (BossTimer <= 0) 
        { 
        
            StartNewBossRound();
            
        }

        
    }

    private void StartNewBossRound()
    {
        if (MainBoss.MainBossLives == 2)
        {
            if (BossTimer <= 0)
            {
                

                BossEnemies.Add(LightEnemy1Phase2);
                BossEnemies.Add(LightEnemy2Phase2);
                BossEnemies.Add(MediumEnemy1Phase2);
                BossEnemies.Add(MediumEnemy2Phase2);
                BossEnemies.Add(HeavyEnemy1Phase2);
                
                BossTimer = 1;

            }
        }

        if (MainBoss.MainBossLives == 1)
        {
            if (BossTimer <= 0)
            {


                
                BossEnemies.Add(HeavyEnemy1Phase3);
                BossEnemies.Add(HeavyEnemy2Phase3);
                BossEnemies.Add(HeavyEnemy3Phase3);
                BossTimer = 1;

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
