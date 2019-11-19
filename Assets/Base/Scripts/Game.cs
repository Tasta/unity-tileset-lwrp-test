using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    // List of scenes to play
    public int startSceneIdx = 0;
    public string[] scenes;

    // Runtime
    public World currentWorld { get; protected set; }
    public InputDevice input { get; protected set; }
    public HUD hud { get; protected set; }
    public int sceneIdx { get; protected set; }

    private void Awake() {
        sceneIdx = startSceneIdx;

        // Mark as persistent
        DontDestroyOnLoad(gameObject);

        // Load HUD
        hud = GameObject.Find("HUD")?.GetComponent<HUD>();
        hud.actionMessage.text = "World 1\nTap to start";

        // Set input scheme
        //input = new KeyboardDevice();
        input = new MouseDevice();

        // Init current world
        InitWorld();
    }

    private void InitWorld() {
        // Load world from current scene
        currentWorld = GameObject.Find("World")?.GetComponent<World>();
        if (currentWorld != null)
            currentWorld.Initialize(this);
        hud.Bind(currentWorld);
    }

    private void Update() {
        input?.Update();
    }

    public void Advance() {
        sceneIdx++;

        if (sceneIdx >= scenes.Length) {
            hud.actionMessage.text = "This is it!";
            StartCoroutine(hud.OnLevelEnd());
            hud.button.enabled = false;
        } else {
            hud.actionMessage.text = "World " + (sceneIdx + 1) + "\nTap to start";
            StartCoroutine(NextScene(scenes[sceneIdx]));
        }
    }

    private IEnumerator NextScene(string sceneName) {
        yield return hud.OnLevelEnd();
        yield return SceneManager.LoadSceneAsync(sceneName);        
        InitWorld();
    }
} // class Game
