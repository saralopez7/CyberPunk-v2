using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour {

    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Transform[] points;
    private int randomPos;
    private Animator anim;

	
	void Start () {
        anim = GetComponent<Animator>();

        waitTime = startWaitTime;

        randomPos = Random.Range(0, points.Length);

	}
	
	// Update is called once per frame
	void Update () {
        if(speed > 0)
        {
            anim.SetBool("isIdle", false);
            anim.SetFloat("Speed", speed);
            transform.position = Vector3.MoveTowards(transform.position, points[randomPos].position, speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, points[randomPos].position) < 0.2f)
        {
            if(waitTime <= 0)
            {

                transform.Rotate(0, transform.rotation.y + 180, 0);
                anim.SetBool("isIdle", false);
                anim.SetFloat("Speed", speed);
                randomPos = Random.Range(0, points.Length);

                waitTime = startWaitTime;
            }
            else
            {
                anim.SetBool("isIdle", true);
                anim.SetFloat("Speed", 0);

                waitTime -= Time.deltaTime;
            }
        }
	}
}
