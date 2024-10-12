using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashWeapon : WeaponBase
{
    [SerializeField] GameObject leftslashatk;
    [SerializeField] GameObject rightslashatk;

    PlayerDetlaControl playermove;

    private Vector2 atksize = new Vector2(1f, 1f);


    private void Awake()
    {
        playermove = GetComponentInParent<PlayerDetlaControl>();
    }

    public override void Atk()
    {
        

        StartCoroutine(AtkProcess());

    }

    IEnumerator AtkProcess()
    {
        for(int i = 0; i < weaponstats.numofatk; i++)
        {
            Debug.Log("Attk");
            if (playermove.lastXAtk > 0)
            {
                rightslashatk.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightslashatk.transform.position, atksize, 0f);
                ApplyDMG(colliders);

            }
           else
            {
                leftslashatk.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftslashatk.transform.position, atksize, 0f);
                ApplyDMG(colliders);
            }

            yield return new WaitForSeconds(0.3f);

        }

      

    }



    private void ApplyDMG(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamage e = colliders[i].GetComponent<IDamage>();
            if (e != null)
            {
                PostDamage(weaponstats.dmg, colliders[i].transform.position);
                e.TakeDamage(weaponstats.dmg);
            }
        }
        
    }



}
