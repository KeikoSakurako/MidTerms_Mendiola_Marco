using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyStats
{
    public float maxhealth = 10;
    public int dmg = 2;
    public float movespd = 5f;

    public EnemyStats(EnemyStats stats)
    {
        this.maxhealth = stats.maxhealth;
        this.dmg = stats.dmg;
        this.movespd = stats.movespd;
    }

    internal void ApplyProgress(float progress)
    {
        this.maxhealth = (int)(maxhealth * progress);
        this.dmg = (int)(dmg * progress);
    }

}

public class EnemyDeltaControl : MonoBehaviour, IDamage
{
    public Transform player;
    public EnemyDeltaCameraSpawn spawner; //EditInOriginal

    
    Rigidbody2D rb;


    public EnemyStats stats;
    //public float movespd = 5f;
    //public int dmg = 2;
    //public float maxhealth = 10;

    public float curhealth;
    public bool isright;

    //[SerializeField] GameObject dropItemPreFab;
    //[SerializeField] [Range(0f, 1f)] float dropchance = 1f;

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //starting health
        curhealth = stats.maxhealth;

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
    public void GetTarget()
    {
        //reference of the location of the player
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            // player = GameObject.FindGameObjectWithTag("Player").transform;

            //For testPurpose
            player = FindObjectOfType<PlayerDetlaControl>().transform; //EditInOriginal
        }
    }

    //this is use for the enemy spawn the camera of sir made
    public void Initialize(Transform players, EnemyDeltaCameraSpawn spawners) //EditInOriginal
    {
        player = players;
        spawner = spawners;
    }

    private void FixedUpdate()
    {
        //simple follow the player and checking if the player exist
        if (player != null)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, player.position, stats.movespd * Time.deltaTime));

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

    internal void SetStats(EnemyStats stats)
    {
        this.stats = new EnemyStats(stats);
    }

    internal void UpdateStatsProgress(float progress)
    {
        stats.ApplyProgress(progress);
    }

    //to damage the player
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            collision.gameObject.GetComponent<PlayerDetlaControl>().DamagePlayer(stats.dmg); //EditInOriginal
        }
    }

    //when the damage the nemy
    public void TakeDamage(int dmg)
    {
        curhealth -= dmg;

        if (curhealth <= 0)
        {
            StageManager.instanse.KillCount(1);

            //use for objectpulling
            //gameObject.SetActive(false);
            //spawner.ReturnEnemyToPool(this);

            GetComponent<DropOnDestroy>().CheckDrop();

            //This is for the instance and not objectpulling
            Destroy(gameObject);


        }
    }




}
