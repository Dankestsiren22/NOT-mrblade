using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    PlayerController player;
    Reggy Reggy;
    Rifle rifle;
    Image healthbar;
    Image Reggybar;
    Text Ammo;
    GameObject pauseMenu;
    public bool ispaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            Ammo = GameObject.FindGameObjectWithTag("Ammont").GetComponent<Text>();
            healthbar = GameObject.FindGameObjectWithTag("UI_health").GetComponent<Image>();
            Reggybar = GameObject.FindGameObjectWithTag("ReggyHealth").GetComponent<Image>();
            player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerController>();
            Reggy = GameObject.FindGameObjectWithTag("Reggy").GetComponent<Reggy>();
            //rifle = GameObject.FindGameObjectWithTag("weapon").GetComponent<Rifle>();
            pauseMenu = GameObject.FindGameObjectWithTag("PAUSE");
            pauseMenu.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
	    healthbar.fillAmount = (float)player.health / (float)player.maxHealth;
        Reggybar.fillAmount = (float)Reggy.health / (float)Reggy.maxHealth;
        //Ammo.text = "yes";
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
