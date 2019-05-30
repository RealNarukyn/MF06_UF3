using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Data;
using Mono.Data.Sqlite;

public class DB : MonoBehaviour{
    String db_file = "inventario";
    IDbConnection connection;
    IDbCommand command;
    IDataReader reader;

    private void Awake()
    {
        String path = "URI=file:" + Application.dataPath + "/" + db_file;

        connection = new SqliteConnection(path);

        connection.Open();

        command = connection.CreateCommand();
    }

    private void Start()
    {
        //PrintWeapons();
        //Debug.Log(GetWeapons()[0].GetId());
        //Debug.Log(GetWeapons()[0].GetWeapon());
    }

    private void PrintWeapons()
    {
        string query = "SELECT weapon FROM weapons";

        command.CommandText = query;

        reader = command.ExecuteReader();

        while (reader.Read())
        {
            string weapon = reader.GetString(0);
            Debug.Log(weapon);
        }
    }

    public List<Weapon> GetWeapons()
    {
        List<Weapon> weapons = new List<Weapon>();

        command = connection.CreateCommand();

        //string query = "SELECT id_weapon, weapon FROM weapons";
        string query = "SELECT * FROM weapons";

        command.CommandText = query;

        reader = command.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string weapon = reader.GetString(1);
            int damage = reader.GetInt32(2);


            weapons.Add(new Weapon(id, weapon, damage));
        }
        
        return weapons;
    }

    public List<User> GetUsers()
    {
        List<User> users = new List<User>();

        command = connection.CreateCommand();

        string query = "SELECT id_user, user FROM users";

        command.CommandText = query;

        reader = command.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string user = reader.GetString(1);

            users.Add(new User(id, user));
        }

        return users;
    }
}