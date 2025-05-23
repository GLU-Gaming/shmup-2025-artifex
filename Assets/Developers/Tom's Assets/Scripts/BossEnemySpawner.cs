using UnityEngine;

public class BossEnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject Camera;
    
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

    public GameManager game;
    public MainBossMechanics MainBoss;
    public AutoScroll autoscroll;

    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        MainBoss = FindFirstObjectByType<MainBossMechanics>();
        autoscroll = FindFirstObjectByType<AutoScroll>();
    }


    void Update()
    {
       if(game.BossTimer <= 0)
        {
            if(game.BossEnemies.Count >= 0)
            {
                if(MainBoss.MainBossLives == 2)
                {
                    LightEnemy1Phase2.gameObject.SetActive(true);
                    LightEnemy2Phase2.gameObject.SetActive(true);
                    MediumEnemy1Phase2.gameObject.SetActive(true);
                    MediumEnemy2Phase2.gameObject.SetActive(true);
                    HeavyEnemy1Phase2.gameObject.SetActive(true);
                    
                }
            }
        }

        if (game.BossTimer <= 0)
        {
            if (game.BossEnemies.Count >= 0)
            {

                if(MainBoss.MainBossLives == 1)
                {
                    HeavyEnemy1Phase3.gameObject.SetActive(true);
                    HeavyEnemy2Phase3.gameObject.SetActive(true);
                    HeavyEnemy3Phase3.gameObject.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Destroy(autoscroll.rb) ;

        LightEnemy1Phase1.gameObject.SetActive(true);
        LightEnemy2Phase1.gameObject.SetActive(true);
        LightEnemy3Phase1.gameObject.SetActive(true);
        MediumEnemy1Phase1.gameObject.SetActive(true);
        MediumEnemy2Phase1.gameObject.SetActive(true);
        MediumEnemy3Phase1.gameObject.SetActive(true);

    }
}
