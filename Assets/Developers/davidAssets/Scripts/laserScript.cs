using UnityEngine;

public class laserScript : MonoBehaviour
{
    [SerializeField] public playerController player;
    [SerializeField] public GameManager Gamemanager;
    public Collider laserCollider;
    void Start()
    {
        laserCollider = FindFirstObjectByType<Collider>();
        Destroy(gameObject, 5);
    }

    
    void Update()
    {
        
    }
    //On contact logic
    public void OnTriggerEnter(Collider other)
    {
        player.playerHealth = player.playerHealth - 1;
        laserCollider.enabled = false;
    }
}
