using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] BattleData battleData;

    void Awake() => player.transform.position = battleData.mapPosition;

    //! Just to test Battle Scenes -> Will be handled by Slimes
    [SerializeField] BattleData testBattle;
    void Start() { 
        battleData.UpdateData(testBattle);
        SceneManager.LoadScene("Battle");
    }
}
