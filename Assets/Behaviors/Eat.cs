using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour {

    GameObject myCreature;
    // Use this for initialization
    void Start () {
        myCreature = transform.parent.gameObject;
        Debug.Log(myCreature);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay(Collider other)
    {
        if (myCreature.GetComponent<Controller>().actionSet.Contains(Actions.Swallow))
        {
            Vector3 colsize = other.gameObject.transform.localScale;
            Vector2 diffvec = transform.localScale - colsize;
            if (diffvec.x > colsize.x && diffvec.y > colsize.y) // eatable
            {
                //if(!(other.gameObject is CorCodile))
                Destroy(other.gameObject);                
                myCreature.transform.localScale += colsize;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (myCreature.GetComponent<Controller>().actionSet.Contains(Actions.Swallow))
        {
            Vector3 colsize = other.gameObject.transform.localScale;
            Vector2 diffvec = myCreature.transform.localScale - colsize;
            if (diffvec.x > colsize.x && diffvec.y > colsize.y) // eatable
            {
                //if(!(other.gameObject is CorCodile))
                Destroy(other.gameObject);
                myCreature.transform.localScale += colsize;
            }
        }
    }
}
