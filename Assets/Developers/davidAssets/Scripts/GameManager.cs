using UnityEngine;
using UnityEngine.SceneManagement;

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
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        //Explosion
        Debug.Log("Death");
        SceneManager.LoadScene("endScene");
    }
}
