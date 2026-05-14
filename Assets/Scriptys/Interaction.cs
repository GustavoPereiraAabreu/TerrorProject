using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Camera _mainCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCam = Camera.main;

        //Não usar os 3 seguintes

        //FindAnyObjectByType
        //GameObject.Find("KitFirstPerson")
        //GameObject.FindWithTag("Player")
        //FindObjectOfType

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
