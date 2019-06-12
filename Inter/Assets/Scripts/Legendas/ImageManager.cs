using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{


    /// <summary>
    /// Este script faz com que imagens sejam 
    /// passadas entre si após determinado tempo 
    /// (sendo este decidido pela variável 
    /// "tempoParaProxima"), essas imagens são 
    /// colocadas através de um Array (que é 
    /// o "textSprites"), elas devem ser 
    /// inseridas pelo inspector (*IMPORTANTE*
    /// as imagens precisam ser de "TextureType"
    /// "Sprite (2D and UI)" pois assim elas 
    /// estarão no formato de sprite)
    /// 
    /// Deve ser colocado em um objeto que 
    /// tenha um collider para que o jogador 
    /// possa colidir e ativar a sequência 
    /// de imagens
    /// </summary>


    public Animator fadeOutAnim;

    public GameObject textBox;

    bool ativou = true; //Detecta colisão pela primeira vez
    bool textBoxLigada = false; //Checa se a text box está ligada
    
    //[HideInInspector]
    public int currentImage = 0;
    [HideInInspector]
    public int endAtImage;
    
    public Image theImage;

    public Sprite[] textSprites;

    public float tempoParaProxima;

    public TesteCharDrunk player;

    public GameObject tutorial;

    public bool ativoNoMomento = false;

    public bool tocandoFala;

    public float falaA_01, falaA_02, falaA_03, falaA_04, falaA_05;
    public float falaB_01, falaB_02, falaB_03, falaB_04, falaB_05;

    public bool precisaDimitri;


    [Header ("Audios dos Personagens")]
    public AudioSource OutrosPersonagensVoz;
    public AudioSource SergueiVoz;
    public AudioSource SomDeFundo;

    public GameObject telefoneSom;


    public GameObject espaco;

    public bool proximaCena;

    private void Start()
    {
        tocandoFala = false;
        if (tutorial != null)
        {
            tutorial.SetActive(false);
        }
        textBox.SetActive(false);
        endAtImage = textSprites.Length;
    }


    void Update()
    {
        if (currentImage < endAtImage && Input.GetKeyDown(KeyCode.Space) && ativoNoMomento == true)
        {
            tocandoFala = false;
            currentImage++;
            SomDaFala();
        }

        if(currentImage < endAtImage)
        {
            theImage.sprite = textSprites[currentImage];
        }
        else if(endAtImage <= currentImage)
        {
            textBox.SetActive(false);
            player.freeze = false;

             OutrosPersonagensVoz.Stop();
             SergueiVoz.Stop();

            if (tutorial != null)
            {
                tutorial.SetActive(true);
            }
            if(proximaCena == true && fadeOutAnim != null)
            {
                fadeOutAnim.SetTrigger("Acabou");
                SceneManager.LoadScene("Fase02");
            }
            gameObject.SetActive(false);

            if (espaco != null)
            {
                espaco.SetActive(false);
            }
        }

        if(currentImage == 1 && SomDeFundo != null)
        {           
            telefoneSom.SetActive(false);
            SomDeFundo.volume = 0.0f;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player") && ativou == true) && precisaDimitri == false || other.CompareTag("Dimitri") && precisaDimitri == true)
        { 
            ativoNoMomento = true;
            currentImage = 0;
            player.freeze = true;
            ativou = false;
            SomDaFala();
            if (textBoxLigada == false)
            {
                if(espaco != null)
                {
                    espaco.SetActive(true);
                }
                textBox.SetActive(true);
                textBoxLigada = true;
            }
        }
    }

    void SomDaFala()
    {
        if((currentImage == falaA_01 || currentImage == falaA_02 || currentImage == falaA_03 || currentImage == falaA_04 || currentImage == falaA_05) && tocandoFala == false)
        {
            if (OutrosPersonagensVoz != null)
            {
                OutrosPersonagensVoz.Play();
            }
            if (SergueiVoz != null)
            {
                SergueiVoz.Stop();
            }
            tocandoFala = true;
        }
        if ((currentImage == falaB_01 || currentImage == falaB_02 || currentImage == falaB_03 || currentImage == falaB_04 || currentImage == falaB_05) && tocandoFala == false)
        {
            if (OutrosPersonagensVoz != null)
            {
                OutrosPersonagensVoz.Stop();
            }
            if (SergueiVoz != null)
            {
                SergueiVoz.Play();
            }
            tocandoFala = true;
        }
    }
}
