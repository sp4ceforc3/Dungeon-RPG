using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] TextMeshProUGUI hpText;
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

        hpText.text = $"{player.hitpoints}";
    }

    public void PlayerAttack() {

        Debug.Log("Yes!");

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

    public void PlayerDefend() {
        if (playerTurn) {
            player.Defend();

            Debug.Log("Player Defend");
        }
        playerTurn = false;
    }

    public void PlayerHeal() {
        if (playerTurn) {
            
            Debug.Log("Player heals 3!");

            player.Heal();
            sfxSrc.PlayOneShot(healSound, 1f);
        }
        playerTurn = false;
    }

    public void PlayerRun() {
        if (playerTurn) {
            sfxSrc.PlayOneShot(runSound, 1f);
            LoadDungeon();
        }
        playerTurn = false;
    }

    // Maybe some more to do 
    private void LoadDungeon() => SceneManager.LoadScene("DungeonRPG");
}