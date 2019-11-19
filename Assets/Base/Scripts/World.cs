using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class World 
    : MonoBehaviour
{
    [Header("HUD object")]
    public HUD hud;

    [Header("Tilemap parent of custom objects")]
    public Transform tilemap;

    [Header("The player controller")]
    public PlayerController player;

    // Objects needed for game logic
    private List<Interactable> beacons;
    private Interactable portal;

    // Link to the game
    public Game game;

    /*
     * Initialize this world.
     */
    public void Initialize(Game game) {
        this.game = game;
    }

    /*
     * Start playing this world.
     */
    public void StartPlay() {
        // Initialize interactable objects
        beacons = new List<Interactable>();
        foreach (Transform child in tilemap) {
            if (child.name == "Objective") {
                var interactable = child.GetComponent<Interactable>();
                if (interactable != null) {
                    beacons.Add(interactable);
                    interactable.Initialize(this, game.input);
                } else {
                    Debug.LogWarning("Object in Interactable tilemap has no Interactable component.");
                }
            } else if (child.name == "Portal") {
                portal = child.GetComponent<Interactable>();
                portal.Initialize(this, game.input);
            }
        }

        // Initialize player control
        player.Bind(game.input);
    }

    /*
     * When progress is 1.0f, jump to next world, if any.
     */
    public void OnProgress(float progress) {
        progress = Mathf.Clamp01(progress);

        // Pass to UI
        hud.OnProgress(progress);
    }
} // class World
