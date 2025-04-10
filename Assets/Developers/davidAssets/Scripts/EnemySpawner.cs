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
        if (!other.gameObject.CompareTag("PlayerScreenWrapper")) return;

        enemySpawner.enabled = false;


        for (int i = 0; i < spawnDatas.Length; i++)
        {
            GameObject enemySpawned = Instantiate(spawnDatas[i].prefab, transform.position + spawnDatas[i].spawnPosition, spawnDatas[i].prefab.transform.rotation);
            mediumEnemy medium = enemySpawned.GetComponent<mediumEnemy>();
            if (medium != null)
            {
                medium.targetPositions= targetPositions;
            }
        }
    }
}
