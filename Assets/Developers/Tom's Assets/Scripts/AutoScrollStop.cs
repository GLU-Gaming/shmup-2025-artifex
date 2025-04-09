using UnityEngine;

public class AutoScrollStop : MonoBehaviour
{
    public AutoScroll autoscroll;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        autoscroll = FindFirstObjectByType<AutoScroll>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerScreenWrapper")
        {
            Debug.Log("test");
            autoscroll.forwardThrust = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerScreenWrapper")
        {
            Debug.Log("test");
            autoscroll.forwardThrust = 0;
        }
    }
}
