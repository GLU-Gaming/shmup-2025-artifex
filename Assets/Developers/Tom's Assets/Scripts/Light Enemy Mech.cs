using UnityEngine;

public class LightEnemyMech : MonoBehaviour
{
    [SerializeField] private Transform Player;

    bool TargetDownOrUp = true;

    [SerializeField] private float TargetspeedIncreaseY;

    private float TargetspeedY;

    [SerializeField] private float AttackCoolDown = 5f;

    


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
            transform.position = new Vector3(transform.position.x - Time.deltaTime * 20, Mathf.Lerp(transform.position.y, Player.transform.position.y, Time.deltaTime * 3), transform.position.z);

        }


       

    }
}

