using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon {
    private int id;
    private string weapon;
    private int damage;

    public int GetId() { return id; }
    public string GetWeapon() { return weapon; }
    public int GetDamage() { return damage; }

    public Weapon(int _id, string _weapon, int _damage)
    {
        id = _id;
        weapon = _weapon;
        damage = _damage;
    }
}
