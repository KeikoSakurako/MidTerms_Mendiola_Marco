using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour
{
    //Stats
    [SerializeField] float movespd = 5f; // movement speed
    public float maxhealh = 100f;
    public float curhealth;
    
    //atk input soon
    //public float atktimer;
    //public float atkrate = 0.5f;

    public bool isright = true;

    //Reference
    public Animator anim;
    public Image healthbar; 
    private Rigidbody2D rb; // Rididbogy reference
    
    //calucation
    Vector2 move;

    private void Awake()
    {
        //spriteneder get compoint
        curhealth = maxhealh;
        rb = GetComponent<Rigidbody2D>();
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        //to have a consistent dialgonal spd
        move = new Vector2(move.x, move.y).normalized;

        //add like a timer for the atk animation

        //walking animation
        if (move != Vector2.zero)
        {
            anim.SetBool("move", true);
        }
        else
        {
            anim.SetBool("move", false);
        }

        //Fliping the sprite
         if (move.x < 0 && !isright)
        {
            Flip();
        }

        if (move.x > 0 && isright)
        {
            Flip();
        }

    }

    private void FixedUpdate()
    {
        //movement for the player
        rb.MovePosition(rb.position + move * movespd * Time.deltaTime);
        
    }

    public void Flip()
    {
        isright = !isright;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }

    //add soon to play the animation atk

    public void DamagePlayer(int dmg)
    {
        
        healthbar.fillAmount = curhealth / maxhealh;
        curhealth -= dmg;

        if (curhealth <= 0)
        {
            FindObjectOfType<StageManager>().GameOverScreen();
            Destroy(gameObject);


        }

    }



}
