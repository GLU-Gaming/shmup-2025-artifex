using JetBrains.Annotations;
using UnityEditor.Search;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Movement variables
    public Rigidbody rb;
    [SerializeField] private int horizontalMovementSpeed = 0;
    [SerializeField] private int verticalMovementSpeed = 0;

    void Start()
    {
        //Fetch rigidbody
        rb = GetComponent<Rigidbody>();
        
    }

    
    void Update()
    {
        //Movement logic

        //Left
        if (Input.GetKey(KeyCode.A) == true)
        {
            rb.AddRelativeForce(Vector3.left * horizontalMovementSpeed);
        }
        //Right
        if (Input.GetKey(KeyCode.D) == true)
        {
            rb.AddRelativeForce(Vector3.right * horizontalMovementSpeed);
        }
        //Up
        if (Input.GetKey(KeyCode.W) == true)
        {
            rb.AddRelativeForce(Vector3.up * verticalMovementSpeed);
        }
        //Down
        if (Input.GetKey(KeyCode.S) == true)
        {
            rb.AddRelativeForce(Vector3.down * verticalMovementSpeed);
        }
    }
}
