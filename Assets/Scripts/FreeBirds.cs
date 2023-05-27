using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreeBirds : MonoBehaviour
{
    public AudioSource MissionComplete;
    public AudioSource GameMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay()
    {
        if(Input.GetKey(KeyCode.F))
        {
            GameMusic.Stop();
            MissionComplete.Play();
            StartCoroutine(GameOver());
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(11);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);
    }
}
