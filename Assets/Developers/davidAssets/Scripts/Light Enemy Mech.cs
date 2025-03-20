using UnityEngine;

public class LightEnemyMech : MonoBehaviour
{
    [SerializeField] private Transform Player;

    bool TargetDownOrUp = true;

    [SerializeField] private float TargetspeedIncreaseY;

    private float TargetspeedY;

    [SerializeField] private float AttackCoolDown = 5f;

    public float minimum = -1.0F;
    public float maximum = 1.0F;


    static float t = 0.0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        AttackCoolDown -= Time.deltaTime;

        TargetspeedY = TargetspeedIncreaseY;

        if (transform.position.y >= 10)
        { if(AttackCoolDown >= 0)
            {
                TargetDownOrUp = false;
            }
            
        }
        else if (transform.position.y <= -10)
        {
            if (AttackCoolDown >= 0)
            {
                TargetDownOrUp = true;
            }
            
        }
        if (TargetDownOrUp == false)
        {
            if (AttackCoolDown >= 0)
            {
                TargetspeedIncreaseY = -0.30f;
            }
            
        }

        if (TargetDownOrUp == true)
        {
            if (AttackCoolDown >= 0)
            {
                TargetspeedIncreaseY = 0.30f;
            }

        }
        if (AttackCoolDown >= 0)
        {
            transform.position += new Vector3(0, TargetspeedY * Time.deltaTime * 20f, 0);
        }
        if(AttackCoolDown < 0)
        {
            AttackCoolDown = -0.1f;
            transform.position = new Vector3(transform.position.x - Time.deltaTime, Mathf.Lerp(Player.position.y, Player.position.y, t), transform.position.z);

            t += 0.5f * Time.deltaTime;

            if (t > 1f)
            {
                float temp = Player.position.y;
                maximum = Player.position.y;
                minimum = temp;
                t = 0.0f;
            }

        }
       

    }
}

