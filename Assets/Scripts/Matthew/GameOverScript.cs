using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
  public void LoadMainMenu(){
    SceneManager.LoadScene("MainMenu");
    Debug.Log("pressed");
  }

  public void LoadFirstLevel(){
    SceneManager.LoadScene("Game");
    Debug.Log("pressed");
  }
}

