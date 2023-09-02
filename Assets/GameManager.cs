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
    public bool TocarJaula()
    {
        bool request = true;
        if (!haveKey)
        {
            request=  false;
        }
        return request;
    }
    public void changeScene()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
