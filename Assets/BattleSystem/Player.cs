using UnityEngine;

public enum PlayerState {
    HIT,
    DEFEND,
    DOGED,
    DEAD
}

public class Player
{
    // current hitpoints of player
    private int hitpoints   = 10;

    // player cose to defend
    private bool defending  = false;

    // player will dodge the next attack
    private bool willDodge  = false;

    // range of damage the player can deal
    private int maxDmg      = 3;
    private int minDmg      = 1;

    // player skill will influence dodging chance
    private float skill     = 1.0f;

    // chance that a the player can dodge the attack
    private float dodgeThreshold = 0.55f;

    //* Constructor
    public Player(int _hitpoints, int _maxDmg, int _minDmg, float _skillBase, float _dogeChance) {
        hitpoints = _hitpoints;
        maxDmg = _maxDmg;
        minDmg = _minDmg;
        skill = _skillBase;
        dodgeThreshold = _dogeChance;
    }

    //* Calculate strength of attack and return them.
    /*
        Return:
            int: Amount of damage the enemy should take.
    */
    public int attack() {
        int dmg = Random.Range(minDmg, maxDmg);
        skill += 0.05f;
        return dmg;
    }

    //* Heal player by 3 HP
    public void heal() {
        hitpoints += 3;
        if (hitpoints >= 10)
            hitpoints = 10;
        skill += 0.02f;
    }

    //* Set defending true
    public void defend() => defending = true;

    //* Receive damage from enemy (or not)
    /*
        Arguments:
            dmg (int): Amount of hitpoints the player should loose.

        Return:
            PlayerState: Indicator if player got Hit, was Defending, 
                         was Dodging or is Dead
    */
    public PlayerState receiveDamage(int dmg) {
        PlayerState ret;
        
        calcDodge(); // maybe the player can doge
        if (willDodge)
            ret = PlayerState.DOGED;
        else if (defending)
            ret = PlayerState.DEFEND;
        else {
            hitpoints -= dmg;
            ret = PlayerState.HIT;
        }
        
        defending = false;
        willDodge = false;

        if (hitpoints <= 0)
            ret = PlayerState.DEAD;

        return ret;
    }

    //* Player has a chance to dodge attack.
    private void calcDodge() {
        if (Random.Range(0f,1f) >= (1f - dodgeThreshold * skill)) 
            willDodge = true;
        else
            willDodge = false; 
    }
}