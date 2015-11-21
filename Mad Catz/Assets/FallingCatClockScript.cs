using UnityEngine;
using System.Collections;

public class FallingCatClockScript : MonoBehaviour {

    Rigidbody rigidBody;
    SoundLevel SoundLevel;

    public AudioClip audioClip;

    public AudioSource audioSource;

    void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(audioClip);
        SoundLevel.Change(5.0f);
    }

    // Use this for initialization
    void Start () {
        SoundLevel = GameObject.Find("SoundLevelMonitor").GetComponent<SoundLevel>();
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        rigidBody.Sleep();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
