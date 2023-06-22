using UnityEngine;

public class Enemy
{
    // current hitpoints of enemy
    private int hitpoints = 10;

    // range of damage the enemy can deal
    private int maxDmg    = 4;
    private int minDmg    = 2;

    // percentage of propability to attack (instead of charging)
    private float attackChance = 0.65f;

    // indicates the the enemy was charging for a super attack
    private bool charging = false;

    //* Constructor
    public Enemy(int _hitpoints, int _maxDmg, int _minDmg, float _attackChance) {
        hitpoints = _hitpoints;
        maxDmg = _maxDmg;
        minDmg = _minDmg;
        attackChance = _attackChance;
    }
    
    //* Caculate chance for an attack or charging.
    /*
        Returns:
            int: Amount of damage the enemy will deal.
                 A negative value indicates charging for next round.
    */
    public int Attack() {
        int dmg = -1;
        if (Random.Range(0f,1f) <= attackChance || charging) {
            // set damage the player will take if not defending
            dmg = Random.Range(minDmg, maxDmg);
            if (charging)
                dmg = 999; // instantly kill player
            charging = false; // reset charging of last round
        } else
            charging = true;
        return dmg;
    }

    //* Receive Damage / Kind of Setter for Enemy's hitpoints
    /*
        Returns:
            bool: Is the enemy dead or not. True -> Enemy is dead.
    */
    public bool ReceiveDamage(int dmg) {
        hitpoints -= dmg;
        return hitpoints <= 0;
    }
}
