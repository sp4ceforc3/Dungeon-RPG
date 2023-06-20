using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] BattleData battleData;

    void Awake() => player.transform.position = battleData.mapPosition;
}
