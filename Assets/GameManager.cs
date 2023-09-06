using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //control de llave
    public bool haveKey { get; private set;} = false;

    //singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void AgarrarLlave()
    {
        haveKey = true;
    }
    public void TocarJaula()
    {
        if (haveKey)
        {
            changeScene(); 
        }    
    }
    public void changeScene()
    {
        SceneManager.LoadScene("LevelTwo");
        ResetGameController();
    }

    public void ResetGameController() { 
        haveKey = false;    
    }

    public void ResetScene()
    {
        //reset atado con alambre
        changeScene();
    }

}
