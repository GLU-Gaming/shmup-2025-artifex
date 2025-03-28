using UnityEngine;

public class ForceField : MonoBehaviour
{
    private HeavyMovement heavyMovement;

    public int ForceFieldLives = 30;

    


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
        ForceFieldLives -= 1;
    }
}
