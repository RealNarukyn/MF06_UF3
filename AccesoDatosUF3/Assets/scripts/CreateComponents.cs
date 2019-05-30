using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreateComponents : MonoBehaviour{

    public GameObject prebaf;
    public DB db;
    public Transform contentBox;
    public CanvasWeapon infoBox;


    List<Weapon> weapons;
    int max_weapons;

	void Start () {
        weapons = db.GetWeapons();
        max_weapons = weapons.Count();
        
        Vector3 offset = new Vector3(contentBox.transform.localPosition.x, contentBox.transform.localPosition.y + 100, contentBox.transform.localPosition.z);

        for (int i = 0; i < max_weapons; i++)
        {
            GameObject content = Instantiate(prebaf);
            content.transform.SetParent(contentBox, false);

            content.name = weapons[i].GetWeapon();
            content.transform.localPosition = offset;

            infoBox.setName(weapons[i].GetWeapon());
            infoBox.setDamage(weapons[i].GetDamage());

            offset = new Vector3(offset.x, offset.y - 60, offset.z);
            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
