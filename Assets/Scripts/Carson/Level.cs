using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    public GameObject playerSpawnPoint;

    void Awake() {
        LevelSingleton.level = this;
    }
}
