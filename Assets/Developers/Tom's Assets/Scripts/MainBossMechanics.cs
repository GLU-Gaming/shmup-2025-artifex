using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBossMechanics : MonoBehaviour
{

    public int MainBossLives = 3;

    [SerializeField] private GameObject Trident;

    [SerializeField] private GameObject TridentSpawnPoint;

    public GameManager game;

    public GetValue getValue;

    private float ReloadTime = 0;
    
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        getValue = FindFirstObjectByType<GetValue>();
    }

    
    void Update()
    {
        if (game.BossEnemies.Count <= 0) 
        {
            transform.GetComponent<BoxCollider>().enabled = true;
        }

        if(MainBossLives <= 0)
        {
            game.SceneCount = 0;
            getValue.LoadSceneAndKeepValue();
            SceneManager.LoadScene("startScene");
        }

        if (transform.GetComponent<BoxCollider>().enabled == true) 
        {
            if(ReloadTime <= 0)
            {
                Instantiate(Trident, TridentSpawnPoint.transform.position, Quaternion.identity);
                ReloadTime = 1;
            }
        }
        if(MainBossLives <= 1)
        {
            if(ReloadTime <= 0)
            {
                Instantiate(Trident, TridentSpawnPoint.transform.position, Quaternion.identity);
                ReloadTime = 1;
            }
        }

        if(ReloadTime > 0)
        {
            ReloadTime -= Time.deltaTime;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            MainBossLives -= 1;
            game.BossTimer = 0;
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
