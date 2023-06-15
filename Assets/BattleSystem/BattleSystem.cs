using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleSystem : MonoBehaviour
{
    // Battle Data
    [SerializeField] BattleData data;
    private Enemy enemy;
    private Player player;
    private bool playerTurn;

    // Audio 
    [SerializeField] AudioSource bgmSrc;

    // Awake is called on creation
    void Awake() {
        enemy  = new Enemy(data.hpEnemy, data.maxDmgEnemy, data.minDmgEnemy, data.attackChance);
        player = new Player(data.hpPlayer, data.maxDmgPlayer, data.minDmgPlayer, data.skillBase, data.dodgeChance); 
    }

    // Start is called before the first frame update
    void Start() {
        playerTurn = true;
    }

    // Update is called once per frame
    void Update(){}
}


// public class BattleSystemScript : MonoBehaviour
// {
//     int playerHP;
//     int pmaxHP = 20;
//     int amaxHP = 30;
//     int aiHP;
//     bool playerDefends;
//     int aiDodgeChance;
//     bool aiCharges;
//     bool playerTurn;
//     bool playerBuff;
//     bool playerParry;
//     bool aiBuff;

//     // Start is called before the first frame update
//     void Start()
//     {
//         StartGame();
//     }
//     void StartGame()
//     {
//         Debug.Log("Game Start! A) Attack | H) Heal | D) Defend | P) Parry | B) Buff");

//         playerHP = pmaxHP;
//         aiHP = amaxHP;
//         playerDefends = false;
//         playerParry = false;
//         aiCharges = false;
//         aiDodgeChance = 25;
//         playerBuff = false;
//         aiBuff = false;
//         playerTurn = true;
//         Debug.Log($"Your HP: {playerHP}  | AI HP: {aiHP} ");
//     }
//     void PlayerAction()
//     {
//         playerParry = false;
//         playerDefends = false;
//         if (Input.GetKeyDown(KeyCode.A))
//         {
//             PlayerAttacked();

//         }
//         else if (Input.GetKeyDown(KeyCode.H))
//         {
//             PlayerHeal();

//         }
//         else if (Input.GetKeyDown(KeyCode.D))
//         {
//             PlayerDefend();
//         }
//         else if (Input.GetKeyDown(KeyCode.P))
//         {
//             PlayerParry();
//         }
//         else if (Input.GetKeyDown(KeyCode.B))
//         {
//             PlayerBuff();
//         }
//         else return;
//     }
//     void AIAction()
//     {
//         aiBuff = false;
//         if (aiCharges == true)
//         {
//             Debug.Log("AI is charged!!!");
//             Debug.Log("AI Unleashes OMNISLASH!");
//             if (playerDefends == true)
//             {
//                 Debug.Log("But you Blocked it!!!");
//                 Debug.Log("The Battle Continues...");
//                 aiCharges = false;
//                 playerDefends = false;
//                 CurrentHP();
//                 playerTurn = true;
//             }
//             else
//             {
//                 Debug.Log("AI deals -9999");
//                 playerHP = 0;
//                 CurrentHP();
//             }
//         }
//         else
//         {
//             int move = Random.Range(1, 101);
//             if (move > 45)
//             {
//                 Debug.Log("AI chooses to Attack!");
//                 AIAttacked();
//                 CurrentHP();
//                 playerTurn = true;

//             }
//             else if (move <= 20)
//             {
//                 Debug.Log("AI chooses to Charge!");
//                 AICharge();
//                 CurrentHP();
//                 playerTurn = true;
//             }
//             else if (move <= 35 && move > 20)
//             {
//                 Debug.Log("AI chooses to Heal!");
//                 AIHeal();
//                 CurrentHP();
//                 playerTurn = true;
//             }
//             else if (move <= 45 && move > 35)
//             {
//                 Debug.Log("AI chooses to Buff!");
//                 AIBuff();
//                 CurrentHP();
//                 playerTurn = true;
//             }
//         }
//     }


