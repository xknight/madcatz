using UnityEngine;
using System.Collections;

public class CatScript : MonoBehaviour {

    SoundLevel SoundLevel;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null&&collision.rigidbody.tag!="DoesNotAngerCat")
        {
            SoundLevel.Change(0.4f);
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
