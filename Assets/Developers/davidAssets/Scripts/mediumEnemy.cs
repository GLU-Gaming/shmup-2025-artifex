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
    private int IdleTimer = 5;
    [SerializeField] public Transform waypoint1;
    [SerializeField] public Transform waypoint2;
    [SerializeField] public Transform waypoint3;
    [SerializeField] public Transform waypoint4;
    [SerializeField] public Transform waypoint5;
    [SerializeField] public Transform waypoint6;
    [SerializeField] public Transform waypoint7;

    //Behavior function setup
    enum EnemyBehavior
    {
        Idle,
        LockedOn,
        Reset,
    }
    void EnemyIdleLoop()
    {
         //Chase waypoint
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
        IdleTimer--;
        
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
