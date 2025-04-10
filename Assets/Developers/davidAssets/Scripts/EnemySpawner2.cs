using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    [SerializeField] GameObject LightEnemy;
    [SerializeField] GameObject MediumEnemy;
    [SerializeField] GameObject HeavyEnemy;
    private Collider enemySpawner;

    [SerializeField] GameObject Squid1;
    [SerializeField] GameObject Squid2;
    [SerializeField] GameObject Squid3;
    [SerializeField] GameObject Squid4;
    [SerializeField] GameObject Squid5;
    void Start()
    {
        enemySpawner = GetComponent<Collider>();
    }

    
    void Update()
    {
        
    }


    //Enemy wave 1
    private void OnTriggerEnter()
    {
        enemySpawner.enabled = false;
        Instantiate(LightEnemy, new Vector3(60, 20, 0), Quaternion.Euler(-90, 180, 0));
        Instantiate(LightEnemy, new Vector3(70, 0, 0), Quaternion.Euler(-90, 180, 0));
        Instantiate(LightEnemy, new Vector3(75, -20, 0), Quaternion.Euler(-90, 180, 0));
        Squid2.SetActive(true);
    }
}
