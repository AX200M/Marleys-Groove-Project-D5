using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC: MonoBehaviour
{
    AudioSource NPCAudio;
    public AudioSource AudioToStop;
    // Start is called before the first frame update
    void Start()
    {
        NPCAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay()
    {
        if(Input.GetKey(KeyCode.F))
        {
            AudioToStop.Stop();
            NPCAudio.Play();
            StartCoroutine(WaitForNPC());
        }
    }
    IEnumerator WaitForNPC()
    {
        yield return new WaitForSeconds(4);
        AudioToStop.Play();
    }
}
