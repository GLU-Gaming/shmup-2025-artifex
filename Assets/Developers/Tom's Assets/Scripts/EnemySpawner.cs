using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject LightEnemy;
    [SerializeField] private GameObject LightEnemy2;
    [SerializeField] private GameObject HeavyEnemy;

    void Start()
    {
            
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        LightEnemy.gameObject.SetActive(true);
        LightEnemy2.gameObject.SetActive(true);
        HeavyEnemy.gameObject.SetActive(true);
    }
}
