using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarInteraction : MonoBehaviour
{
    public AudioSource FoundBoar;
    public AudioSource StopMusic;
    // Start is called before the first frame update
    void Start()
    {
        //FoundBoar = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay()
    {
        StopMusic.Stop();
        FoundBoar.Play();
        StartCoroutine(WaitForBob());
    }
    IEnumerator WaitForBob()
    {
        yield return new WaitForSeconds(8);
        StopMusic.Play();
    }
}
