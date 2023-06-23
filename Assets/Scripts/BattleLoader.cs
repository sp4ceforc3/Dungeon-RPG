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

    // Input System 
    private InputActions playerControls;
    private bool enterBattle = false;

    private void Awake() => playerControls = new InputActions(); 

    private void OnEnable() {
        playerControls.Player.EnterBattle.performed += _ => enterBattle = true;
        playerControls.Player.EnterBattle.canceled += _ => enterBattle = false;

        playerControls.Enable();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // TODO: Detection is still a bit buggy
        if (enterBattle) {
            battle.mapPosition = other.gameObject.transform.position;
            loadBattleSceneWith.UpdateData(battle);
            sfxSrc.PlayOneShot(battle.attackSound, 1f);
            StartCoroutine(nameof(LoadBattle));
        }
    }

    private IEnumerator LoadBattle() {
        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "MasterVolume", 1f, 0f));
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Battle");
    }
}
