using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Audio;
public class EnemyThree : MonoBehaviour
{ 
    Transform tr_Player;
    float f_RotSpeed = 5.0f;
    float f_MoveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*Look at player*/
        transform.rotation = Quaternion.Slerp(transform.rotation,
                             Quaternion.LookRotation(tr_Player.position - transform.position)
                             , f_RotSpeed * Time.deltaTime);
        /*Move Towards Player*/
        transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
    }
   
}
