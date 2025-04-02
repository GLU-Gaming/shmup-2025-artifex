using UnityEngine;

public class AutoScroll : MonoBehaviour
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
}
