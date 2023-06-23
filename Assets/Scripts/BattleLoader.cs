using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BattleLoader : MonoBehaviour
{
    // Battle
    [Header("Battle Information")]
    [SerializeField] BattleData battle;
    [SerializeField] BattleData loadBattleSceneWith;

    // Audio 
    [Header("Audio")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource sfxSrc;

    // Player 
    [Header("Player")]
    [SerializeField] GameObject player;

    // Input System 
    private InputActions playerControls;
    private bool enterBattle = false;

    private void Awake() => playerControls = new InputActions(); 

    private void OnEnable() {
        playerControls.Player.EnterBattle.performed += _ => enterBattle = true;
        playerControls.Player.EnterBattle.canceled += _ => enterBattle = false;

        playerControls.Enable();
    }

    void Update() {
        // Solition by: https://discussions.unity.com/t/check-if-player-is-close/69270/2
        // the player is within a radius of 2 units to this game object
        if ((player.transform.position - gameObject.transform.position).sqrMagnitude < 9 && enterBattle) {
            battle.mapPosition = player.transform.position;
            loadBattleSceneWith.UpdateData(battle);
            sfxSrc.PlayOneShot(battle.attackSound, 1f);
            StartCoroutine(nameof(LoadBattle));
        }
    }

    private IEnumerator LoadBattle() {
        var controls = player.GetComponent<TopDownPlayerController>();
        controls.playerControls.Disable();
        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "MasterVolume", 1f, 0f));
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Battle");
    }
}
