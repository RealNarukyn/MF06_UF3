using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User {

    int id;
    string user;

    public int GetId() { return id; }
    public string GetWeapon() { return user; }

    public User(int _id, string _user)
    {
        id = _id;
        user = _user;
    }

}
