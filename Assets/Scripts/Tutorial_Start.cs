using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Start : MonoBehaviour
{
    AudioSource Tutorial;
    // Start is called before the first frame update
    void Start()
    {
        Tutorial = GetComponent<AudioSource>();
        StartCoroutine(StartTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(1);
        Tutorial.Play();
    }
}
