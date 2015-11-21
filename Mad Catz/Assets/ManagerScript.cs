using UnityEngine;
using System.Collections;

public class ManagerScript : MonoBehaviour {

    public void changeScene(string index) {
        Application.LoadLevel(index);
    }

    public void close()
    {
        Application.Quit();
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
