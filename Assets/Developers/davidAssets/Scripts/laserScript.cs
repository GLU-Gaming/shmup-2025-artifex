using UnityEngine;

public class laserScript : MonoBehaviour
{
    public GameManager Gamemanager;
    [SerializeField] public playerController Player;
    [SerializeField] public Collider laserCollider;
    private GameObject laserParent;
    private bool laserFired = false;
    private float beamWidth = 2f;

    void Start()
    {
        laserFired = true;
        laserParent = transform.parent.gameObject;
        Gamemanager = FindFirstObjectByType<GameManager>();
        Player = FindFirstObjectByType<playerController>();
    }

     
    void Update()
    {
        if (laserFired == true)
        {
            gameObject.transform.localScale -= new Vector3(beamWidth * Time.deltaTime, 0 ,0);
        }
        if (gameObject.transform.localScale.x <= 0)
        {
            Destroy(laserParent);
        }
    }

    //On contact logic
    public void OnTriggerEnter(Collider other)
    {
        laserCollider.enabled = false;

        Debug.Log("HIT");
    }
}
