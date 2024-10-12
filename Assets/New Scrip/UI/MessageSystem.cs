using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    [SerializeField] GameObject damagaemsg;

    public static MessageSystem instance;

    List<TextMesh> msgpool;

    int objectcount = 10;
    int count;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        msgpool = new List<TextMesh>();

        for (int i = 0; i < objectcount; i++)
        {
            Populate();

        }
    }

    public void Populate()
    {
        GameObject go = Instantiate(damagaemsg, transform);
        msgpool.Add(go.GetComponent<TextMesh>());
        go.SetActive(false);

       
    }



    public void PostMessage(string text, Vector3 worldposition)
    {
        msgpool[count].gameObject.SetActive(true);
        msgpool[count].transform.position = worldposition;
        msgpool[count].text = text;
        count += 1;

        if(count >= objectcount)
        {
            count = 0;
        }


    }


}
