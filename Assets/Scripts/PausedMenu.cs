/*This Script is to for the pause menu. All functions for all buttons
*for this menu are controlled by this script. Please see Tracy Rountre
*Team Lead 1 for TTC for more information.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{

    public GameObject PauseMenu;
    //pauses all running scripts during pause
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }

    //pause function
    public void PauseGame(){
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    //Resume Function
    public void ResumeGame(){
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    //Main Menu Function
    public void ToMainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    //Quit Application Function
    public void QuitGame(){
        Application.Quit();
    }
}
