using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
            //CONDICION DE VICTORIA
            Debug.Log("GAANAR");
        }
    }

}
