using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyHolder : MonoBehaviour
{
    private int _difficulty = 1;

    private void Awake()
    {
        
    }

    private void AddDifficulty()
    {
        _difficulty++;
    }
}
