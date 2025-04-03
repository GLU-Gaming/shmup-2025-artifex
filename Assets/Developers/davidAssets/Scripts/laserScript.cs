using UnityEngine;

public class laserScript : MonoBehaviour
{
    [SerializeField] public GameManager Gamemanager;
    [SerializeField] public playerController Player;
    [SerializeField] public Collider laserCollider;
    private bool laserFired = false;
    //private float beamWidth = 1.0f;
    private void LaserFire()
    {
        //Despawn met een effect Scale X
        laserFired = true;
    }
    void Start()
    {
        LaserFire();
    }

     
    void Update()
    {
        if (laserFired == true)
        {
            //gameObject.transform.localScale.x += Vector3(beamWidth, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }

    //On contact logic
    public void OnTriggerEnter(Collider other)
    {
        laserCollider.enabled = false;
    }
}
