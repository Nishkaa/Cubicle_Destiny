using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthbar;

    public float speed = 25.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    private float turner;
    private float looker;
    public float sensitivity = 5;

    // Use this for initialization
    void Start()
    {

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
            CharacterController controller = GetComponent<CharacterController>();
            // is the controller on the ground?
            if (controller.isGrounded)
            {
                //Feed moveDirection with input.
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);

                //Multiply it by speed.
                moveDirection *= speed;

                //Jumping
                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                    FindObjectOfType<SoundManager>().Play("JumpingSound");
                    //Jumping Sound

                }
            }

            turner = Input.GetAxis("Mouse X") * sensitivity;
            looker = -Input.GetAxis("Mouse Y") * sensitivity;
            if (turner != 0)
            {
                //Code for action on mouse moving right
                transform.eulerAngles += new Vector3(0, turner, 0);
            }
            if (looker != 0)
            {
                //Code for action on mouse moving right
                transform.eulerAngles += new Vector3(looker, 0, 0);
            }
            //Applying gravity to the controller
            moveDirection.y -= gravity * Time.deltaTime;
            //Making the character move
            controller.Move(moveDirection * Time.deltaTime);
        }

      public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);
    }
  public void GiveHealth(int health)
    {
        currentHealth += health;
        healthbar.SetHealth(currentHealth);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Purple_Enemy(Clone)")
        {
            TakeDamage(34);
            FindObjectOfType<SoundManager>().Play("PlayerTakingDamage");
        }
        if (col.gameObject.name == "CuberStarEnemy(Clone)")
        {
            TakeDamage(34);
            FindObjectOfType<SoundManager>().Play("PlayerTakingDamage");
        }
        if (col.gameObject.name == "YellowEnemy(Clone)")
        {
            TakeDamage(34);
            FindObjectOfType<SoundManager>().Play("PlayerTakingDamage");
        }
        if (currentHealth <= 0)
        {
            Destroy(GameObject.FindWithTag("Player"));
            SceneManager.LoadScene("TheWorld");
        }
    }
}
