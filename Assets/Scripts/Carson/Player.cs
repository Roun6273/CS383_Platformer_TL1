using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Player : MonoBehaviour {
    //Events we emit
    public UnityEvent OnHealthChanged;
    public UnityEvent OnScoreChanged;
    public HealthBar healthBar;
    //Respawn the player
    public void Respawn() {
        transform.position = LevelSingleton.level.playerSpawnPoint.transform.position;
    }

    private void OnDeath() {
        //Feel free to comment out this line if you need to
        Respawn();
    }

    private int m_health = 3;
    private int m_score = 0;
    public TextMeshProUGUI scoreText;
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
            /*if (m_health <= 0) {
                OnDeath();
            }
            */
            Respawn();
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
        OnHealthChanged.AddListener(UpdateHP);
        OnScoreChanged.AddListener(UpdateScore);
        healthBar.setMaxHealth(m_health);
        scoreText.text = "Score: " + Score.ToString();
    }
    public void UpdateHP(){
        healthBar.UpdateHealth(Health);
    }
    public void UpdateScore(){
        scoreText.text = "Score: " + Score.ToString();

    }
}
