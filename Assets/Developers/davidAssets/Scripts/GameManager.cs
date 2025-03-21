using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Playership variables
    [SerializeField] public playerController player;
    [SerializeField] public Transform playerPosition;
    [SerializeField] public ParticleSystem Sparks;
    void Start()
    {
        
    }
    void Update()
    {
        //Game over
        if (player.playerHealth <= 0)
        {
            Instantiate(Sparks, playerPosition.transform.position, Quaternion.Euler(0, 0, 0));
            Debug.Log("Death");
            //Endscreen
        }
    }
}
