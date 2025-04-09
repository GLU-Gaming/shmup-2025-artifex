using UnityEngine;

public class BossEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject LightEnemy;
    [SerializeField] private GameObject LightEnemy2;
    [SerializeField] private GameObject HeavyEnemy;

    public GameManager game;
    public MainBossMechanics MainBoss;

    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        MainBoss = FindFirstObjectByType<MainBossMechanics>();
    }


    void Update()
    {
       if(MainBoss.MainBossLives == 2)
        {
            LightEnemy2.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        LightEnemy.gameObject.SetActive(true);
        
    }
}
