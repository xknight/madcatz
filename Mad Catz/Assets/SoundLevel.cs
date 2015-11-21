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

    DateTime gameOverAnimationEndTime;
    bool gameOver;
    
    float soundLevel = 0.0f;

    public void Increase(float amount)
    {
        soundLevel += amount;
        SoundLevelSlider.value = soundLevel;

        if (soundLevel >= 1.0f)
        {
            //game over after like 2 seconds
            gameOver = true;
            StartCoroutine("GameEnd");
            soundLevel = 1;
        }

        Noise.grainIntensityMax = soundLevel * soundLevel * 0.9f;
        Noise.scratchIntensityMax = soundLevel * 0.6f;
        Trippy.intensity = soundLevel * 0.7f;
    }

    IEnumerator GameEnd()
    {
        //TODO: do some ending effects: cats going insane, screams, post effects...
        DateTime gameOverAnimationEndTime = DateTime.Now;
        yield return new WaitForSeconds(2);
        MANAGER.changeScene("gameover");
    }

	// Use this for initialization
	void Start () {
        SoundLevelSlider = GameObject.Find("SoundLevelSlider").GetComponent<Slider>();
        MANAGER = GameObject.Find("_Manager").GetComponent<ManagerScript>();
        MainCamera = GameObject.Find("MainCamera");
        Noise = MainCamera.GetComponent<NoiseAndScratches>();
        Trippy = MainCamera.GetComponent<VignetteAndChromaticAberration>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (gameOver)
        {
            //animate game over
            long delta = gameOverAnimationEndTime.ToBinary() - DateTime.Now.ToBinary();
            Debug.Log(delta);
        }
	}
}
