using UnityEngine;

public class ForceField : MonoBehaviour
{
    private HeavyMovement heavyMovement;

    public int ForceFieldLives = 30;
    [SerializeField] private AudioSource collisionSfx;
    


    void Start()
    {
        heavyMovement = GetComponentInParent<HeavyMovement>();
    }

    
    void Update()
    {
        transform.position = new Vector3(transform.position.x, heavyMovement.transform.position.y, heavyMovement.transform.position.z);

        if (ForceFieldLives < 0)
        {
            gameObject.SetActive(false);
            
            
        }

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionSfx.Play();
        ForceFieldLives -= 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyWrapper")
        {
            Destroy(gameObject);
        }
    }
}
