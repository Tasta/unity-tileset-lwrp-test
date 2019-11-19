using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // List of scenes to play
    public string[] scenes;

    // Runtime
    public World currentWorld { get; protected set; }
    public InputDevice input { get; protected set; }

    private void Awake() {
        // Mark as persistent
        DontDestroyOnLoad(gameObject);

        // Set input scheme
        input = new KeyboardDevice();

        // Load world from current scene
        currentWorld = GameObject.Find("World")?.GetComponent<World>();
        currentWorld.Initialize(this);
    }

    private void Update() {
        input?.Update();
    }
} // class Game
