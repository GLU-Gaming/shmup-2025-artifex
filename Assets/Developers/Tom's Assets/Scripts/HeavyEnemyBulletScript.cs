using UnityEngine;

public class HeavyEnemyBulletScript : MonoBehaviour
{
    [SerializeField] private int forwardThrust = 0;
    Rigidbody rb;
    [SerializeField] ParticleSystem bulletCollision;

    private int EnemyBullet = 2;

    private float EnemyBulletTime = 3f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(transform.right * forwardThrust);
    }


    void Update()
    {
        EnemyBulletTime -= Time.deltaTime;
        if (EnemyBullet == 0)
        {
            Destroy(gameObject);
        }
        else if(EnemyBulletTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        EnemyBullet -= 1;
    }
}
