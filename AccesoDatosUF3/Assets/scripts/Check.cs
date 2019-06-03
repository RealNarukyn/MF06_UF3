using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Security.Cryptography;
using System.Data;
using Mono.Data.Sqlite;

public class Check : MonoBehaviour{
    public DB db;

    public bool checkUser() {
        bool retValue = false;
        string user = Login.username;

        if (user != null)
        {
            user = user.Trim();             // trim — Elimina espacio en blanco (u otro tipo de caracteres) 
            int user_length = user.Length;  // del inicio y el final de la cadena

            if (user_length > 2 && user_length < 12)
            {
                string query = "SELECT user FROM users WHERE user = \"" + user +"\"";
                //Debug.Log("HERE: " + query);
                try
                {
                    IDbCommand command = db.getCommand();
                    command.CommandText = query;

                    IDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string db_user = reader.GetString(0);

                        if (db_user != null)
                        {
                            retValue = true;
                        }
                    }
                    reader.Close();
                }
                catch
                {
                   Debug.Log("NO USER");
                }
            }
            else
            {
                Debug.Log("Too Short");
            }
        }
        else
        {
            Debug.Log("No user");
        } 

        return retValue;
    }

    public bool checkRegisterUser()
    {
        bool retValue = false;
        string user = Register.username;

        if (user != null)
        {
            user = user.Trim();  
            int user_length = user.Length;

            if (user_length > 2 && user_length < 12)
            {
                string query = "SELECT user FROM users WHERE user = \"" + user + "\"";
                //try
                //{
                    IDbCommand command = db.getCommand();
                    command.CommandText = query;
                    
                    IDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        if (reader.GetString(0) == null)
                        {
                            retValue = true;
                            Debug.Log("ENTRA AQUI");
                        }
                        else
                        {
                            Debug.Log("El usuario " + reader.GetString(0) + " ya existe");
                        }
                    }

                    reader.Close();
                //}
                //catch
                //{
                //    Debug.Log("NO USER");
                //}
                
            }
            else
            {
                Debug.Log("Too Short");
            }
        }
        else
        {
            Debug.Log("No user");
        }

        return retValue;
    }

    public bool checkPass()
    {
        bool retValue = false;
        string pass = Login.password;

        if (pass != null)
        {
            pass = pass.Trim();
            int pass_length = pass.Length;

            if (pass_length > 2 && pass_length < 12)
            {
                int int_pass = pass.GetHashCode();

                string query = "SELECT pass FROM users WHERE pass = " + int_pass;
                try
                {
                    IDbCommand command = db.getCommand();
                    command.CommandText = query;

                    IDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int db_pass = reader.GetInt32(0);

                        if (db_pass < 0)
                        {
                            retValue = true;
                        }
                    }
                    reader.Close();
                }
                catch
                {
                  Debug.Log("NO PASS");
                }

                retValue = true;
            }
            else
            {
                Debug.Log("Too Short");
            }
        }
        else
        {
            Debug.Log("No pass");
        }

        return retValue;
    }

    public bool checkRegisterPass()
    {
        bool retValue = false;
        string pass = Register.password;

        if (pass != null)
        {
            pass = pass.Trim();
            int pass_length = pass.Length;

            if (pass_length > 2 && pass_length < 12)
            {
                retValue = true;
            }
            else
            {
                Debug.Log("Too Short");
            }
        }
        else
        {
            Debug.Log("No pass");
        }
        return retValue;
    }
}