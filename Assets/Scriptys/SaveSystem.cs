using System;
using UnityEngine;

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
    }

    private void SaveGame()
    {
        /*
        // Primeiro criamos um objeto com os valores que queremos salvar
        FlashlightStatus status = new FlashlightStatus(_activeState, _batteryTimer, _lostingPower);
        //Depois transformamos esse objeto em uma string JSON
        string json = JsonUtility.ToJson(status);
        JsonUtility.ToJson(json);

        // Criamos o caminho do arquivo onde vamos salvar a string JSON no arquivo

        //Application.persistentDataPath é uma pasta é criada automaticamente pela Unity
        //Para Salvar dados que precisam ser persistentes entre as sessões do jogo, como configurações, progresso do jogador, etc.
        string path = Application.persistentDataPath + "/flashlight.json";
        System.IO.File.WriteAllText(path, json); */
    }
}
