using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBossMechanics : MonoBehaviour
{

    public int MainBossLives = 1;

    [SerializeField] private GameObject Trident;

    [SerializeField] private GameObject TridentSpawnPoint;

    public GameManager game;

    public GetValue getValue;

    private float ReloadTime = 0;

    private float ColliderReload = 0;
    
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        getValue = FindFirstObjectByType<GetValue>();
    }

    
    void Update()
    {
        if (game.BossEnemies.Count <= 0) 
        {
            ColliderReload += Time.deltaTime;
            Debug.Log("test");
            transform.position = new Vector3(240.7f, -6.478357f, -2.974732f);

            if (ColliderReload > 1)
            {
                transform.GetComponent<BoxCollider>().enabled = true;
                ColliderReload = 0;
            }
            
        }
        else if(game.BossEnemies.Count > 0)
        {
            transform.GetComponent<BoxCollider>().enabled = false;
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
                
                Instantiate(Trident, TridentSpawnPoint.transform.position, Quaternion.Euler(45, -90, 0));
                ReloadTime = 2;
            }
        }


        if(MainBossLives <= 1)
        {
            if(ReloadTime <= 0)
            {
                transform.position = new Vector3(240.7f, -6.478357f, -2.974732f);
                Instantiate(Trident, TridentSpawnPoint.transform.position, Quaternion.Euler(45, -90, 0));
                ReloadTime = 4;
            }
        }
        if(transform.GetComponent<BoxCollider>().enabled == false)
        {
            if(game.BossEnemies.Count > 0)
            {
                if(MainBossLives >= 2)
                {
                    transform.position = new Vector3(240.7f, -6.478357f, 25.79f);
                }
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
