using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;

    public void SetVolume (float volume){
        audioMixer.SetFloat("MasterVolume", volume);
    }
}
