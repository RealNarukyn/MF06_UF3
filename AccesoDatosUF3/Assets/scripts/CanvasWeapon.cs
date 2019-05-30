using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CanvasWeapon : MonoBehaviour{

    // TODO: ASIGNAR EL SCRIPT DB
    public DB db;

    public Image icon;
    public Text name;
    public Text dmg;

    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void setName(string _name) {
        name.text = _name;
    }

    public void setDamage(int _dmg) {
        dmg.text = "Damage: " + _dmg.ToString();
    }
}
