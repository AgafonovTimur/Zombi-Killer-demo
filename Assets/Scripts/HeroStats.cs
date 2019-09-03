using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour{

    [SerializeField]
    GameObject heroHealthGO;
    [SerializeField]
    GameObject ammoGO;
    public float heroHealthF = 100;
//    string heroHealthS;
    public float heroArmorF = 25;
 //   string heroArmorS;
    int bulletAmmount = 30;
  //  string bulletAmmountS;
    int clipsAmmount = 5;
  //  string clipsAmmountS;
    int healthPack = 2;
  //  string healthPackS;
    int grenades = 5;
   // string grenadesS;



    void Start () {
        heroHealthGO = GameObject.Find("heroHealthAndArmor");
        ammoGO = GameObject.Find("ammunation");
        heroHealthGO.transform.GetChild(1).GetComponent<UILabel>().text = "100"; //hp
        heroHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = "25"; // armor
        heroHealthGO.transform.GetChild(5).GetComponent<UILabel>().text = "5"; // health pack
        heroHealthGO.transform.GetChild(7).GetComponent<UILabel>().text = "2"; // boosts
        ammoGO.transform.GetChild(1).GetComponent<UILabel>().text = "30"; // bullets in weapon
        ammoGO.transform.GetChild(2).GetComponent<UILabel>().text = "5"; // clips
        ammoGO.transform.GetChild(4).GetComponent<UILabel>().text = "2"; //grenades

    }

    public void HeroHitted(int x, int y)
    {
        heroHealthF = heroHealthF - x;
        heroHealthF.ToString(); //hp
        //heroArmorF = heroArmorF - y;
        //heroHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = heroArmorF.ToString(); //armor
        Debug.Log("heroDamageTaken " + heroHealthF + " armor " + heroArmorF);
        if (heroHealthF <= 0)
            HeroDeath();
    }
    public void AmmoConsuption(int x) // send bullets ammount
    {

        if (x >= 0)
        {
            ammoGO.transform.GetChild(1).GetComponent<UILabel>().text = x.ToString();
            Debug.Log("bullets " + x);
        }
        
    }



    private void HeroDeath()
    {
        Debug.Log("death");
       // CharacterController a = gameObject.GetComponent<CharacterController>();
        Transform t = gameObject.GetComponent<Transform>();
  //      t.gameObject.SetActive(false);
    }
}
