using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Controller : MonoBehaviour
{

    AudioSource Audio1;
    public TMP_Text ScoreText;
    public TMP_Text BirdsText;
    Animator anim;
    public float speed;
    public float turnSpeed;
    public float runspeed;
    Rigidbody rb;
    
    public float Score;

    public float destroyDistance = 5f;

    public List<GameObject> enemies = new List<GameObject>();
    public Transform player;

    private bool playingGuitar;

    public Animator BirdAnim;

    string BirdsDropped;
    
    bool StringEmptyBool;

    bool PlayAudio;
    bool AudioStop;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        anim = gameObject.GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Score = 0;
        BirdsDropped = "The Cage Has Dropped !";
        Audio1 = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //rb.velocity = transform.TransformDirection(transform.forward*speed);

            anim.SetBool("Idle", false);
            anim.SetBool("Walk", true);
            anim.SetBool("Run", false);
            anim.SetBool("Dancing", false);
        }
        
        if(!Input.anyKey)
        {
            StartCoroutine(Waitforidle());
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            anim.SetBool("Dancing", false);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
            anim.SetBool("Idle", false);
            anim.SetBool("Dancing", false);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate( -Vector3.up * Time.deltaTime * turnSpeed);
            anim.SetBool("Idle", false);
            anim.SetTrigger("Walk");
            anim.SetBool("Dancing", false);
        }

        if(Input.GetMouseButton(0))
        {
            anim.SetBool("Dancing", true);
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            StartCoroutine(GuitarPlay());
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
            transform.Translate(Vector3.forward * Time.deltaTime * runspeed);
        }
        if(Score == 500)
        {
            BirdAnim.SetBool("ScoreMet", true);
            BirdsText.SetText(BirdsDropped.ToString());
        }
        IEnumerator Waitforidle()
        {
            yield return new WaitForSeconds(2);
            anim.SetBool("Idle", true);
        }

        IEnumerator GuitarPlay()
        {
            if(!playingGuitar) {
                playingGuitar=true;
                yield  return new WaitForSeconds(3);
                Debug.Log("Enemy Transformed");
                GameObject closestEnemy = FindClosestEnemy();
                if (closestEnemy != null && Vector3.Distance(player.position, closestEnemy.transform.position) <= destroyDistance)
                {
                    Destroy(closestEnemy);
                    enemies.Remove(closestEnemy);
                    Score = Score + 100;
                    ScoreText.SetText(Score.ToString());
                }
                playingGuitar=false;
            } 
            else {
                yield return null;
            }
        }

        GameObject FindClosestEnemy()
        {
            GameObject closestEnemy = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(player.position, enemy.transform.position);

                if (distance < closestDistance)
                {
                    closestEnemy = enemy;
                    closestDistance = distance;
                }
            }

            return closestEnemy;
        }
    }
}

