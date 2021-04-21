using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button mainMenuButton;
    public Button exitButton;
    private Image activeFrameOnMenu;
    private Image activeFrameOnExit;
    private int activeFrameCounter;

    
    void Start()
    {
        activeFrameOnMenu = mainMenuButton.transform.Find("activeframe").GetComponent<Image>();
        activeFrameOnExit = exitButton.transform.Find("activeframe").GetComponent<Image>();
        activeFrameOnMenu.enabled= false;
        activeFrameOnExit.enabled = false;
        pauseMenu.SetActive(false);
        activeFrameCounter = 0;

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            activeFrameCounter = 0;
            switch (pauseMenu.activeInHierarchy){
                case true:
                    ContinueGame();
                    break;
                case false:
                    PauseGame();
                    break;
            }
        }
        MenuNavigation();
        ExitGameChosen();
        MainMenuChosen();
        

        
        
    }

    public void PauseGame(){
            
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            
    }

    public void ContinueGame(){
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void MenuNavigation(){
        
        
        if(pauseMenu.activeInHierarchy && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))){
            activeFrameCounter++;
            if(activeFrameCounter == 2){
                activeFrameCounter = 0;
            }
           
        }
        switch(activeFrameCounter){
            case 0:
            activeFrameOnMenu.enabled = true;
            activeFrameOnExit.enabled = false;
            break;
            case 1:
            activeFrameOnMenu.enabled = false;
            activeFrameOnExit.enabled = true;
            
            break;
        }

    }
    public void ExitGameChosen(){
        if(activeFrameOnExit.enabled && Input.GetKeyDown(KeyCode.Return)){
            Application.Quit();
        }
            
    }

    public void MainMenuChosen(){
        if(activeFrameOnMenu.enabled && Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("CharSelect");
            Time.timeScale =1;
        }
    }
}