//     void PlayerAttacked()
//     {
//         Debug.Log($"You Choose to Attack!");
//         int aiDodgeProbability = Random.Range(1, 101);
//         if (aiBuff == true) aiDodgeChance = aiDodgeChance * 2;
//         int playerAttackDmg = Random.Range(1, 5);
//         if (aiDodgeProbability < aiDodgeChance)
//         {
//             Debug.Log("The AI dodged your Attack!");
//             playerBuff = false;
//             playerTurn = false;
//         }
//         else
//         {
//             if (playerBuff == true)
//             {
//                 aiHP = aiHP - playerAttackDmg;
//                 playerHP = playerHP + playerAttackDmg;
//                 Debug.Log($"You dealt: {playerAttackDmg} DMG and healed for {playerAttackDmg} HP");
//                 playerBuff = false;
//                 playerTurn = false;
//             }
//             else if (playerBuff == false)
//             {
//                 aiHP = aiHP - playerAttackDmg;
//                 Debug.Log($"You dealt: {playerAttackDmg} DMG");
//                 playerTurn = false;
//             }
//         }
//     }
//     void AIAttacked()
//     {
//         int aiAttackDmg = Random.Range(2, 6);
//         if (playerParry == true)
//         {
//             Debug.Log("The AI Attack got parried");
//             aiHP = aiHP - (2 * aiAttackDmg);
//             Debug.Log($"AI took {2 * aiAttackDmg} DMG !");
//         }
//         else
//         {
//             playerHP = playerHP - aiAttackDmg;
//             Debug.Log($"AI knocked your HP down to {playerHP} !");
//         }
//     }
//     void PlayerHeal()
//     {
//         Debug.Log("You Choose to Heal!");
//         playerHP = playerHP + 3;
//         if (playerHP > pmaxHP)
//         {
//             playerHP = pmaxHP;
//         }
//         Debug.Log($"Your HP was restored to {playerHP} !");
//         playerTurn = false;
//     }

//     void AIHeal()
//     {
//         aiHP = aiHP + 2;
//         if (aiHP > amaxHP)
//         {
//             aiHP = amaxHP;
//         }
//     }

//     void PlayerDefend()
//     {
//         Debug.Log("You Choose to Defend!");
//         playerDefends = true;
//         playerTurn = false;
//     }

//     void PlayerBuff()
//     {
//         Debug.Log("You Choose to Buff!");
//         if (playerBuff == true)
//         {
//             Debug.Log("You're already buffed!");
//             playerTurn = false;
//         }
//         else
//         {
//             playerBuff = true;
//             playerTurn = false;
//         }
//     }

//     void AIBuff()
//     {
//         aiBuff = true;
//     }

//     void AICharge()
//     {
//         aiCharges = true;
//     }

//     void CurrentHP()
//     {
//         Debug.Log($"Your HP: {playerHP}  | AI HP: {aiHP} ");
//     }

//     void PlayerParry()
//     {
//         Debug.Log("You Choose to Parry!");
//         int ParryChance = Random.Range(1, 101);
//         if (ParryChance > 67)
//         {
//             playerParry = true;
//             playerTurn = false;
//         }
//         else if (ParryChance <= 67)
//         {
//             Debug.Log("The Parry failed!");
//             playerParry = false;
//             playerTurn = false;
//         }
//     }
//     void GameOver()
//     {
//         if (playerHP < 1)
//         {
//             int lastStandChance = Random.Range(1, 101);
//             if (lastStandChance > 80)
//             {
//                 Debug.Log("You got revived with 5 HP!");
//                 aiCharges = false;
//                 playerDefends = false;
//                 playerParry = false;
//                 playerBuff = false;
//                 playerHP = 5;
//                 CurrentHP();
//                 playerTurn = true;

//             }
//             else if (lastStandChance < 81)
//             {
//                 Debug.Log("You lose!");
//                 StartGame();

//             }

//         }

//         else if (aiHP < 1)
//         {
//             Debug.Log("You won!");
//             StartGame();
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         if (playerTurn)
//         {
//             PlayerAction();
//             GameOver();

//         }
//         else
//         {
//             AIAction();
//             GameOver();
//         }


//     }
// }