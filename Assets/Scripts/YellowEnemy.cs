using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Audio;
public class YellowEnemy : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);
    }
}