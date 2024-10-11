using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManag : MonoBehaviour
{
    public void StartGame()
    {
        //SceneManager.LoadScene("GaunletLevel");
        SceneManager.LoadScene("Deloglvl");
    }

    

    public void QuitGame()
    {
        Application.Quit();
    }

}
