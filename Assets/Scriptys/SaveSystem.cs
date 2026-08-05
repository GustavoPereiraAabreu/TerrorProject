using System;
using System.IO; //Imprtação para utilizar a conversão para JSON e salvar o arquivo
using UnityEngine;

[Serializable]
public class  Save
{
    private int _saveId;

    public Save(int saveId)
    {
        _saveId = saveId;
    }
    public int SaveId { get => _saveId; }
}

public class SaveSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SaveGame();
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            LoadGame();
        }
    }

    private void LoadGame()
    {
        if(!File.Exists(Application.persistentDataPath + "/save.json"))
         return;

        string json = File.ReadAllText(Application.persistentDataPath + "/save.json");
        Save save = JsonUtility.FromJson<Save>(json);
        GameController.Instance.OnLoadGame.Invoke();
    }

    private void SaveGame()
    {
        Save save = new Save(1);
        string json = JsonUtility.ToJson(save);
        JsonUtility.FromJson<Save>(json);
        string path = Application.persistentDataPath + "/save.json";
        File.WriteAllText(path, json);
        GameController.Instance.OnSaveGame.Invoke();
    }
}
