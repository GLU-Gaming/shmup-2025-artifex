using UnityEngine;

public class MainBossMechanics : MonoBehaviour
{

    public int MainBossLives = 3;

    public GameManager game;
    
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
    }

    
    void Update()
    {
        if (game.BossEnemies.Count <= 0) 
        {
            transform.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            MainBossLives -= 1;
            game.BossTimer = 0;
        }
    }
}
