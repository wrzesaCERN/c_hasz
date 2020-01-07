using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsToDestroy : MonoBehaviour
{
    public GameObject objectToDestroy;
    public GameObject[] objectsToDestroy;
    public GameObject[] statusBars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        Material newMat = Resources.Load("Materials/StateBarNotDestroyed", typeof(Material)) as Material;
        objectsToDestroy = GameObject.FindGameObjectsWithTag("ToDestroy");
        foreach (GameObject g in objectsToDestroy) 
        {
            
        }
        statusBars = GameObject.FindGameObjectsWithTag("StatusBar");
        foreach (GameObject s in statusBars)
        {
            //Destroy(s);
            s.GetComponent<Renderer>().material = newMat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
