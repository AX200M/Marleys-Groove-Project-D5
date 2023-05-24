using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter()
    {
        if(Input.GetKey(KeyCode.F))
        {
            StartCoroutine(GuitarPlayCheck());
        }
    }
    IEnumerator GuitarPlayCheck()
    {
        yield return new WaitForSeconds(2);
        //Debug.Log("Working Trigger");
        Anim.SetBool("EnemyTriggered", true);
        
    }
}
