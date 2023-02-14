using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private int m_health = 100;
    private int m_score = 0;
    public int Health {
        get {
            return m_health;
        }

        set {
            m_health = value;
            if (m_health <= 0) {
                OnDeath();
            }
        }
    }

    public int Score {
        get {
            return m_score;
        }

        set {
            m_score = value;
        }
    }

    private void OnDeath() {
        Debug.Log("CJ - Player died");
        transform.position = LevelSingleton.level.playerSpawnPoint.transform.position;
    }
}
