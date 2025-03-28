using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


enum LightEnemyState
{
    Idle,
    Attack, 
    Reset
}


public class LightEnemyMech : MonoBehaviour
{
    private Transform Player;

    bool TargetDownOrUp = true;

    [SerializeField] private float TargetspeedIncreaseY;

    private float TargetspeedY;

    [SerializeField] public float AttackCoolDown = 5f;

    private LightEnemyState State;

    private Transform ReturnPoint;

    public GameObject ReturnPoints;

    //vector3 variabele van de returnPosition;
    private int ReturnTrigger = 0;

    public int LightEnemyLives = 3;

    private Vector3 PositionReturn;
    

    void Start()
    {
        Player = FindFirstObjectByType<playerController>().transform;
        ReturnPoint = GetComponentInChildren<LightEnemyReturn>().transform;
        ReturnPoints = GetComponentInChildren<LightEnemyReturn>().gameObject;

        State = LightEnemyState.Idle;
        
    }


    void Update()
    {
        AttackCoolDown -= Time.deltaTime;

        TargetspeedY = TargetspeedIncreaseY;

        if (transform.position.y >= 10)
        { if (AttackCoolDown >= 0)
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
        if (AttackCoolDown < 0)
        {
            if(ReturnTrigger == 0)
            {
                if(State == LightEnemyState.Idle)
                {
                    //returnPosition vullen met z'n 
                    PositionReturn = transform.position;
                    State = LightEnemyState.Attack;
                }
                

                AttackCoolDown = -0.1f;
                transform.position = new Vector3(transform.position.x - Time.deltaTime * 20, Mathf.Lerp(transform.position.y, Player.transform.position.y, Time.deltaTime * 3), transform.position.z);
            }
        }

        if(ReturnTrigger == 1)
        {
            State = LightEnemyState.Reset;

            //transform.position = new Vector3(Mathf.Lerp(transform.position.x, ReturnPoint.transform.position.x, Time.deltaTime * 1), Mathf.Lerp(transform.position.y, ReturnPoint.transform.position.y, Time.deltaTime * 1), transform.position.z);
            transform.position = Vector3.Lerp(transform.position, PositionReturn, Time.deltaTime * 2);
            

            if (Vector3.Distance(PositionReturn, transform.position) < 0.1f)
            {
                ReturnTrigger = 0;
                AttackCoolDown = 5f;
                State = LightEnemyState.Idle;
            }
        }

        if(LightEnemyLives <= 0)
        {
            Destroy(gameObject);
            Destroy(ReturnPoints);
        }


    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RespawnPoint")
        {
            ReturnTrigger = 1;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            LightEnemyLives -= 1;
        }

        if(collision.gameObject.tag == "OnderZeeer")
        {
            LightEnemyLives -= 3;
        }
        
        
    }
}