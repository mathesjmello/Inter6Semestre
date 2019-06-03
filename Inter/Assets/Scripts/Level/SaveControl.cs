using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveControl : MonoBehaviour
{

    public SaveData saveData;

    public bool salvar;

    public bool load;

    public Respawn level;

    public int saveLevel;

    public int myVar;

    public bool salvou =  false;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        saveLevel = level.fase;

        if (salvar)
        {
            
            StartCoroutine(SaveGame());
            Debug.Log(salvar);
         
        }

        

    }

    
    IEnumerator SaveGame(){

        PlayerPrefs.SetInt("Level",saveLevel);
        PlayerPrefs.Save();
        Debug.Log("AutoSave"); 
        myVar = PlayerPrefs.GetInt("Level");
        Debug.Log(myVar + "numeroGravado");

        yield return new WaitForSeconds(1.0f);

        level.ativaSave = false;
        salvar = false;

    }

}
