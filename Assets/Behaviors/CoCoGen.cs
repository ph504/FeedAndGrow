using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoCoGen : MonoBehaviour {
    public List<GameObject> allCorCodiles = new List<GameObject>();
    public GameObject corcodile;
    public int maxAmount = 20;
    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (allCorCodiles.Count < maxAmount)
        {
            GameObject thisGO = Instantiate(corcodile, new Vector3(Random.Range(-100,100),Random.Range(-100,100), Random.Range(-100,100)), Quaternion.identity);            
            allCorCodiles.Add(thisGO);
        }
    }
}
