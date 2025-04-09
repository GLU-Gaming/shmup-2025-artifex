using UnityEngine;

public class BossEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject LightEnemy;
    [SerializeField] private GameObject LightEnemy2;
    [SerializeField] private GameObject HeavyEnemy;

    public GameManager game;

    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
    }


    void Update()
    {
       if(game.BossLives == 2)
        {
            LightEnemy2.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        LightEnemy.gameObject.SetActive(true);
        
    }
}
