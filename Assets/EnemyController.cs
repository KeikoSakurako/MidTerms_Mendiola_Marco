using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public EnemyCameraSpawn spawner; //reference for the enemycameraspawn

    public float movespd = 5f;
    Rigidbody2D rb;

    public int dmg = 2;
    public float maxhealth = 10;
    public float curhealth;
    public bool isright;

  
    
    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //starting health
        curhealth = maxhealth;   

    }

    // Update is called once per frame
    void Update()
    {

        if (!player)
        {
            GetTarget();
            
        }
        else 
        {
            
        }

  

    }

    //finding the player
    private void GetTarget()
    {
        //reference of the location of the player
        if (GameObject.FindGameObjectWithTag("Player"))
        {
           // player = GameObject.FindGameObjectWithTag("Player").transform;
            player = FindObjectOfType<PlayerControl>().transform;
        }
    }

    //this is use for the enemy spawn the camera of sir made
    public void Initialize(Transform players, EnemyCameraSpawn spawners)
    {
        player = players;
        spawner = spawners;
    }

    private void FixedUpdate()
    {
        //simple follow the player and checking if the player exist
        if (player != null)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, player.position, movespd * Time.deltaTime));

            Vector3 scale = transform.localScale;

            //flip the scale of the enemy sprite
            if (player.transform.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * -1 * (isright ? -1 : 1);

            }
            else
            {
                scale.x = Mathf.Abs(scale.x) * (isright ? -1 : 1);

            }

            transform.localScale = scale;


        }
       
    }

    //to damage the player
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerControl>().DamagePlayer(dmg);

        }
    }

    //when the damage the nemy
    public void DamageEnemy(int dmg)
    {
        curhealth -= dmg;

        if (curhealth <= 0)
        {
            StageManager.instanse.KillCount(1);

            //use for objectpulling
            gameObject.SetActive(false);
            spawner.ReturnEnemyToPool(this);

            //This is for the instance and not objectpulling
            //Destroy(gameObject);


        }
    }





}
