using UnityEngine;
using System.Collections;

public class GrannyDoorScript : MonoBehaviour {

    Rigidbody rigidBody;
    
	// Use this for initialization
	void Start () {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        rigidBody.Sleep();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
