using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float spd;
    public int dmg = 5;

    float ttl = 5f;

    bool isdectected = false;

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);

        if(dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;


        }

    }


    // Update is called once per frame
    void Update()
    {
        transform.position += direction * spd * Time.deltaTime;

        //Add a frame count to opimitezd
        if(Time.frameCount % 6 == 0)
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.3f);
            foreach (Collider2D c in hit)
            {
                IDamage e = c.GetComponent<IDamage>();
                if (e != null)
                {

                    PostDamage(dmg, transform.position);

                    e.TakeDamage(dmg);
                    isdectected = true;
                    break;
                }
            }
            if (isdectected == true)
            {
                Destroy(gameObject);
            }
        }

        ttl -= Time.deltaTime;
        if(ttl < 0f)
        {
            Destroy(gameObject);

        }



    }

    public void PostDamage(int dmg, Vector3 worldposition)
    {
        MessageSystem.instance.PostMessage(dmg.ToString(), worldposition);
    }

    
}
