using UnityEngine;

public class mediumEnemy : MonoBehaviour
{
    public Rigidbody rb;
    //Laser variables
    [SerializeField] public GameObject laser;
    //Enemy health variables
    public int enemyHealth = 15;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        enemyHealth--;
    }

  
}
