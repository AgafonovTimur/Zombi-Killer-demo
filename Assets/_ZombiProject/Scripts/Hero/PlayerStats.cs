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
    public int playerHealth = 100;
    public int playerArmor = 25;
    public int bulletAmmount = 30;
    public int clipsAmmount = 10;
    public int healthPackAmmount = 2;
    public int boostAmmount = 2;
    public int grenadesAmmount = 5;
    public string message = "";
    public GameObject outOfAmmoGO;

//  UI elements
    [HideInInspector]
    public UILabel playerHealthUI;
    [HideInInspector]
    public UILabel playerArmorhUI;
    [HideInInspector]
    public UILabel playerBulletUI;
    [HideInInspector]
    public UILabel playerClipsUI;
    [HideInInspector]
    public UILabel playerHealthPackhUI;
    [HideInInspector]
    public UILabel playerBoosthUI;
    [HideInInspector]
    public UILabel playerGrenadeshUI;
    [HideInInspector]
    public UILabel playerMessageUI;
    [HideInInspector]
    public UILabel outOfAmmoUI;


    void Start () {
        playerHealthGO = GameObject.Find("playerHealthAndArmor");
        ammoGO = GameObject.Find("ammunation");
        gameObject.name = "Player";
        outOfAmmoGO = ammoGO.transform.GetChild(6).gameObject; //out of ammo
        outOfAmmoGO.SetActive(false);

//------------------------------------------------------------------------------------------------------------------------
// set UI elements labels as values
//------------------------------------------------------------------------------------------------------------------------

        playerHealthUI = playerHealthGO.transform.GetChild(1).GetComponent<UILabel>(); //hp , 125 max
        playerHealthUI.text = playerHealth.ToString();

        playerArmorhUI = playerHealthGO.transform.GetChild(3).GetComponent<UILabel>(); // armor
        playerArmorhUI.text = playerArmor.ToString();

        playerHealthPackhUI = playerHealthGO.transform.GetChild(5).GetComponent<UILabel>(); // health pack
        playerHealthPackhUI.text = healthPackAmmount.ToString();

        playerBoosthUI = playerHealthGO.transform.GetChild(7).GetComponent<UILabel>(); // boosts
        playerBoosthUI.text = boostAmmount.ToString();

        playerMessageUI = playerHealthGO.transform.GetChild(8).GetComponent<UILabel>(); // message for player
        playerMessageUI.text = message;

        playerBulletUI = ammoGO.transform.GetChild(1).GetComponent<UILabel>(); // bullets
        playerBulletUI.text = bulletAmmount.ToString();

        playerClipsUI = ammoGO.transform.GetChild(2).GetComponent<UILabel>(); //clips
        playerClipsUI.text = clipsAmmount.ToString();

        playerGrenadeshUI = ammoGO.transform.GetChild(4).GetComponent<UILabel>(); //grenades
        playerGrenadeshUI.text = grenadesAmmount.ToString();

        outOfAmmoUI = ammoGO.transform.GetChild(6).GetComponent<UILabel>(); // hide out of ammo
        outOfAmmoUI.text = "";
        //playerHealthGO.transform.GetChild(1).GetComponent<UILabel>().text = playerHealth.ToString(); //hp , 125 max
        //playerHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = playerArmor.ToString(); // armor
        //playerHealthGO.transform.GetChild(5).GetComponent<UILabel>().text = healthPackAmmount.ToString(); // health pack
        //playerHealthGO.transform.GetChild(7).GetComponent<UILabel>().text = boostAmmount.ToString(); // boosts
        //playerHealthGO.transform.GetChild(8).GetComponent<UILabel>().text = message; // message for player

        //ammoGO.transform.GetChild(1).GetComponent<UILabel>().text = bulletAmmount.ToString() ; // bullets in weapon
        //ammoGO.transform.GetChild(2).GetComponent<UILabel>().text = clipsAmmount.ToString(); //clips
        //ammoGO.transform.GetChild(4).GetComponent<UILabel>().text = grenadesAmmount.ToString(); //grenades
        //ammoGO.transform.GetChild(6).GetComponent<UILabel>().text = ""; // hide out of ammo

        ////UILabel UI_PlayerHP1 = playerHealthGO.transform.GetChild(1).GetComponent<UILabel>(); //hp , 125 max
        ////UILabel UI_PlayerArmor3 = playerHealthGO.transform.GetChild(3).GetComponent<UILabel>(); // armor
        ////UILabel UI_PlayersHealthPacks5 = playerHealthGO.transform.GetChild(5).GetComponent<UILabel>(); // health pack
        ////UILabel UI_PlayerBoosts7= playerHealthGO.transform.GetChild(7).GetComponent<UILabel>(); // boosts
        ////UILabel UI_PlayersMessage8= playerHealthGO.transform.GetChild(8).GetComponent<UILabel>(); // message for player

        ////UI_PlayerHP1.text = playerHealthF.ToString();
        ////UI_PlayerArmor3.text = playerArmorF.ToString();
        ////UI_PlayersHealthPacks5.text = healthPack.ToString();
        ////UI_PlayerBoosts7.text = boost.ToString();
        ////UI_PlayersMessage8.text = "" ;

        ////UILabel UI_Bullets1 = ammoGO.transform.GetChild(1).GetComponent<UILabel>(); // bullets in weapon
        ////UILabel UI_Clips2 = ammoGO.transform.GetChild(2).GetComponent<UILabel>(); // clips
        ////UILabel UI_Grenades4 = ammoGO.transform.GetChild(4).GetComponent<UILabel>();  //grenades
        ////UILabel IO_OutOfAmmo = ammoGO.transform.GetChild(6).GetComponent<UILabel>(); // hide out of ammo

        ////UI_Bullets1.text = bulletAmmount.ToString();
        ////UI_Clips2.text = clipsAmmount.ToString();
        ////UI_Grenades4.text = grenades.ToString();
        ////IO_OutOfAmmo.text = "";


        ////playerHealthGO.transform.GetChild(1).GetComponent<UILabel>().text ="100"; //hp , 125 max
        ////playerHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = "25"; // armor
        ////playerHealthGO.transform.GetChild(5).GetComponent<UILabel>().text = "5"; // health pack
        ////playerHealthGO.transform.GetChild(7).GetComponent<UILabel>().text = "2"; // boosts
        ////playerHealthGO.transform.GetChild(8).GetComponent<UILabel>().text = ""; // message for player
        ////ammoGO.transform.GetChild(1).GetComponent<UILabel>().text = "30"; // bullets in weapon
        ////ammoGO.transform.GetChild(2).GetComponent<UILabel>().text = "10"; // clips
        ////ammoGO.transform.GetChild(4).GetComponent<UILabel>().text = "2"; //grenades
        ////ammoGO.transform.GetChild(6).gameObject.SetActive(false); // hide out of ammo
    }

