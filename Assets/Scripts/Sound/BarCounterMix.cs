using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BarCounterMix : MonoBehaviour
{
    public new AudioSource audio; //THIS MAY NOW BE BROKE WITH THE NEW KEYWORD
    Camera cam;
    float twoSecondTimer = 2;
    bool twoSecondFlag = false;
    bool firstTimeInGame = true;

    bool fromGame;
    float preChrousTime = 36f;

    //zoom camera settings
    private float zoomDuration = 10f;
    float zoomStartValue = 3;
    float zoomEndValue = 6;
    float vigStartValue = 1;
    float vigEndValue = 0;
    private Vignette vg;
    private ChromaticAberration ca;
    float timeElapsed = 0;

    public static BarCounterMix _instance;
 
     void Awake()
     {
         //if we don't have an [_instance] set yet
         if(!_instance)
             _instance = this ;
         //otherwise, if we do, kill this thing
         else
             Destroy(this.gameObject) ;
 
 
         DontDestroyOnLoad(this.gameObject) ;
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene"){
            fromGame = true;
            cam = Camera.main;
            GameObject pp = GameObject.Find("Global Post Processing");
            pp.GetComponent<Volume>().profile.TryGet(out vg);
            pp.GetComponent<Volume>().profile.TryGet(out ca);
            if (timeElapsed < zoomDuration){
                cam.orthographicSize = Mathf.Lerp(zoomStartValue, zoomEndValue, timeElapsed / zoomDuration);
                vg.intensity.value = Mathf.Lerp(vigStartValue, vigEndValue, timeElapsed / zoomDuration);
                ca.intensity.value = Mathf.Lerp(vigStartValue, vigEndValue, timeElapsed / zoomDuration);
                timeElapsed += Time.deltaTime;
                GameManager.instance.playerCanMove = false;
            }
            else{
                cam.orthographicSize = 6;
                vg.intensity.value = 0;
                ca.intensity.value = 0;
            }
        }

        if (SceneManager.GetActiveScene().name != "SampleScene" && fromGame){
            audio.clip = Resources.Load<AudioClip>("Music/mainloopwav");
            audio.Play();
            audio.loop = true;
            timeElapsed = 0;
            firstTimeInGame = true;
            fromGame = false;
        }

        if (Mathf.Floor(audio.time) % 6 == 0 && !twoSecondFlag){
            twoSecondFlag = true;
            if (audio.clip.name == "intro1" && audio.time >= 18f){
                audio.clip = Resources.Load<AudioClip>("Music/mainloopwav");
                audio.Play();
                audio.loop = true;
            }
            
            Debug.Log(audio.time);
        }
        if (audio.time >= 10.5f && firstTimeInGame && audio.clip.name == "gameMainLoopWAV"){
            firstTimeInGame = false;
            StartCoroutine(Cheese());
        }

        if (twoSecondFlag){
            twoSecondTimer -= Time.deltaTime;
            if (twoSecondTimer <= 0){
                twoSecondFlag = false;
                twoSecondTimer = 2;
            }
        }
    }

    IEnumerator Cheese(){
        for (int i = 4; i > 0; i--){
            Debug.Log(i);
            GameManager.instance.playerCanMove = false;
            GameManager.instance.countdownText.text = i.ToString();
            yield return new WaitForSeconds(0.375f);
        }
        GameManager.instance.countdownText.text = "";
        GameManager.instance.playerCanMove = true;
    }
}
