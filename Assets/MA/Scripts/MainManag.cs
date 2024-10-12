using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManag : MonoBehaviour
{
    public void StartGame()
    {
        //SceneManager.LoadScene("GaunletLevel");
        //SceneManager.LoadScene("SeamlessLevel");
        SceneManager.LoadScene("lvlmo");
    }

    

    public void QuitGame()
    {
        Application.Quit();
    }

}
