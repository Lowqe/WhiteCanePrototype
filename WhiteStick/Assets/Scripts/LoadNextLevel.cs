using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextLevel : MonoBehaviour
{

    private int nextSceneToLoad;
    int currentScene;

    private AudioSource source;
    public AudioClip victoryAudio;
    public AudioClip testEndedAudio;

    float currentTime = 0f;
    float startingTime = 300f;
    public Text timerCounter;

    string sceneName;
    string scenePath;
    string currentSceneName;
    string currentScenePath;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;

        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        currentScene = SceneManager.GetActiveScene().buildIndex;

        scenePath = SceneUtility.GetScenePathByBuildIndex(nextSceneToLoad);
        sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

        currentScenePath = SceneUtility.GetScenePathByBuildIndex(currentScene);
        currentSceneName = System.IO.Path.GetFileNameWithoutExtension(currentScenePath);


        source = GetComponent<AudioSource>();

        timerCounter = GameObject.Find("TimerCounter ").GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerCounter.text = currentTime.ToString("00") + " Sekunder kvar";

        if (currentTime <= 0 && !source.isPlaying)
        {
           
            source.PlayOneShot(testEndedAudio);

            StartCoroutine(LoadLevel(sceneName, testEndedAudio.length));
        }

        if (sceneName == "NivåMedKäpp" && Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.B) || sceneName == "NivåUtanKäpp" && Input.GetKey(KeyCode.Return))
        {

            SceneManager.LoadScene(sceneName);
        }

        if (Input.GetKey(KeyCode.K))
        {
            
            SceneManager.LoadScene(currentSceneName);
        }

    }
    private void OnTriggerEnter(Collider collision)
    {

        if (!source.isPlaying)
        {
            source.PlayOneShot(victoryAudio);
            float timeToReachGoal = 300f - currentTime;
            Debug.Log("Tid det tog att nå målet = " + timeToReachGoal + " sekunder");
        }

        StartCoroutine(LoadLevel(sceneName, victoryAudio.length));

           
    }

    IEnumerator LoadLevel(string name, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }


    
}
