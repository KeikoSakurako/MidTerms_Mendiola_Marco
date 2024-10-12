using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugtest : MonoBehaviour
{

    //public Transform player;
    //public bool flip;
    public StageManager m;

    //private StageManager ki;
    public Text finalkilltext;
    public Text finaltimertext;

  

    private void Start()
    {
        DisplayStats();
    }

    private void Update()
    {
       

        #region
        //Vector3 scale = transform.localScale;
        //if (player.transform.position.x > transform.position.x)
        //{
        //    scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
        //}
        //else
        //{
        //    scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        //}
        //transform.localScale = scale;
        #endregion
    }

    void DisplayStats()
    {
        

        int minutes = Mathf.FloorToInt(m.elapsedTime / 60);
        int seconds = Mathf.FloorToInt(m.elapsedTime % 60);

        finaltimertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        finalkilltext.text = m.killfeed.ToString();
    }

    #region
    //Vector2 that need to return in order to have a complete value
    //public Transform target;
    //public float spawnradius = 1f;
    //public Vector2 GetRandom() {return (Vector2)target.position + new Vector2(Random.Range(-spawnradius, spawnradius), Random.Range(-spawnradius, spawnradius)); }
    #endregion




}
