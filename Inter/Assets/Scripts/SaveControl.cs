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
            //Debug.Log("AutoSave");
           // SaveGame(saveData,saveLevel);
           SaveGame();
            Debug.Log("AutoSave02");
            salvou = true;
        }

        if (load)
        {
            //saveData = LoadGame(saveLevel);
            load = false;
        }

        if (salvou = true)
        {
            salvar = false;
            salvou = false;
        }
        

    }

    /*static void SaveGame (SaveData data, int charSlot){
        PlayerPrefs.SetInt("level_CharacterSlot" + charSlot, data.savePoint);
        PlayerPrefs.Save();
    }

    static SaveData LoadGame( int charSlot){
        SaveData loadedGame = new SaveData();
        loadedGame.savePoint = PlayerPrefs.GetInt("level_CharacterSlot" + charSlot);

        return loadedGame;
    }*/

    public void SaveGame(){
        PlayerPrefs.SetInt("Level",saveLevel);
        saveData.savePoint = saveLevel;
        PlayerPrefs.Save();
        //Debug.Log("AutoSave"); 
        myVar = PlayerPrefs.GetInt("Level");
        Debug.Log(myVar + "numeroGravado");
    }

    public void Carregar(){
        load = true;
    }
}
