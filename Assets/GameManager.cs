using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    [SerializeField] AudioSource src;
    [SerializeField] AudioClip sfxJaula1, sfxJaula2, sfxJaula3;
    [SerializeField] AudioClip sfxLlave;
    [SerializeField] string nextScene;
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
        keySound();
        src.Play();
    }
    public void keySound()
    {     
            src.clip = sfxLlave;
    }

    public void cageSound()
    {
        int numberSound = (Random.Range(0, 4));
        if (numberSound == 1)
        {
            src.clip = sfxJaula1;

        }
        if (numberSound == 2)
        {
            src.clip = sfxJaula2;

        }
        if (numberSound == 3)
        {
            src.clip = sfxJaula3;

        }
        src.Play();
    }

        public void TocarJaula()
    {
        if (haveKey)
        {
            cageSound();
            src.Play();
            changeScene(); 
        }    
    }
    public void changeScene()
    {
        SceneManager.LoadScene(nextScene);
        ResetGameController();
    }

    public void ResetGameController() { 
        haveKey = false;    
    }

    public void ResetScene(string scene)
    {
        //reset atado con alambre
        SceneManager.LoadScene(scene);
        ResetGameController();
    }
    public void abrirMenuGanaste()
    {
        
    }

}
