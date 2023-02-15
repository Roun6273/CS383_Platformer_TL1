using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    //Events we emit
    public UnityEvent OnHealthChanged;
    public UnityEvent OnScoreChanged;
    public UIManager UI;
    //Respawn the player
    public void Respawn() {
        transform.position = LevelSingleton.level.playerSpawnPoint.transform.position;
    }

    private void OnDeath() {
        //Feel free to comment out this line if you need to
        //Respawn();
        SceneManager.LoadScene(4);
    }

    private int m_health = 3;
    private int m_score = 0;
    public int Health {
        get {
            return m_health;
        }

        set {
            m_health = value;
            //Debugging checks
            //Debug.Log("In set");
            //Debug.Log(m_health);
            OnHealthChanged.Invoke();
            if (m_health <= 0) {
                OnDeath();
            }
            Respawn();
        }
    }

    public int Score {
        get {
            return m_score;
        }

        set {
            m_score = value;
            Debug.Log(m_score);
            PlayerPrefs.Save();
            OnScoreChanged.Invoke();
        }
    }

    void Awake() {
        LevelSingleton.player = this;
        OnHealthChanged = new UnityEvent();
        OnScoreChanged = new UnityEvent();
        OnHealthChanged.AddListener(UI.UpdateHP);
        OnScoreChanged.AddListener(UI.UpdateScore);
    }
}
