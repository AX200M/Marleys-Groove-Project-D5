using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic_Start : MonoBehaviour
{
    AudioSource MainSong;
    // Start is called before the first frame update
    void Start()
    {
        MainSong = GetComponent<AudioSource>();
        StartCoroutine(WaitForTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitForTutorial()
    {
        yield return new WaitForSeconds(14);
        MainSong.Play();
    }
}
