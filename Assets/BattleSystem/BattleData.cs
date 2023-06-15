using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewBattleData", menuName = "Data/Battle")]
public class BattleData : ScriptableObject
{
    [Header("Scene Informtion")]
    public SpriteRenderer background;
    
    [Header("Audio")]
    public AudioClip backgroundMusic;

    [Header("Enemy")]
    public GameObject enemyPuppet; // TODO: Animation, Sound and so one
    public int hpEnemy;
    public int maxDmgEnemy;
    public int minDmgEnemy;
    [Range(0.1f, 0.9f)]
    public float attackChance;

    [Header("Player")]
    public int hpPlayer;
    public int maxDmgPlayer;
    public int minDmgPlayer;
    [Range(0.5f, 1.5f)]
    public float skillBase;
    [Range(0.1f, 0.9f)]
    public float dodgeChance;

    //* Update Battle Data -> specially for Scene creation
    public void UpdateData(BattleData newData) {
        background = newData.background;
        backgroundMusic = newData.backgroundMusic;
        enemy = newData.enemy;
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
