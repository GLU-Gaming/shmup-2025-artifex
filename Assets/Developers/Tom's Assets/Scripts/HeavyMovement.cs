using UnityEngine;

public class HeavyMovement : MonoBehaviour
{
    private Transform Currenttarget;

    private LightEnemyMech[] LightEnemies;

    private ForceField forceField;

    bool HeavyDownOrUp = true;

    public float RegenerateTime = 10;

    private int HeavyLives = 10;

    [SerializeField] private float HeavyspeedIncreaseY;

    private HeavyBulletSpawn heavyBulletSpawn;

    private Transform HeavyBulletspawn;

    private float HeavyspeedY;

    [SerializeField] GameObject HeavyBullet;

    private float HeavyBulletReload = 0;

    [SerializeField] int scoreAmount = 100;

    public GameManager game;

    public MainBossMechanics MainBoss;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        forceField = GetComponentInChildren<ForceField>();

        game = FindFirstObjectByType<GameManager>();

        MainBoss = FindFirstObjectByType<MainBossMechanics>();
    }

    // Update is called once per frame
    void Update()
    {


        if (forceField.ForceFieldLives < 0)
        {
            HeavyBulletReload += Time.deltaTime;
            if(HeavyBulletReload >= 1.5f)
            {
                Instantiate(HeavyBullet, gameObject.transform.position, Quaternion.identity);
                HeavyBulletReload = 0;
            }
            RegenerateTime -= Time.deltaTime;

            if (RegenerateTime <= 0)
            {
                forceField.gameObject.SetActive(true);
                forceField.ForceFieldLives = 30;
                RegenerateTime = 10;
            }
        }

#pragma warning disable CS0618 // Type or member is obsolete
        LightEnemies = FindObjectsOfType<LightEnemyMech>();
#pragma warning restore CS0618 // Type or member is obsolete

        int LowestLifes = 3;

        for (int i = 0; i < LightEnemies.Length; i++)
        {

            if (LightEnemies[i].LightEnemyLives < LowestLifes)
            {
                LowestLifes = LightEnemies[i].LightEnemyLives;

                Currenttarget = LightEnemies[i].transform;
            }
        }

        //Als CurrentTarget niet bestaat
        //Zet CurrentTarget op een random Enemy uit de array
        if (LightEnemies.Length > 0)
        {
            if (Currenttarget == null)
            {
                Currenttarget = LightEnemies[Random.Range(0, LightEnemies.Length)].transform;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, Currenttarget.transform.position.y, Time.deltaTime * 1), transform.position.z);
            }
        }
        else if (LightEnemies.Length <= 0) {
            
                

                if (transform.position.y >= 10)
                {

                    HeavyDownOrUp = false;


                }
                else if (transform.position.y <= -10)
                {

                    HeavyDownOrUp = true;


                }
                if (HeavyDownOrUp == false)
                {

                    HeavyspeedIncreaseY = -0.30f;


                }

                if (HeavyDownOrUp == true)
                {

                    HeavyspeedIncreaseY = 0.30f;


                }

                HeavyspeedY = HeavyspeedIncreaseY;

                transform.position += new Vector3(0, HeavyspeedY * Time.deltaTime * 10f, 0);

                
            
        }

        if (HeavyLives <= 0)
        {
            Destroy(gameObject);
            game.AddScore(scoreAmount);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        HeavyLives -= 1;
        if (MainBoss.MainBossLives <= 3)
        {
            if (HeavyLives <= 0)
            {
                Debug.Log("Test");
                game.AddScore(scoreAmount);
                game.RemoveBossEnemies(gameObject);
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {

       if (other.gameObject.tag == "EnemyWrapper")
        {
            Destroy(gameObject);
        }
    }
}
