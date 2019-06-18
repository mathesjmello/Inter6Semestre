using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public PostProcessProfile PostProcessProfile;
    private ColorGrading colorGrading;
    private MasterVolume MasterVolume;
    private TesteCharDrunk TesteCharDrunk;
    public Slider MasterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public GameObject brilhoEAudioObject;
    public GameObject sensibilObject;

    static private float brilho = 0;
    static private float sensibilidade = 30;
    


    // Start is called before the first frame update
    void Start()
    {
        MasterVolume = brilhoEAudioObject.GetComponent<MasterVolume>();
        TesteCharDrunk = sensibilObject.GetComponent<TesteCharDrunk>();
        MasterSlider.maxValue = 20;
        MasterSlider.minValue = -80;
        musicSlider.maxValue = 20;
        musicSlider.minValue = -80;
        sfxSlider.maxValue = 20;
        sfxSlider.minValue = -80;
        
        
        MasterSlider.value = PlayerPrefs.GetFloat("volumePrefs");
        musicSlider.value = PlayerPrefs.GetFloat("musicPrefs");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxPrefs");

    }

    // Update is called once per frame
    void Update()
    {
        PostProcessProfile.TryGetSettings(out colorGrading);
        colorGrading.brightness.value = brilho;
        print(colorGrading.postExposure.value);
    }


    public void Brilho(float valor)
    {
        brilho = valor;
       
    }

    public void Sensibilidade(float valor)
    {
        TesteCharDrunk.mouseSensivity = valor;
    }

    public void Volume(float valor)
    {
        MasterVolume.masterVolume = valor;
        PlayerPrefs.SetFloat("volumePrefs", valor);
    }

    public void Music(float valor)
    {
        MasterVolume.musicVolume = valor;
        PlayerPrefs.SetFloat("musicPrefs", valor);
    }
    public void Sfx(float valor)
    {
        MasterVolume.sfxVolume = valor;
        PlayerPrefs.SetFloat("sfxPrefs", valor);
    }
    
}
