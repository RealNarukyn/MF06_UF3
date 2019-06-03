using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {
    Check check;
    

    public Text user_txt;
    public Text pass_txt;

    public static string username;
    public static string password;

    string query;

    private void Start()
    {
        check = GetComponent<Check>();
    }

    public void setUser() {
        username = user_txt.GetComponent<Text>().text;
        password = pass_txt.GetComponent<Text>().text;

        if (check.checkUser() && check.checkPass())
        {
            Debug.Log("USER & PASS OK");
            this.gameObject.SetActive(false);
        }
    }             
}