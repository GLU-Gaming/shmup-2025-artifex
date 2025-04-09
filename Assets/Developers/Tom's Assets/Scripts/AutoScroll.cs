using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    public int forwardThrust = 125;

    public Rigidbody rb;
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
