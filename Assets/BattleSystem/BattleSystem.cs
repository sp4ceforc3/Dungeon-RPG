using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BattleSystem : MonoBehaviour
{
    // Battle Data
    [SerializeField] BattleData data;
    private Enemy enemy;
    private Player player;
    private bool playerTurn;
    private bool godmode = false;
    private bool game = true;

    // UI
    [SerializeField] SpriteRenderer bgm;
    [SerializeField] TextMeshProUGUI hpText;
    private Animator anim;

    // Audio 
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource bgmSrc;
    [SerializeField] AudioSource sfxSrc;

    // Input System to control the battle
    private BattleControls battleControls;

    // Enble input manager when object is enabled
    private void OnEnable() {
        battleControls.Battle.Attack.performed += _ => { PlayerAttack(); };
        battleControls.Battle.Defend.performed += _ => { PlayerDefend(); };
        battleControls.Battle.Heal.performed += _ => { PlayerHeal(); };
        battleControls.Battle.Run.performed += _ => { PlayerRun(); };
        battleControls.Battle.Godmode.performed += _ => { godmode = !godmode; };

        battleControls.Enable();
    }

    // Disable input manager when object is disabled
    private void OnDisable() => battleControls.Disable();

    // Awake is called on creation
    void Awake() {
        enemy  = new Enemy(data.hpEnemy, data.maxDmgEnemy, data.minDmgEnemy, data.attackChance);
        player = new Player(data.hpPlayer, data.maxDmgPlayer, data.minDmgPlayer, data.skillBase, data.dodgeChance);
        battleControls = new BattleControls(); 
        bgm.sprite = data.background;

        // spawning puppet
        Vector2 spawnPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        GameObject puppet = Instantiate(data.enemyPuppet, spawnPos, Quaternion.identity);
        anim = puppet.GetComponent<Animator>();

        hpText.text = $"{player.hitpoints}";

        bgmSrc.clip = data.backgroundMusic;
        bgmSrc.mute = false;
        bgmSrc.Play();

        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "MasterVolume", 2f, 1));
    }

    // Start is called before the first frame update
    void Start() => playerTurn = true;

    // Update is called once per frame
    void Update() {
        if (!playerTurn && game) {
            int dmg = enemy.Attack();
            if (dmg < 0)
                Debug.Log($"Enemy is charging!");
            else {
                if (dmg > data.maxDmgEnemy)
                    anim.SetTrigger("ChargeAttack");
                else 
                    anim.SetTrigger("Attack");
                Debug.Log($"Enemy attack with {dmg}!");

                PlayerState state = player.ReceiveDamage(dmg);
                if (state == PlayerState.DEAD && !godmode) {
                    sfxSrc.PlayOneShot(data.looseSound);
                    Debug.Log("Player loose battle...");
                    game = false;
                    StartCoroutine(nameof(LoadDungeon));
                }
                else if (state == PlayerState.DOGED) Debug.Log("Player doged attack!");
                else if (state == PlayerState.DEFEND) Debug.Log("Player defended attack!");
            }

            playerTurn = true;
        }

        hpText.text = $"{player.hitpoints}";
    }

    public void PlayerAttack() {
        if (playerTurn) {
            int dmg = player.Attack();
            sfxSrc.PlayOneShot(data.attackSound);

            Debug.Log($"Player attacks with {dmg}!");

            if (enemy.ReceiveDamage(dmg)) {
                sfxSrc.PlayOneShot(data.winningSound, 1f);
                Debug.Log("Player won battle!");
                game = false;
                StartCoroutine(nameof(LoadDungeon));
            }
        }
        playerTurn = false;
    }

    public void PlayerDefend() {
        if (playerTurn) {
            player.Defend();
            Debug.Log("Player Defend");
        }
        playerTurn = false;
    }

    public void PlayerHeal() {
        if (playerTurn) {
            player.Heal();
            sfxSrc.PlayOneShot(data.healSound, 1f);
            Debug.Log("Player heals 3!");
        }
        playerTurn = false;
    }

    public void PlayerRun() {
        if (playerTurn) {
            sfxSrc.PlayOneShot(data.runSound, 1f);
            StartCoroutine(nameof(LoadDungeon));
        }
    }

    private IEnumerator LoadDungeon() {
        bgmSrc.mute = true;
        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "MasterVolume", 1f, 0f));
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("DungeonRPG");
    }   
}