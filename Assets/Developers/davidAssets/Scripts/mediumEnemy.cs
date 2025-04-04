using Unity.VisualScripting;
using UnityEngine;

public class mediumEnemy : MonoBehaviour
{
    public Rigidbody rb;
    //Laser variables
    [SerializeField] public GameObject laser;
    //Enemy health variables
    public int enemyHealth = 15;
    //Behavior variables
    private EnemyBehavior State;
    private float IdleTimer = 10;
    private float LockOnTimer = 1;
    private float enemySpeed = 10;
    [SerializeField] Transform[] targetPositions;
    private int arrayCounter = 0;
    [SerializeField] Transform laserSpawnPoint;


    //Behavior function setup
    enum EnemyBehavior
    {
        Idle,
        LockedOn,
    }
    //Enemy idle behavior
    void EnemyIdleLoop()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPositions[arrayCounter].position, enemySpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPositions[arrayCounter].position) <0.4f)
        {
            arrayCounter++;
            if (arrayCounter >= targetPositions.Length)
            {
                arrayCounter = 0;
            }
        }
    }
    //Enemy locked on behavior
    void EnemyLockedOnLoop()
    {
        IdleTimer = 10;
        LockOnTimer -= Time.deltaTime;
        if (LockOnTimer <= 0)
        {
            Debug.Log("Firing");
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        State = EnemyBehavior.Idle;
    }


    void Update()
    {
        //Death logic
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        //Behavior logic
        IdleTimer -= Time.deltaTime;
        
        if (State == EnemyBehavior.Idle)
        {
            EnemyIdleLoop();
        }
        if (State == EnemyBehavior.LockedOn)
        {
            EnemyLockedOnLoop();
        }
        if (IdleTimer < 0)
        {
            State = EnemyBehavior.LockedOn;
        }
    }


    //Damage logic
    public void OnCollisionEnter(Collision collision)
    {
        enemyHealth--;
    }

    
}
