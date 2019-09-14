using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour {

    //[SerializeField]
    GameObject playerHealthGO;
    //[SerializeField]
    GameObject ammoGO;
    [SerializeField]
    GameObject deathPanel;
    public int playerHealthF = 100;
    public int playerArmorF = 25;
    public int bulletAmmount = 30;
    public int clipsAmmount = 10;
    public int healthPackAmmount = 2;
    public int boostAmmount = 2;
    public int grenadesAmmount = 5;
    public string message = "";


    void Start () {
        playerHealthGO = GameObject.Find("playerHealthAndArmor");
        ammoGO = GameObject.Find("ammunation");
        gameObject.name = "Player";


        playerHealthGO.transform.GetChild(1).GetComponent<UILabel>().text = playerHealthF.ToString(); //hp , 125 max
        playerHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = playerArmorF.ToString(); // armor
        playerHealthGO.transform.GetChild(5).GetComponent<UILabel>().text = healthPackAmmount.ToString(); // health pack
        playerHealthGO.transform.GetChild(7).GetComponent<UILabel>().text = boostAmmount.ToString(); // boosts
        playerHealthGO.transform.GetChild(8).GetComponent<UILabel>().text = message; // message for player

        ammoGO.transform.GetChild(1).GetComponent<UILabel>().text = bulletAmmount.ToString() ; // bullets in weapon
        ammoGO.transform.GetChild(2).GetComponent<UILabel>().text = clipsAmmount.ToString(); //clips
        ammoGO.transform.GetChild(4).GetComponent<UILabel>().text = grenadesAmmount.ToString(); //grenades
        ammoGO.transform.GetChild(6).GetComponent<UILabel>().text = ""; // hide out of ammo


        //UILabel UI_PlayerHP1 = playerHealthGO.transform.GetChild(1).GetComponent<UILabel>(); //hp , 125 max
        //UILabel UI_PlayerArmor3 = playerHealthGO.transform.GetChild(3).GetComponent<UILabel>(); // armor
        //UILabel UI_PlayersHealthPacks5 = playerHealthGO.transform.GetChild(5).GetComponent<UILabel>(); // health pack
        //UILabel UI_PlayerBoosts7= playerHealthGO.transform.GetChild(7).GetComponent<UILabel>(); // boosts
        //UILabel UI_PlayersMessage8= playerHealthGO.transform.GetChild(8).GetComponent<UILabel>(); // message for player

        //UI_PlayerHP1.text = playerHealthF.ToString();
        //UI_PlayerArmor3.text = playerArmorF.ToString();
        //UI_PlayersHealthPacks5.text = healthPack.ToString();
        //UI_PlayerBoosts7.text = boost.ToString();
        //UI_PlayersMessage8.text = "" ;

        //UILabel UI_Bullets1 = ammoGO.transform.GetChild(1).GetComponent<UILabel>(); // bullets in weapon
        //UILabel UI_Clips2 = ammoGO.transform.GetChild(2).GetComponent<UILabel>(); // clips
        //UILabel UI_Grenades4 = ammoGO.transform.GetChild(4).GetComponent<UILabel>();  //grenades
        //UILabel IO_OutOfAmmo = ammoGO.transform.GetChild(6).GetComponent<UILabel>(); // hide out of ammo

        //UI_Bullets1.text = bulletAmmount.ToString();
        //UI_Clips2.text = clipsAmmount.ToString();
        //UI_Grenades4.text = grenades.ToString();
        //IO_OutOfAmmo.text = "";


        //playerHealthGO.transform.GetChild(1).GetComponent<UILabel>().text ="100"; //hp , 125 max
        //playerHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = "25"; // armor
        //playerHealthGO.transform.GetChild(5).GetComponent<UILabel>().text = "5"; // health pack
        //playerHealthGO.transform.GetChild(7).GetComponent<UILabel>().text = "2"; // boosts
        //playerHealthGO.transform.GetChild(8).GetComponent<UILabel>().text = ""; // message for player
        //ammoGO.transform.GetChild(1).GetComponent<UILabel>().text = "30"; // bullets in weapon
        //ammoGO.transform.GetChild(2).GetComponent<UILabel>().text = "10"; // clips
        //ammoGO.transform.GetChild(4).GetComponent<UILabel>().text = "2"; //grenades
        //ammoGO.transform.GetChild(6).gameObject.SetActive(false); // hide out of ammo

    }

    public int PlayerHealed(int x, int y) // healed by pick ups
    {
        Debug.Log("x = " + x);
        if (x > 0)
        {
            playerHealthF = x;
            playerHealthF.ToString(); //hp
            playerHealthGO.transform.GetChild(1).GetComponent<UILabel>().text = playerHealthF.ToString();
            //heroArmorF = heroArmorF - y;
            //heroHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = heroArmorF.ToString(); //armor
            // Debug.Log("heroDamageTaken " + heroHealthF + " armor " + heroArmorF);
        }
        if (x <= 0)
            PlayerDeath();
        return x;
    }
    public int PlayerHitted(int x, int y) // hitted by enemy
    {
        if (playerHealthF > 0)
        {
            playerHealthF = playerHealthF - x;
            playerHealthF.ToString(); //hp
            playerHealthGO.transform.GetChild(1).GetComponent<UILabel>().text = playerHealthF.ToString();
            //heroArmorF = heroArmorF - y;
            //heroHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = heroArmorF.ToString(); //armor
//            Debug.Log("heroDamageTaken " + x);
        }
        if (playerHealthF <= 0)
        {
            PlayerDeath();
        }
            return x;
    }
    public void AmmoConsuption(int x, int y) // send bullets , clips
    {
        if (x >= 0) // bullets
        {
            ammoGO.transform.GetChild(6).gameObject.SetActive(false); //out of ammo
            ammoGO.transform.GetChild(2).GetComponent<UILabel>().text = y.ToString();
            ammoGO.transform.GetChild(1).GetComponent<UILabel>().text = x.ToString();
            clipsAmmount = y;
        }
        if (x <= 0 && y <= 0) //ammo, bullets
        {
            ammoGO.transform.GetChild(6).gameObject.SetActive(true);
            ammoGO.transform.GetChild(6).GetComponent<UILabel>().text = "Out Of Ammo";
        }
    }

    private void PlayerDeath()
    {
        deathPanel.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log("death");
    }
    public void MessageForPlayerOne(string x)
    {
        playerHealthGO.transform.GetChild(8).GetComponent<UILabel>().text = x;
    }
    public void MessageForPlayerDoors(string x, int y)
    {
        playerHealthGO.transform.GetChild(8).GetComponent<UILabel>().text = x + y;
    }
}
