using UnityEngine;

public class HeavyEnemyBulletScript : MonoBehaviour
{
    [SerializeField] private int forwardThrust = 0;
    Rigidbody rb;
    [SerializeField] ParticleSystem bulletCollision;

    

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(transform.right * forwardThrust);
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        Destroy(gameObject);
    }
}
