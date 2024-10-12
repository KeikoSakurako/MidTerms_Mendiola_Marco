using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetlaControl : MonoBehaviour
{
    //Stats
    [SerializeField] float movespd = 5f; // movement speed
    public float maxhealh = 100f;
    public float curhealth;

    public bool isright = true;

    //EditInOriginal
    public float lastXAtk;
    public float lastYAtk;

    public int armor = 0;

    //Reference
    public Animator anim;
    public Image healthbar;
    private Rigidbody2D rb; // Rididbogy reference

    public LevelManager lvl;
    public Coin coins;

    //calucation
    public Vector2 move;

    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        //spriteneder get compoint
        curhealth = maxhealh;
        rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        lvl = GetComponent<LevelManager>();
        coins = GetComponent<Coin>();
    }

    // Start is called before the first frame update
    void Start()
    {
        lastXAtk = 1f;
        lastYAtk = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        //LastAtk
        if (move.x != 0)
        {
            lastXAtk = move.x;
        }
        if (move.y != 0)
        {
            lastYAtk = move.y;
        }

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
        if (move.x < 0)
        {
            _spriteRenderer.flipX = true;
        }

        if (move.x > 0)
        {
            _spriteRenderer.flipX = false;
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
        //Armor Reference
        ApplyArmor(ref dmg);

        //Damage Calcu
        healthbar.fillAmount = curhealth / maxhealh;
        curhealth -= dmg;

        if (curhealth <= 0)
        {
            FindObjectOfType<StageManager>().GameOverScreen();
            Destroy(gameObject);


        }

    }

    private void ApplyArmor(ref int dmg)
    {
        dmg -= armor;
        if (dmg < 0) { dmg = 0; }

    }


    public void Heal(int amount)
    {
        if (curhealth <= 0) { return; }

        
        curhealth += amount;
        if(curhealth > maxhealh)
        {
            curhealth = maxhealh;
        }
        healthbar.fillAmount = curhealth / maxhealh;
    }


}
