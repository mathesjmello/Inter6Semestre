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

    public GameObject brilhoEAudioObject;
    public GameObject sensibilObject;

    static private float brilho = 0;
    static private float sensibilidade = 30;
    static private float volume = 1;


    // Start is called before the first frame update
    void Start()
    {
        MasterVolume = brilhoEAudioObject.GetComponent<MasterVolume>();
        TesteCharDrunk = sensibilObject.GetComponent<TesteCharDrunk>();
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
        sensibilidade = valor;
    }

    public void Volume(float valor)
    {
        volume = valor;
    }
}
