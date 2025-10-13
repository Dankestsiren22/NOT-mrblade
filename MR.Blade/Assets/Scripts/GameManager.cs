using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    //Reggy health bars
    GameObject ST1HealthParent;
    GameObject ST2HealthParent;
    Reggy Reggy;
    Image ST1P1Health;
    Image ST1P2Health;
    Image ST2Health;
    //ammo
    Rifle rifle;
    TextMeshProUGUI Ammo;
    
    //player health
    PlayerController player;
    Image healthbar;
    //pause menu
    GameObject pauseMenu;
    public bool ispaused = false;
    //---------------------------------------------------------------------
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            //ammo
            rifle = GameObject.FindGameObjectWithTag("weapon").GetComponent<Rifle>();
            Ammo = GameObject.FindGameObjectWithTag("Ammont").GetComponent<TextMeshProUGUI>();

            //reggy health bars
            Reggy = GameObject.FindGameObjectWithTag("Reggy").GetComponent<Reggy>();
            ST1HealthParent = GameObject.FindGameObjectWithTag("ST1HealthParent");
            ST1P1Health = GameObject.FindGameObjectWithTag("ST1P1Health").GetComponent<Image>();
            ST1P2Health = GameObject.FindGameObjectWithTag("ST1P2Health").GetComponent<Image>();
            ST2HealthParent = GameObject.FindGameObjectWithTag("ST2HealthParent");
            ST2Health = GameObject.FindGameObjectWithTag("ST2Health").GetComponent<Image>();
            //reggy health false
            ST1HealthParent.SetActive(false);
            ST2HealthParent.SetActive(false);

            //player health
            player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerController>();
            healthbar = GameObject.FindGameObjectWithTag("UI_health").GetComponent<Image>();

            //pause menu
            pauseMenu = GameObject.FindGameObjectWithTag("PAUSE");
            pauseMenu.SetActive(false);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //player health
	    healthbar.fillAmount = (float)player.health / (float)player.maxHealth;

        //reggy Health bar Functions
        ST1P1Health.fillAmount = (float)Reggy.ST1P1Health / (float)Reggy.ST1P1MaxHealth;
        ST1P2Health.fillAmount = (float)Reggy.ST1P2Health / (float)Reggy.ST1P2MaxHealth;

        // reggy health bar if statments
        if (Reggy.St1P1 == true)
        {
            ST1HealthParent.SetActive(true);
            ST1P1Health.fillAmount = (float)Reggy.ST1P1Health / (float)Reggy.ST1P1MaxHealth;
            ST1P2Health.fillAmount = (float)Reggy.ST1P2Health / (float)Reggy.ST1P2MaxHealth;
        }
        if(Reggy.St1P2 == true)
        {
            ST1HealthParent.SetActive(true);
            ST1P1Health.fillAmount = (float)Reggy.ST1P1Health / (float)Reggy.ST1P1MaxHealth;
            ST1P2Health.fillAmount = (float)Reggy.ST1P2Health / (float)Reggy.ST1P2MaxHealth;
        }

        if (Reggy.St2 == true)
        {
            ST1HealthParent.SetActive(false);
            ST2HealthParent.SetActive(true);
            ST2Health.fillAmount = (float)Reggy.ST2Health / (float)Reggy.ST2HealthMax;
        }
        //ammo
        Ammo.text = rifle.clip + "/" + rifle.clipSize;
    }

    public void Pause()
    {
        if (!ispaused)
        {
            ispaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
            Resume();
    }

    public void Quitgame()
    {
        Application.Quit();
    }

    public void LoadLevel(int Level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Level);
    }

    public void MainMenu()
    {
        LoadLevel(0);
    }
    public void Resume()
    {

        if (ispaused)
        {
            ispaused = false;

            pauseMenu.SetActive(false);

            Time.timeScale = 1;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;


        }





    }
}
