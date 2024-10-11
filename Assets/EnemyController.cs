using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
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

    private void GetTarget()
    {
        //reference of the location of the player
        if (GameObject.FindGameObjectWithTag("Player"))
        {
           // player = GameObject.FindGameObjectWithTag("Player").transform;
            player = FindObjectOfType<PlayerControl>().transform;
        }
    }


    private void FixedUpdate()
    {
        //simple follow the player and checking if the player exist
        if (player != null)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, player.position, movespd * Time.deltaTime));

            Vector3 scale = transform.localScale;

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


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerControl>().DamagePlayer(dmg);

        }
    }

    public void DamageEnemy(int dmg)
    {
        curhealth -= dmg;

        if (curhealth <= 0)
        {
            StageManager.instanse.KillCount(1);
            Destroy(gameObject);


        }
    }





}
