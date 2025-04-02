using UnityEngine;

public class HeavyEnemyBulletScript : MonoBehaviour
{
    [SerializeField] private int forwardThrust = 0;
    Rigidbody rb;
    [SerializeField] ParticleSystem bulletCollision;

    private int EnemyBullet = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(transform.right * forwardThrust);
    }


    void Update()
    {
        if (EnemyBullet == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        EnemyBullet -= 1;
    }
}
