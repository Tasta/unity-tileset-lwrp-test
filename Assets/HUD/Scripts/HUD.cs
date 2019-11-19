using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // UI Components
    public Text actionMessage;
    public Animator animator;
    public Text objectiveLabel;

    // Link to the world
    public World world;

    public void OnBegin() {
        animator.Play("StartGame");
    }

    public void OnShowDone() {
        // Pass control to action phase
        world.StartPlay();
    }

    public void OnProgress(float progress) {
        if (progress < 1.0f) {
            int percent = Mathf.RoundToInt(progress * 100.0f);
            objectiveLabel.text = "Light up all beacons\n<color=orange>" + percent + "%</color>";
        } else {
            objectiveLabel.text = "Task completed!\nProceed to the <color=orange>Teleporter</color>.";
        }
    }
} // class HUD
