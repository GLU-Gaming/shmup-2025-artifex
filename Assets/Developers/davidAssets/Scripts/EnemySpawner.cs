using System.Transactions;
using UnityEngine;

[System.Serializable]
public class SpawnData
{
    public GameObject prefab;
    public Vector3 spawnPosition;
}

public class EnemySpawner : MonoBehaviour
{
    private Collider enemySpawner;

    [SerializeField] SpawnData[] spawnDatas;
    [SerializeField] Transform[] targetPositions;

    void Start()
    {
        enemySpawner = GetComponent<Collider>();
    }

    
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        for (int i = 0; i < spawnDatas.Length; i++)
        {
            Gizmos.DrawSphere(transform.position + spawnDatas[i].spawnPosition, 0.5f);
        }
    }

    //Enemy wave 1
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("OnderZeeer")) return;

        enemySpawner.enabled = false;
        //Instantiate(LightEnemy, new Vector3(60, 20, 0), Quaternion.Euler(-90, 180, 0));
       // Instantiate(LightEnemy, new Vector3(70, 0, 0), Quaternion.Euler(-90, 180, 0));
        //Instantiate(LightEnemy, new Vector3(75, -20, 0), Quaternion.Euler(-90, 180, 0));
       // Squid2.SetActive(true);

        for (int i = 0; i < spawnDatas.Length; i++)
        {
            GameObject enemySpawned = Instantiate(spawnDatas[i].prefab, transform.position + spawnDatas[i].spawnPosition, Quaternion.identity);
            mediumEnemy medium = enemySpawned.GetComponent<mediumEnemy>();
            if (medium != null)
            {
                medium.targetPositions= targetPositions;
            }
        }
    }
}
