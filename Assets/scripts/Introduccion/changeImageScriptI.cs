using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeImageScript : MonoBehaviour
{
    [SerializeField] float tiempoEspera; // Cambia este valor al tiempo que desees
    [SerializeField] GameObject thisObject;
    [SerializeField] GameObject nextObject;
    [SerializeField] FadeCanvasGroup fadeCanvasGroup;
    private void OnEnable()
    {
        fadeCanvasGroup.fadeToOne();
        Invoke("HacerAlgo", tiempoEspera);
    }

    private void HacerAlgo()
    {
        fadeCanvasGroup.fadeToZero();
       nextObject.SetActive(true);
    }
}