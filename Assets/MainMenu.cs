using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
    public void PlayGame ()
    
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    public void QuitGame ()

    {
        Debug.Log("why would you do this. This is the perfect game. WHY WOULD YOU WILLINGLY STOP PLAYING. You monster.");
        Application.Quit();
    }





}    
 