using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introduction : MonoBehaviour
{
    [SerializeField] AudioSource src;
    [SerializeField] AudioClip clip1,clip2;


    private void Start()
    {
        audio1();
    }
    // Update is called once per frame
    public void audio1()
    {
        src.clip = clip1;
        src.Play();
    }
    public void audio2()
    {
        src.clip = clip2;
        src.Play();
    }
}
