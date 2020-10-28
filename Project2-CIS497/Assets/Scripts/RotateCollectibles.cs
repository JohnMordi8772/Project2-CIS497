﻿/*
 * Name: George Tang
 * Project Dream
 * Purpose: allows collectibles to rotate attach to collectible
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCollectibles : MonoBehaviour
{
    private bool triggered = false;
    public float speed = 5;
    public Vector3 rotateDirection;

    void Update()
    {
        transform.Rotate(rotateDirection * speed * Time.deltaTime);
    }
}
