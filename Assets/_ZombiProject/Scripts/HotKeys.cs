using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HotKeys : MonoBehaviour {

    [SerializeField]
    GameObject shop;
    bool isShopActive = false;
    bool isOptActive = false;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject opt;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.F5))
            SceneManager.LoadScene(1);

        if (Input.GetKeyDown(KeyCode.B)) //  shop
        {
            opt.SetActive(false);
            isOptActive = false;
            if (isShopActive == false)
            {
                shop.SetActive(true);
                player.SetActive(false);
            }
            if (isShopActive == true)
            {
                shop.SetActive(false);
                player.SetActive(true);
            }
        isShopActive = !isShopActive;
        }

        if (Input.GetKeyDown(KeyCode.O))  // options
        {
            shop.SetActive(false);
            isShopActive = false;
            if (isOptActive == false)
            {
                opt.SetActive(true);
                player.SetActive(false);
            }
            if (isOptActive == true)
            {
                opt.SetActive(false);
                player.SetActive(true);
            }
        isOptActive = !isOptActive;
        }

        //if (Input.GetKeyDown(KeyCode.P) && Time.timeScale != 0)
        //{
        //    Time.timeScale = 0;
        //    Debug.Log(Time.timeScale);
        //}
        //else Time.timeScale = 1;

    }
}
