using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class World : MonoBehaviour
{
    [Header("Tilemap parent of custom objects")]
    public Transform tilemap;

    [Header("The player controller")]
    public PlayerController player;

    // Objects needed for game logic
    private List<Objective> beacons;
    private Teleport portal;

    // Links
    private Game game;
    private HUD hud;

    // Track items lit
    private int itemsLit = 0;

    /*
     * Initialize this world.
     */
    public void Initialize(Game game) {
        this.game = game;
        this.hud = game.hud;

        this.itemsLit = 0;
        OnProgress(0.0f);
    }

    /*
     * Start playing this world.
     */
    public void StartPlay() {
        // Initialize interactable objects
        beacons = new List<Objective>();
        foreach (Transform child in tilemap) {
            if (child.name == "Objective") {
                var interactable = child.GetComponent<Objective>();
                if (interactable != null) {
                    beacons.Add(interactable);
                    interactable.Initialize(this, game.input, OnBeaconLit);
                } else {
                    Debug.LogWarning("Object in Interactable tilemap has no Objective component.");
                }
            } else if (child.name == "Teleport") {
                portal = child.GetComponent<Teleport>();
                portal.Initialize(this, game.input, OnTeleport);
                portal.Hide();
            }
        }

        // Initialize player control
        player.Bind(game.input);
    }

    private void OnBeaconLit() {
        itemsLit++;

        if (itemsLit == beacons.Count) {
            portal.Show();
        }

        OnProgress((float)itemsLit / beacons.Count);
    }

    private void OnTeleport() {
        game.Advance();
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
