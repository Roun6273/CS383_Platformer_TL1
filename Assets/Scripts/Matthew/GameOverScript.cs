using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
  public void LoadMainMenu(){
    SceneManager.LoadScene(0);
  }
  
  public void LoadFirstLevel(){
    SceneManager.LoadScene(1);
  }
}
