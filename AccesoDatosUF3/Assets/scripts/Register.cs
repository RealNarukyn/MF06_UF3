using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour {
    Check check;

    public DB db;
    public Text user_txt;
    public Text pass_txt;

    public static string username;
    public static string password;

    string query;

    // Use this for initialization
    void Start () {
        check = GetComponent<Check>();
    }

    public void addUser()
    {
        username = user_txt.GetComponent<Text>().text;
        password = pass_txt.GetComponent<Text>().text;

        if (check.checkRegisterUser() && check.checkRegisterPass())
        {
            query = "INSERT INTO users (user, pass) VALUES (\"" + username + "\", " + password.GetHashCode() + ")"; 
            Debug.Log("query: " + query);   

            IDbCommand command = db.getCommand();
            command.CommandText = query;

            command.ExecuteNonQuery();
        }
    }

}
