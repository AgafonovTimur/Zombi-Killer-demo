using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    //[SerializeField]
    GameObject playerHealthGO;
    //[SerializeField]
    GameObject ammoGO;
    [SerializeField]
    GameObject deathPanel;
    public int playerHealthF = 100;
//    string heroHealthS;
    public int playerArmorF = 25;
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
        playerHealthGO = GameObject.Find("playerHealthAndArmor");
        ammoGO = GameObject.Find("ammunation");
        playerHealthGO.transform.GetChild(1).GetComponent<UILabel>().text ="100"; //hp , 125 max
        playerHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = "25"; // armor
        playerHealthGO.transform.GetChild(5).GetComponent<UILabel>().text = "5"; // health pack
        playerHealthGO.transform.GetChild(7).GetComponent<UILabel>().text = "2"; // boosts
        playerHealthGO.transform.GetChild(8).GetComponent<UILabel>().text = ""; // message for player
        ammoGO.transform.GetChild(1).GetComponent<UILabel>().text = "30"; // bullets in weapon
        ammoGO.transform.GetChild(2).GetComponent<UILabel>().text = "10"; // clips
        ammoGO.transform.GetChild(4).GetComponent<UILabel>().text = "2"; //grenades
        ammoGO.transform.GetChild(6).gameObject.SetActive(false); // hide out of ammo
        gameObject.name = "Player";
    }

    public int PlayerHealed(int x, int y) // healed by pick ups
    {
        Debug.Log("x = " + x);
        if (x > 0)
        {
            playerHealthF = x;
            //       Debug.Log("?" + heroHealthF);
            playerHealthF.ToString(); //hp
            playerHealthGO.transform.GetChild(1).GetComponent<UILabel>().text = playerHealthF.ToString();
            //heroArmorF = heroArmorF - y;
            //heroHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = heroArmorF.ToString(); //armor
   //         Debug.Log("heroDamageTaken " + heroHealthF + " armor " + heroArmorF);
        }
        if (x <= 0)
            PlayerDeath();
        return x;
    }
    public int PlayerHitted(int x, int y) // hitted by enemy
    {
        Debug.Log("x = " + x);
        if (playerHealthF > 0)
        {
            playerHealthF = playerHealthF - x;
            //     Debug.Log("&" + heroHealthF);
            playerHealthF.ToString(); //hp
            playerHealthGO.transform.GetChild(1).GetComponent<UILabel>().text = playerHealthF.ToString();
            //heroArmorF = heroArmorF - y;
            //heroHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = heroArmorF.ToString(); //armor
            Debug.Log("heroDamageTaken " + x);
        }
        if (playerHealthF <= 0)
        {
            PlayerDeath();
        }
            return x;
    }
    public void AmmoConsuption(int x, int y) // send bullets , clips
    {
 //       Debug.Log("y " + y);
        if (x >= 0) // bullets
        {
            ammoGO.transform.GetChild(6).gameObject.SetActive(false); //out of ammo
            ammoGO.transform.GetChild(2).GetComponent<UILabel>().text = y.ToString();
            ammoGO.transform.GetChild(1).GetComponent<UILabel>().text = x.ToString();
            clipsAmmount = y;
  //          Debug.Log("ammo consumption " + x + " " + y +" "+ clipsAmmount);
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

    private void PlayerDeath()
    {
        deathPanel.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log("death");
        //      Transform t = gameObject.GetComponent<Transform>();
        //      t.gameObject.SetActive(false);
    }
    public void MessageForPlayerMeth (string x)
    {
        playerHealthGO.transform.GetChild(8).GetComponent<UILabel>().text = x;
    }
}
