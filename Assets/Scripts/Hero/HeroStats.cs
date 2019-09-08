using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour{

    [SerializeField]
    GameObject heroHealthGO;
    [SerializeField]
    GameObject ammoGO;
    public int heroHealthF = 100;
//    string heroHealthS;
    public int heroArmorF = 25;
 //   string heroArmorS;
    public int bulletAmmount = 30;
  //  string bulletAmmountS;
    public int clipsAmmount = 10;
  //  string clipsAmmountS;
    public int healthPack = 2;
  //  string healthPackS;
    public int grenades = 5;
   // string grenadesS;



    void Start () {
        heroHealthGO = GameObject.Find("heroHealthAndArmor");
        ammoGO = GameObject.Find("ammunation");
        heroHealthGO.transform.GetChild(1).GetComponent<UILabel>().text = "100"; //hp , 125 max
        heroHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = "25"; // armor
        heroHealthGO.transform.GetChild(5).GetComponent<UILabel>().text = "5"; // health pack
        heroHealthGO.transform.GetChild(7).GetComponent<UILabel>().text = "2"; // boosts
        ammoGO.transform.GetChild(1).GetComponent<UILabel>().text = "30"; // bullets in weapon
        ammoGO.transform.GetChild(2).GetComponent<UILabel>().text = "10"; // clips
        ammoGO.transform.GetChild(4).GetComponent<UILabel>().text = "2"; //grenades
        ammoGO.transform.GetChild(6).gameObject.SetActive(false); // hide out of ammo

    }

    public int HeroHealed(int x, int y) // healed by pick ups
    {
        Debug.Log("x = " + x);
        if (x > 0)
        {
            heroHealthF = x;
     //       Debug.Log("?" + heroHealthF);
            heroHealthF.ToString(); //hp
            heroHealthGO.transform.GetChild(1).GetComponent<UILabel>().text = heroHealthF.ToString();
            //heroArmorF = heroArmorF - y;
            //heroHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = heroArmorF.ToString(); //armor
   //         Debug.Log("heroDamageTaken " + heroHealthF + " armor " + heroArmorF);
        }
        if (x <= 0)
            HeroDeath();
        return x;
    }
    public int HeroHitted(int x, int y) // hitted by enemy
    {
        Debug.Log("x = " + x);
        if (x > 0)
        {
            heroHealthF = heroHealthF - x;
       //     Debug.Log("&" + heroHealthF);
            heroHealthF.ToString(); //hp
            heroHealthGO.transform.GetChild(1).GetComponent<UILabel>().text = heroHealthF.ToString();
            //heroArmorF = heroArmorF - y;
            //heroHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = heroArmorF.ToString(); //armor
     //       Debug.Log("heroDamageTaken " + x + " armor " + heroArmorF);
        }
        if (x <= 0)
            HeroDeath();
        return x;
    }
    public void AmmoConsuption(int x, int y) // send bullets , clips
    {
        Debug.Log("y " + y);
        if (x >= 0) // bullets
        {
            ammoGO.transform.GetChild(6).gameObject.SetActive(false); //out of ammo
            ammoGO.transform.GetChild(2).GetComponent<UILabel>().text = y.ToString();
            ammoGO.transform.GetChild(1).GetComponent<UILabel>().text = x.ToString();
            clipsAmmount = y;
            Debug.Log("ammo consumption " + x + " " + y +" "+ clipsAmmount);
        }
        if (x <= 0 && y <= 0) //ammo, bullets
        {
            ammoGO.transform.GetChild(6).gameObject.SetActive(true);
            ammoGO.transform.GetChild(6).GetComponent<UILabel>().text = "Out Of Ammo";
        }
    }
    //public void clipsAmmountTotal(int x)
    //{

    //    Debug.Log("clips ammount total " + x);
    //}

    private void HeroDeath()
    {
      //  Debug.Log("death");
        Transform t = gameObject.GetComponent<Transform>();
  //      t.gameObject.SetActive(false);
    }
}
