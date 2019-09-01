using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour{

    
    public float heroHealthF =100;
    [SerializeField]
    GameObject heroHealthGO;
    public float heroArmorF = 25;
    [SerializeField]
    GameObject heroArmorGO;
    [SerializeField]
    GameObject bulletAmmountGO;
    [SerializeField]
    GameObject clipsAmmountGO;
    int bulletAmmount = 30;
    int clipsAmmount = 5;
    

	void Start () {
        heroHealthGO.GetComponent<UILabel>().text = "100";
        heroArmorGO.GetComponent<UILabel>().text = "25";
        bulletAmmountGO.GetComponent<UILabel>().text = "30";
        clipsAmmountGO.GetComponent<UILabel>().text = "5";
    }
	
    public float HeroHitted(int x)
    {
        Debug.Log("HeroHitted = " + x);
        heroDamageTaken(x);
        return x;
    }

    public void heroDamageTaken(float t)
    {
        heroHealthF = heroHealthF - 10;
        heroHealthGO.GetComponent<UILabel>().text = heroHealthF.ToString();
        Debug.Log("heroDamageTaken " + t);
    }

}
