using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour {
    [SerializeField]
    private AudioSource _audioSource;
    void OnTriggerEnter2D(Collider2D col) {
        if (col.name == "Player") {
            Debug.Log("Got the player");
            _audioSource.Play();
            Player player = col.gameObject.GetComponent<Player>();
            player.Health = player.Health - 1;
        }
    }
    void Awake(){
        _audioSource = GetComponent<AudioSource>();
        if(_audioSource == null){
            Debug.Log("The audio source is null!");
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
        //DontDestroyOnLoad(_audioSource);
    }
}