using UnityEngine;

public class LightEnemyReturn : MonoBehaviour
{
    private Transform LightEnemy;


    private LightEnemyMech LightEnemymech;
    void Start()
    {
        LightEnemymech = GetComponentInParent<LightEnemyMech>();
        LightEnemy = LightEnemymech.transform;
    }

    
    void Update()
    {
        if(LightEnemymech.AttackCoolDown >= 0)
        {
            transform.position = new Vector3(LightEnemy.transform.position.x, LightEnemy.transform.position.y, LightEnemy.transform.position.z);
        }
    }

    
}
