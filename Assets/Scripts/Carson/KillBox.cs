using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col) {
        if (col.name == "Player") {
            Debug.Log("Got the player");
            Player player = col.gameObject.GetComponent<Player>();
            player.Health = 0;
        }
    }
}