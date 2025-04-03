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


    //Behavior function setup
    enum EnemyBehavior
    {
        Idle,
        LockingOn,
        Shooting,
        Reset,
    }
    void EnemyIdleLoop()
    {
        //Enemy movement
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
            State = EnemyBehavior.LockingOn;
        }
    }


    //Damage logic
    public void OnCollisionEnter(Collision collision)
    {
        enemyHealth--;
    }

    
}
