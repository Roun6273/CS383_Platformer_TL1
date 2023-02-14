using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EndGoal : MonoBehaviour {
    //When the goal is reached
    public UnityEvent OnEndGoalReached;
    //When the LAST goal is reached
    public UnityEvent OnGameFinished;

    void Awake() {
        LevelSingleton.endGoal = this;
        OnEndGoalReached = new UnityEvent();
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.name == "Player") {
            //Player won
            OnEndGoalReached.Invoke();
            
            try {
                //This bit errors if there is no next level
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            catch {
                Debug.Log("Player won the game, sadly you just lost it");
                OnGameFinished.Invoke();
            }
        }
    }
}
