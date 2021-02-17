using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGen : MonoBehaviour {
    public List<GameObject> allGO = new List<GameObject>();
    public GameObject prefab;
    public int maxAmount = 20;
    public float initSize = 3.4f;
    public float maxDeltaS = 3f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (allGO.Count < maxAmount)
        {
            GameObject thisGO = Instantiate(prefab, new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)), Quaternion.identity);
            thisGO.transform.localScale = initSize*(new Vector3(1,1,1));
            float randomDeltaSize = Random.Range(-maxDeltaS, maxDeltaS);
            thisGO.transform.localScale += randomDeltaSize*(new Vector3(1,1,1));
            allGO.Add(thisGO);
        }
    }
}
