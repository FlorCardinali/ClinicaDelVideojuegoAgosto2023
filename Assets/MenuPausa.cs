using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
       
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        
    }

    

    public void MainMenu(){
        Time.timeScale=1f;
        SceneManager.LoadScene("Main menu");
    }
}
