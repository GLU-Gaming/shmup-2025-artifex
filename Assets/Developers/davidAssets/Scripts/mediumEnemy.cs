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
    private float IdleTimer = 100;
    private float enemySpeed = 5;
    [SerializeField] Transform[] targetPositions;
    private int arrayCounter = 0;


    //Behavior function setup
    enum EnemyBehavior
    {
        Idle,
        LockedOn,
    }
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