//-------------------------------------------------------------------------------------------------------------------------
// heal or damage player   // armor maybe later
//------------------------------------------------------------------------------------------------------------------------
    public void PlayerHealthChanges(int x, int y)
    {
        PlayerHealthCount(x, y);
    }
    
    void PlayerHealthCount(int x, int y)
    {
        if (x > 0)
        {
            playerHealth = playerHealth + x;

            if (playerHealth > 125)
            {
                playerHealth = 125;
                playerHealthUI.text = playerHealth.ToString();
            }
            if (playerHealth <= 125)
            {
                playerHealthUI.text = playerHealth.ToString();
            }
        }
            //heroArmorF = heroArmorF - y;
            //heroHealthGO.transform.GetChild(3).GetComponent<UILabel>().text = heroArmorF.ToString(); //armor
            //            Debug.Log("heroDamageTaken " + x);
        if (x < 0)
        {
            playerHealth = playerHealth + x;

            if (playerHealth > 0)
            {
                playerHealthUI.text = playerHealth.ToString();
            }
            if (playerHealth <= 0)
            {
                PlayerDeath();
            }
        }
        if (x == 0)  Debug.Log("health changer = 0 WTF?"); 
    }

 //--------------------------------------------------------------------------------------------------------------------------------
 // ammo usage
 //---------------------------------------------------------------------------------------------------------------------------
    
    public void AmmoConsuption(int x, int y) // send bullets , clips
    {
        if (x >= 0) // bullets
        {
            outOfAmmoGO.SetActive(false);
            playerBulletUI.text = x.ToString();
            playerClipsUI.text = y.ToString();
            clipsAmmount = y;
        }
        if (x <= 0 && y <= 0) //ammo, bullets + clips
        {
            outOfAmmoGO.SetActive(true);
            outOfAmmoUI.text = "Out Of Ammo";
        }
    }
//-------------------------------------------------------------------------------------------------------------------------------------------
//player death if health is <= 0
//--------------------------------------------------------------------------------------------------------------------------------

    private void PlayerDeath()
    {
        deathPanel.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log("death");
    }

//--------------------------------------------------------------------------------------------------------------------------------------
// messages for player during game
//-----------------------------------------------------------------------------------------------------------------------------------
    public void MessageForPlayerOne(string x) // if one message
    {
        playerMessageUI.text = x;
    }
    public void MessageForPlayerDoors(string x, int y) //if two messages
    {
        playerMessageUI.text = x + y;
    }
}
