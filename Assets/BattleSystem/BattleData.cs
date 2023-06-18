using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewBattleData", menuName = "Data/Battle")]
public class BattleData : ScriptableObject
{
    [Header("Scene Informtion")]
    public Sprite background;
    
    [Header("Audio")]
    public AudioClip backgroundMusic;

    [Header("Enemy")]
    public GameObject enemyPuppet; // TODO: Animation, Sound and so one
    public int hpEnemy = 10;
    public int maxDmgEnemy = 4;
    public int minDmgEnemy = 2;
    [Range(0.1f, 0.9f)]
    public float attackChance = 0.65f;

    [Header("Player")]
    public int hpPlayer = 10;
    public int maxDmgPlayer = 3;
    public int minDmgPlayer = 1;
    [Range(0.5f, 1.5f)]
    public float skillBase = 1.0f;
    [Range(0.1f, 0.9f)]
    public float dodgeChance = 0.45f;

    //* Update Battle Data -> specially for Scene creation
    public void UpdateData(BattleData newData) {
        background = newData.background;
        backgroundMusic = newData.backgroundMusic;
        enemyPuppet = newData.enemyPuppet;
        hpEnemy = newData.hpEnemy;
        maxDmgEnemy = newData.maxDmgEnemy;
        minDmgEnemy = newData.minDmgEnemy;
        attackChance = newData.attackChance;
        hpPlayer = newData.hpPlayer;
        maxDmgPlayer = newData.maxDmgPlayer;
        minDmgPlayer = newData.minDmgPlayer;
        skillBase = newData.skillBase;
        dodgeChance = newData.dodgeChance;
    }
}
