using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //play button function which loads the "game" Scene - TR
    public void StartGame(){
        SceneManager. LoadScene("Game");
    }

    //Exit Game Button which quits the game. Has debug window entry for verification- TR
    public void Quit(){
        Application.Quit();
        Debug.Log("Player has quit the game!");
    }

}
