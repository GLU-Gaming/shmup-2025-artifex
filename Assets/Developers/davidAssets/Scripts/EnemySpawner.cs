using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject LightEnemy;
    [SerializeField] GameObject MediumEnemy;
    [SerializeField] GameObject HeavyEnemy;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter()
    {
        Instantiate(LightEnemy, new Vector3(0, 0, 0), Quaternion.identity);
        
    }
}
