using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home1 : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = gameObject.GetComponent<Animator>();
        Play();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Play()
    {
        //animator.Play("Die", 0);
        animator.Play("Start", 0);
    }
}
