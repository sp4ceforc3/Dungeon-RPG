using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewBattleData", menuName = "Data/Battle")]
public class BattleData : ScriptableObject
{
    [Header("Scene Informtion")]
    public Sprite background;
    public Vector3 mapPosition = new Vector3(-4.802314f, -0.4831889f, 1.757211f);
    
    [Header("Audio")]
    public AudioClip backgroundMusic;
    public AudioClip attackSound;
    public AudioClip runSound;
    public AudioClip healSound;
    public AudioClip looseSound;
    public AudioClip winningSound;

    [Header("Enemy")]
    public GameObject enemyPuppet;
    [Range(5, 15)]
    public int hpEnemy = 10;
    [Range(2, 5)]
    public int maxDmgEnemy = 4;
    [Range(1, 3)]
    public int minDmgEnemy = 2;
    [Range(0.1f, 0.9f)]
    public float attackChance = 0.85f;

    [Header("Player")]
    [Range(5, 15)]
    public int hpPlayer = 10;
    [Range(2, 4)]
    public int maxDmgPlayer = 3;
    [Range(0, 2)]
    public int minDmgPlayer = 1;
    [Range(0.5f, 1.5f)]
    public float skillBase = 1.0f;
    [Range(0.1f, 0.9f)]
    public float dodgeChance = 0.1f;

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
        mapPosition = newData.mapPosition;
    }

    //* Reset Data to default values
    public void ResetData() {
        BattleData defaults = new BattleData();
        UpdateData(defaults);
    }
}
