using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {
    //Events we emit
    public UnityEvent OnHealthChanged;
    public UnityEvent OnScoreChanged;

    //Respawn the player
    public void Respawn() {
        transform.position = LevelSingleton.level.playerSpawnPoint.transform.position;
    }

    private void OnDeath() {
        //Feel free to comment out this line if you need to
        Respawn();
    }

    private int m_health = 100;
    private int m_score = 0;
    public int Health {
        get {
            return m_health;
        }

        set {
            m_health = value;
            OnHealthChanged.Invoke();
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
            OnScoreChanged.Invoke();
        }
    }

    void Awake() {
        LevelSingleton.player = this;
        OnHealthChanged = new UnityEvent();
        OnScoreChanged = new UnityEvent();
    }
}
