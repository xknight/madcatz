using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundLevel : MonoBehaviour {
    ManagerScript MANAGER;
    Slider SoundLevelSlider;
    float soundLevel = 0.0f;

    public void Increase()
    {
        soundLevel += 0.1f;
        SoundLevelSlider.value = soundLevel;
        if (soundLevel>1.0f)
        {
            //game over after like 2 seconds
            StartCoroutine("GameEnd");
        }
    }

    IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(2);
        MANAGER.changeScene("gameover");
    }

	// Use this for initialization
	void Start () {
        SoundLevelSlider = GameObject.Find("SoundLevelSlider").GetComponent<Slider>();
        MANAGER = GameObject.Find("_Manager").GetComponent<ManagerScript>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
