using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveControl : MonoBehaviour
{

    public Respawn checkSave;

    public bool salvar;

    public bool load;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (salvar)
        {
            SaveGame(checkSave,0);
            salvar = false;
        }

        if (load)
        {
            checkSave = LoadGame(0);
            load = false;
        }
        
    }

    static void SaveGame (Respawn data, int charSlot){
        PlayerPrefs.SetInt("level_CharacterSlot" + charSlot, data.fase);
        PlayerPrefs.Save();
    }

    static Respawn LoadGame( int charSlot){
        Respawn loadedGame = new Respawn();
        loadedGame.fase = PlayerPrefs.GetInt("level_CharacterSlot" + charSlot);

        return loadedGame;
    }

    public void Carregar(){
        load = true;
    }
}
