﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class CubeLinearMovement : MonoBehaviour
{
    public AudioClip Fire;
    //AudioSource audioSource;

    public Transform Player;
    public float begin;
    public float dist = 5;
    public float speed = 10;
    public int dir;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        begin = transform.position.x;
        dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
       // audioSource.PlayOneShot(Fire, 0.2F);

        if (transform.position.x > begin + dist) { dir = -1; }
        else { if (transform.position.x < begin - dist) { dir = 1; } }
        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed * dir, transform.position.y, transform.position.z);
    }
    void OnCollisionEnter(Collision col)
    {
        // change player name for the name of your players game object
        if (col.gameObject.name == "Player")
        {

            Destroy(GameObject.FindWithTag("Player"));
            SceneManager.LoadScene("TheWorld");

        }
    }
}