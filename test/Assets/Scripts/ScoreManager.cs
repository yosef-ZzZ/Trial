﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle")) {
            // Increase score of 1
            score++;
            Debug.Log(score);
        }
    }
}
