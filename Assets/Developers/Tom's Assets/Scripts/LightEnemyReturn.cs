using UnityEngine;

public class LightEnemyReturn : MonoBehaviour
{
    [SerializeField] private Transform LightEnemy;


    private LightEnemyMech LightEnemymech;
    void Start()
    {
        LightEnemymech = FindFirstObjectByType<LightEnemyMech>();
    }

    
    void Update()
    {
        if(LightEnemymech.AttackCoolDown >= 0)
        {
            transform.position = new Vector3(LightEnemy.transform.position.x, LightEnemy.transform.position.y, LightEnemy.transform.position.z);
        }
    }
}
