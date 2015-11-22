using UnityEngine;
using System.Collections;

public class SoundWhenTouched : MonoBehaviour {

    public AudioClip audioClip;
    public AudioSource audioSource;

    void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(audioClip);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
