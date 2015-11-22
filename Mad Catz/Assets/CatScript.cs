using UnityEngine;
using System.Collections;
using System;

public class CatScript : MonoBehaviour {

    SoundLevel SoundLevel;

    public AudioSource meowSource;
    public AudioClip[] meowMix;

    TimeSpan meowInterval = TimeSpan.FromMilliseconds(3000);
    DateTime nextMeow;

    public float speed = 0.4f;
    public float directionChangeInterval = 1;
    public float maxHeadingChange = 30;

    DateTime catSpawned;

    public bool moving;
    TimeSpan moveInterval = TimeSpan.FromMilliseconds(5123);

    CharacterController controller;
    float heading;
    Vector3 targetRotation;

    void OnCollisionEnter(Collision collision)
    {
        DateTime now = DateTime.Now;
        if (now > catSpawned.AddSeconds(2)&&collision.rigidbody != null&&collision.rigidbody.tag!="DoesNotAngerCat")
        {
            SoundLevel.Change(0.8f);
        }
    }

	// Use this for initialization
	void Start () {
        SoundLevel = GameObject.Find("SoundLevelMonitor").GetComponent<SoundLevel>();
        nextMeow = DateTime.Now.AddMilliseconds(UnityEngine.Random.Range(500, 8000));
        catSpawned = DateTime.Now;
    }
	
	// Update is called once per frame
	void Update () {
        DateTime now = DateTime.Now;
	    if (now > nextMeow)
        {
            nextMeow = now.AddMilliseconds(UnityEngine.Random.Range(0,100000));
            meowSource.PlayOneShot(meowMix[UnityEngine.Random.Range(0,meowMix.Length)]);
        }

        if (moving) {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
            var forward = transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }
    }

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        // Set random initial rotation
        heading = UnityEngine.Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);

        StartCoroutine(NewHeading());
    }

    /// <summary>
    /// Repeatedly calculates a new direction to move towards.
    /// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
    /// </summary>
    IEnumerator NewHeading()
    {
        while (true)
        {
            NewHeadingRoutine();
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    /// <summary>
    /// Calculates a new direction to move towards.
    /// </summary>
    void NewHeadingRoutine()
    {
        var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
        var ceil = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
        heading = UnityEngine.Random.Range(floor, ceil);
        targetRotation = new Vector3(0, heading, 0);
    }
}
