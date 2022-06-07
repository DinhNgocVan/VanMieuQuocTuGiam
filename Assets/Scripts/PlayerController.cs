using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float _rotationSpeed = 10f;
    [SerializeField]
    private Camera _followCamera;

    private Animator animator;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //get the direction
        Vector3 movementInput = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
        //movement direction
        Vector3 movementDirection = movementInput.normalized;

        if (movementDirection != Vector3.zero)
        {
            //Rotate vector around upward vector
            animator.SetBool("Walk", true);
            Quaternion desireRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desireRotation, _rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        characterController.Move(movementDirection * speed * Time.deltaTime);
    }



    /*[SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float turnspeed = 70f;
    private float horizontalPosition;
    private float verticalPosition;
    //[SerializeField]
    private Transform entryContainer;

    // Start is called before the first frame update
    void Awake()
    {
        //entryContainer = transform.Find("Imagation");
        //entryContainer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalPosition = Input.GetAxis("Horizontal");
        verticalPosition = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalPosition);
        transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * horizontalPosition);

        if(Input.GetKey(KeyCode.Space))
        {
            entryContainer.gameObject.SetActive(true);
        }
    }*/

}
