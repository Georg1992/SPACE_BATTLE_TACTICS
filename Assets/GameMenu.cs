using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public GameObject startGame;
    public GameObject exitGame;
    
    private enum Selection{
        start,
        exit
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void actionOnStartChoose(){
        SceneManager.LoadScene("CharSelect");

    }
}
