using UnityEngine;
using System.Collections;

public class CatScript : MonoBehaviour {

    SoundLevel SoundLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag!="DoesNotAngerCat")
        {
            SoundLevel.Increase();
        }
    }

	// Use this for initialization
	void Start () {
        SoundLevel = GameObject.Find("SoundLevelMonitor").GetComponent<SoundLevel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
