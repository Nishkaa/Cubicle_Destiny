using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class CubeEnemy : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    public Transform Player;
    public float begin;
    public float dist = 5;
    public float speed = 5;
    public int dir;
    // Start is called before the first frame update
    void Start()
    {
        begin = transform.position.x;
        dir = 1;
    }

    void Update()
    {
       
                
        if (transform.position.x > begin + dist) { dir = -1; }
        else { if (transform.position.x < begin - dist) { dir = 1; } }
        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed * dir, transform.position.y, transform.position.z);
    }
    void OnCollisionEnter(Collision col)
    {
      if (col.gameObject.name == "Player")
        {
            Destroy(GameObject.FindWithTag("Player"));
            SceneManager.LoadScene("TheWorld");
        }
    }

}
