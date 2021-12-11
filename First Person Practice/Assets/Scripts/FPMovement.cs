using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FPMovement : MonoBehaviour
{

    int maxHealth = 100;
    public int currentHealth = 0;
    public Slider slider;
    public CharacterController controller;
    float speed;
    public float baseSpeed = 12f;
    public float sprintSpeed = 17f;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public TextMeshProUGUI crosshair;


    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        crosshair.text = "+";

        slider.value = currentHealth;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); 

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = baseSpeed;
        }

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    void OnTriggerEvent(Collider other)
    {
        if(other.gameObject.CompareTag("Ladder"))
        {
            SceneManager.LoadScene("Rooftop");
        }
    }

}
