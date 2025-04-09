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

    //Game Manager Vinden
    public GameManager game;

    [SerializeField] int LiveAmount = 1;

    private float InvincibilityFrames = 2;
    void Start()
    {
        //Fetch rigidbody
        rb = GetComponent<Rigidbody>();

        game = FindFirstObjectByType<GameManager>();
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
            Instantiate(Bullet, bulletSpawnPoint.position, Quaternion.Euler(90, 90, 0));
            bulletTimer = 0.0f;
        }

        if(InvincibilityFrames < 2)
        {
            InvincibilityFrames += Time.deltaTime;
        }
        if(InvincibilityFrames >= 2)
        {
            transform.GetComponent<BoxCollider>().enabled = true;
        }
    }

    //Health logic
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            PlayerHit();
            game.RemoveLive(LiveAmount);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("OUU HET DOET ZEER");
            PlayerHit();
            game.RemoveLive(LiveAmount);
        }
    }

    public void PlayerHit()
    {
        playerHealth = playerHealth - 1;
        transform.GetComponent<BoxCollider>().enabled = false;
        InvincibilityFrames = 0;
        Instantiate(Sparks, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
    }
}
