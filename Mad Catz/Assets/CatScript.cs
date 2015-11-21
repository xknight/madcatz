using UnityEngine;
using System.Collections;
using System;

public class CatScript : MonoBehaviour {

    SoundLevel SoundLevel;

    public AudioSource meowSource;
    public AudioClip[] meowMix;

    TimeSpan meowInterval = TimeSpan.FromMilliseconds(3000);
    float meowRandomness = 0.3f;
    DateTime nextMeow;

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
        nextMeow = DateTime.Now.AddMilliseconds(UnityEngine.Random.Range(500, 8000));
    }
	
	// Update is called once per frame
	void Update () {
        DateTime now = DateTime.Now;
	    if (now > nextMeow)
        {
            nextMeow = now.AddMilliseconds(UnityEngine.Random.Range(0,100000));
            meowSource.PlayOneShot(meowMix[UnityEngine.Random.Range(0,meowMix.Length)]);
        }
	}
}
