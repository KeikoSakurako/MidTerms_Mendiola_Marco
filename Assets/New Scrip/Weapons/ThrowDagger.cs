using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDagger : WeaponBase
{
    [SerializeField] GameObject knifePreFab;
    [SerializeField] float spread = 0.5f;

    PlayerDetlaControl playermove;

    private void Awake()
    {
        playermove = GetComponentInParent<PlayerDetlaControl>();
    }


    public override void Atk()
    {
        

        for(int i = 0; i <weaponstats.numofatk; i++ )
        {
            GameObject throwknife = Instantiate(knifePreFab);

            Vector3 knifeposition = transform.position;
            if (weaponstats.numofatk > 1)
            {
                knifeposition.y -= (spread * (weaponstats.numofatk - 1)) / 2; //offset
                knifeposition.y += i * spread; //spread the dagger
            }

            throwknife.transform.position = knifeposition;


            ThrowProjectile throwProjectile = throwknife.GetComponent<ThrowProjectile>();
            throwProjectile.SetDirection(playermove.lastXAtk, 0f);

            throwProjectile.dmg = weaponstats.dmg;
        }

        

    }    



}
