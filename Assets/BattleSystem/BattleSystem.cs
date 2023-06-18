using UnityEngine;
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

    // UI
    [SerializeField] SpriteRenderer bgm;
    private Animator anim;

    // Audio 
    [SerializeField] AudioSource bgmSrc;
    [SerializeField] AudioSource sfxSrc;
    [SerializeField] AudioClip runSound;
    [SerializeField] AudioClip healSound;
    [SerializeField] AudioClip looseSound;
    [SerializeField] AudioClip winningSound;

    // Input System to control the battle
    private BattleControls battleControls;

    // Enble input manager when object is enabled
    private void OnEnable() {
        battleControls.Battle.Attack.performed += PlayerAttack;
        battleControls.Battle.Defend.performed += PlayerDefend;
        battleControls.Battle.Heal.performed += PlayerHeal;
        battleControls.Battle.Run.performed += PlayerRun;
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

        bgmSrc.clip = data.backgroundMusic;
        bgmSrc.Play();
    }

    // Start is called before the first frame update
    void Start() {
        playerTurn = true;
    }

    // Update is called once per frame
    void Update() {
        if (!playerTurn) {
            int dmg = enemy.Attack();
            if (dmg > data.maxDmgEnemy)
                anim.SetTrigger("ChargeAttack");
            else
                anim.SetTrigger("Attack");

            Debug.Log($"Enemy attack with {dmg}!");

            PlayerState state = player.ReceiveDamage(dmg);
            if (state == PlayerState.DEAD && !godmode) {
                sfxSrc.PlayOneShot(looseSound);
                LoadDungeon();
            }

            playerTurn = true;
        }
    }

    private void PlayerAttack(InputAction.CallbackContext _) {
        if (playerTurn) {
            int dmg = player.Attack();

            Debug.Log($"Player attacks with {dmg}!");

            if (enemy.ReceiveDamage(dmg)) {
                sfxSrc.PlayOneShot(winningSound, 1f);
                LoadDungeon();
            }
        }
        playerTurn = false;
    }

    private void PlayerDefend(InputAction.CallbackContext _) {
        if (playerTurn) {
            player.Defend();

            Debug.Log("Player Defend");
        }
        playerTurn = false;
    }

    private void PlayerHeal(InputAction.CallbackContext _) {
        if (playerTurn) {
            
            Debug.Log("Player heals 3!");

            player.Heal();
            sfxSrc.PlayOneShot(healSound, 1f);
        }
        playerTurn = false;
    }

    private void PlayerRun(InputAction.CallbackContext _) {
        if (playerTurn) {
            sfxSrc.PlayOneShot(runSound, 1f);
            LoadDungeon();
        }
        playerTurn = false;
    }

    // Maybe some more to do 
    private void LoadDungeon() => SceneManager.LoadScene("DungeonRPG");
}