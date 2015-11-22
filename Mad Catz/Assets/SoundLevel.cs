using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using System;

public class SoundLevel : MonoBehaviour {
    ManagerScript MANAGER;
    Slider SoundLevelSlider;
    GameObject MainCamera;
    NoiseAndScratches Noise;
    VignetteAndChromaticAberration Trippy;
    GameObject granny;
    GameObject door;
    GameObject player;
    GameObject GrannyCam;
    GameObject GrannySpot;

    DateTime gameOverAnimationEndTime;
    bool gameOver;
    
    float soundLevel = 0.0f;

    public void Change(float amount)
    {
        if (gameOver) return;
        soundLevel += amount;
        SoundLevelSlider.value = soundLevel;

        if (soundLevel < 0)
        {
            soundLevel = 0;
        }
        if (soundLevel >= 1.0f)
        {
            //game over after like 2 seconds
            gameOver = true;
            StartCoroutine("GameEnd");
            soundLevel = 1;
        }

        Noise.grainIntensityMax = soundLevel * soundLevel * 0.3f;
        Noise.scratchIntensityMax = soundLevel * 0.4f;
        Trippy.intensity = soundLevel * 0.2f;
    }

    IEnumerator GameEnd()
    {
        //GRANNY SLAM
        gameOverAnimationEndTime = DateTime.Now;
        yield return new WaitForSeconds(2);
        granny.GetComponent<Animation>().Play();
        Destroy(door);
        GrannySpot.GetComponent<Light>().enabled=true;
        MainCamera.GetComponent<Camera>().enabled = false;
        GrannyCam.GetComponent<Camera>().enabled = true;
        yield return new WaitForSeconds(4);
        MANAGER.changeScene("gameover");
    }

	// Use this for initialization
	void Start () {
        SoundLevelSlider = GameObject.Find("SoundLevelSlider").GetComponent<Slider>();
        MANAGER = GameObject.Find("_Manager").GetComponent<ManagerScript>();
        MainCamera = GameObject.Find("MainCamera");
        GrannyCam = GameObject.Find("GRANNYCAM");
        Noise = MainCamera.GetComponent<NoiseAndScratches>();
        Trippy = MainCamera.GetComponent<VignetteAndChromaticAberration>();
        granny = GameObject.Find("GRANNY");
        door = GameObject.Find("GRANNYDOOR");
        player = GameObject.Find("PLAYER");
        GrannySpot = GameObject.Find("GRANNYSPOT");
    }
	
	// Update is called once per frame
	void Update () {
	    if (gameOver)
        {
            //animate game over
            TimeSpan delta = DateTime.Now - gameOverAnimationEndTime;
            float percent = ((float)delta.TotalMilliseconds / 6000f);
            Trippy.chromaticAberration = percent * 30f;
        }
        else
        {
            Change(-0.0002f);
        }
	}
}
