using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour {
    [SerializeField]
    private List<AudioClip> audioClips;
    void OnTriggerEnter2D(Collider2D col) {
        if (col.name == "Player") {
            Player player = col.GetComponent<Player>();
            player.Score += 100;
            AudioSource.PlayClipAtPoint(audioClips[Random.Range(0, audioClips.Count)], player.transform.position);
            Object.Destroy(this.gameObject);
        }
    }
}
