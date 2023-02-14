using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col) {
        if (col.name == "Player") {
            //Player won

            //This function errors if there is no next level
            try {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            catch {
                Debug.Log("Player won the game, sadly you just lost it");
            }
        }
    }
}
