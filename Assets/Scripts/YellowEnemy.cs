using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
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