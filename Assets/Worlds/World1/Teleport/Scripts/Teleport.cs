﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Interactable
{
    public void Hide() {
        gameObject.SetActive(false);
    }

    public void Show() {
        gameObject.SetActive(true);
        animator.Play("LightUp");
    }

    protected override void OnAction() {
        if (playerNearby) {
            callback.Invoke();
        }
    }
} // class Teleport
