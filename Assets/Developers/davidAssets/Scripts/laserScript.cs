using UnityEngine;

public class laserScript : MonoBehaviour
{
    [SerializeField] public GameManager Gamemanager;
    [SerializeField] public playerController Player;
    [SerializeField] public Collider laserCollider;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    //On contact logic
    public void OnTriggerEnter(Collider other)
    {
        laserCollider.enabled = false;
    }
}
