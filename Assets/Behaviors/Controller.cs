using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public Creature myCreature;
    public float speed = 10f;
    public float rotateSpeed = 0.05f;
    public HashSet<Actions> actionSet = new HashSet<Actions>();    
    Dictionary<KeyCode, Actions> keyActionPair = new Dictionary<KeyCode, Actions>();
    
    private void initDictionary()
    {
        keyActionPair.Add(KeyCode.W, Actions.Forward);
        keyActionPair.Add(KeyCode.S, Actions.Backward);
        keyActionPair.Add(KeyCode.A, Actions.RotateL);
        keyActionPair.Add(KeyCode.D, Actions.RotateR);
        keyActionPair.Add(KeyCode.Mouse0, Actions.Attack);
        keyActionPair.Add(KeyCode.Mouse1, Actions.Swallow);
        //keyActionPair.Add(KeyCode.W, Actions.Forward); mouse up/down        
    }

	// Use this for initialization
	void Start () {
        initDictionary();        
	}
	
	// Update is called once per frame
	void Update () {
        Cursor.visible = false;
        AddRemoveAction(KeyCode.W);
        AddRemoveAction(KeyCode.S);
        /*AddRemoveAction(KeyCode.A);
        AddRemoveAction(KeyCode.D);*/
        AddRemoveAction(KeyCode.Mouse0);
        AddRemoveAction(KeyCode.Mouse1);
        if (!actionSet.Contains(Actions.Backward) && !actionSet.Contains(Actions.Forward)) // not forward and not backward movement. --> Action::StopMovement
        {
            actionSet.Add(Actions.StopMovement);
        }
        else actionSet.Remove(Actions.StopMovement);

        if (!actionSet.Contains(Actions.RotateL) && !actionSet.Contains(Actions.RotateR)) // not rotating left and not rotating right. --> Action::StopRotate
        {
            actionSet.Add(Actions.StopRotation);
        }
        else actionSet.Remove(Actions.StopRotation);

        if (Input.GetAxis("Mouse Y") < 0)
        {
            actionSet.Add(Actions.RotateU);
        }
        else actionSet.Remove(Actions.RotateU);

        if(Input.GetAxis("Mouse Y") > 0)
        {
            actionSet.Add(Actions.RotateD);
        }
        else actionSet.Remove(Actions.RotateD);

        if (Input.GetAxis("Mouse X") < 0)
        {
            actionSet.Add(Actions.RotateL);
        }
        else actionSet.Remove(Actions.RotateL);

        if (Input.GetAxis("Mouse X") > 0)
        {
            actionSet.Add(Actions.RotateR);
        }
        else actionSet.Remove(Actions.RotateR);

    }

    private void FixedUpdate()
    {
        if (actionSet.Contains(Actions.Forward))
        {
            GetComponent<Rigidbody>().velocity = transform.forward*speed;
        }       
        if(actionSet.Contains(Actions.Backward))
        {
            GetComponent<Rigidbody>().velocity = transform.forward * -0.5f * speed;
        }
        if(actionSet.Contains(Actions.StopMovement))
        {
            GetComponent<Rigidbody>().velocity *= 0.25f;
        }
        if (actionSet.Contains(Actions.RotateR))
        {
            transform.Rotate(0, rotateSpeed, 0);
        }
        if (actionSet.Contains(Actions.RotateL))
        {
            transform.Rotate(0, -rotateSpeed, 0);
        }
        if(actionSet.Contains(Actions.StopRotation))
        {
            GetComponent<Rigidbody>().angularVelocity *= 0.25f;
        }
        if (actionSet.Contains(Actions.RotateU))
        {
            transform.Rotate(rotateSpeed, 0, 0);
        }
        if (actionSet.Contains(Actions.RotateD))
        {
            transform.Rotate(-rotateSpeed, 0, 0);
        }
    }

    private void AddRemoveAction(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            Actions action;
            keyActionPair.TryGetValue(key, out action);
            actionSet.Add(action);
        }
        if (Input.GetKeyUp(key))
        {
            Actions action;
            keyActionPair.TryGetValue(key, out action);
            actionSet.Remove(action);
        }
    }
}



