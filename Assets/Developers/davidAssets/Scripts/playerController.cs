using JetBrains.Annotations;
using UnityEditor.Search;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Movement variables
    public Rigidbody rb;
    [SerializeField] private int horizontalMovementSpeed = 0;
    [SerializeField] private int verticalMovementSpeed = 0;
    private float maximumVelocity = 7;
    private float sinkSpeed = 2.5f;
    //Gun variables
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject Bullet;
    [SerializeField] private float bulletTimer = 0.0f;
    //Health variables
    public int playerHealth = 3;
    //Sparks effect
    [SerializeField] public ParticleSystem Sparks;
    void Start()
    {
        //Fetch rigidbody
        rb = GetComponent<Rigidbody>();
        

    }

    
    void Update()
    {
        //Movement logic
        rb.AddRelativeForce(Vector3.down * sinkSpeed);

        //Left
        if (Input.GetKey(KeyCode.A) == true)
        {
            if (rb.linearVelocity.x > -maximumVelocity)
            rb.AddRelativeForce(Vector3.left * horizontalMovementSpeed);
        }
        //Right
        if (Input.GetKey(KeyCode.D) == true)
        {
            if (rb.linearVelocity.x < maximumVelocity)
            rb.AddRelativeForce(Vector3.right * horizontalMovementSpeed);
        }
        //Up
        if (Input.GetKey(KeyCode.W) == true)
        {
            if (rb.linearVelocity.y < maximumVelocity)
            rb.AddRelativeForce(Vector3.up * verticalMovementSpeed);
        }
        //Down
        if (Input.GetKey(KeyCode.S) == true)
        {
            if (rb.linearVelocity.y > -maximumVelocity)
            rb.AddRelativeForce(Vector3.down * verticalMovementSpeed);
        }


        //Gun logic
        bulletTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) == true && bulletTimer < -0.2f)
        {
            Instantiate(Bullet, bulletSpawnPoint.position, Quaternion.Euler(90, 0, 90));
            bulletTimer = 0.0f;
        }
    }

    //Health logic
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            PlayerHit();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            PlayerHit();
        }
    }

    public void PlayerHit()
    {
        playerHealth = playerHealth - 1;
        Instantiate(Sparks, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
    }
}
