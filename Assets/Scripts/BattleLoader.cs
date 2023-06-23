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

    private void OnTriggerEnter2D(Collider2D other) {
        battle.mapPosition = other.gameObject.transform.position;
        loadBattleSceneWith.UpdateData(battle);
        sfxSrc.PlayOneShot(battle.attackSound, 1f);
        StartCoroutine(nameof(LoadBattle));
    }

    private IEnumerator LoadBattle() {
        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "MasterVolume", 1f, 0f));
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Battle");
    }
}
