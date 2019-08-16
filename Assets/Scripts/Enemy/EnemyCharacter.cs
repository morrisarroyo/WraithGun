using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyCharacter : ScriptableObject
{
    [SerializeField]
    private int killScore;
    public int KillScore => killScore;
}

