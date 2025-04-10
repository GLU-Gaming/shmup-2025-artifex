using UnityEngine;

public class TridentMech : MonoBehaviour
{
    
        

        public GameManager game;

        private Transform Player;

        

        [SerializeField] private float TargetspeedIncreaseY;

        private float TargetspeedY;

        [SerializeField] public float AttackCoolDown = 5f;

        

        

        

        
       

        public int LightEnemyLives = 3;

        private Vector3 PositionReturn;

        public MainBossMechanics MainBoss;

        void Start()
        {
            Player = FindFirstObjectByType<playerController>().transform;
            
            
            MainBoss = FindFirstObjectByType<MainBossMechanics>();

            

            game = FindFirstObjectByType<GameManager>();
        }


        void Update()
        {
            TargetspeedY = TargetspeedIncreaseY;

            AttackCoolDown = -0.1f;
            transform.position = new Vector3(transform.position.x - Time.deltaTime * 20, Mathf.Lerp(transform.position.y, Player.transform.position.y, Time.deltaTime * 3), transform.position.z);
        }




    }

