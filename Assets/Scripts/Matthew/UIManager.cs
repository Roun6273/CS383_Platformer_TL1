using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public HealthBar healthBar;
    public Player player;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject UICanvas;
    void Awake()
    {
        healthBar.setMaxHealth(player.Health);
        scoreText.text = "Score: " + player.Score; //PlayerPrefs.GetInt("Score").ToString()
        //DontDestroyOnLoad()
    }

    public void UpdateHP(){
        healthBar.UpdateHealth(player.Health);
    }
    public void UpdateScore(){
        //PlayerPrefs.SetInt("Score", Score);
        scoreText.text = "Score: " + player.Score.ToString();

    }
}
