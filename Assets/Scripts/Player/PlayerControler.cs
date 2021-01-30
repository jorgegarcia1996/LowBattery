using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    #region ##### VARIABLES #####

    [Header("Movement")]
    public float speed = 2f;
    public float acceleration = 20f;

    public float horizontal, vertical, mouseX = 0f, mouseY = 0f;

    private Vector2 directionX, directionZ, desiredVelocity;
    private Rigidbody playerRB;
    #endregion

    #region ##### EVENTS #####
    private void Awake() {
        playerRB = GetComponent<Rigidbody>();
    }

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    void Update() {
        Inputs();
        Movement();
    }
    #endregion

    #region ##### METHODS #####

    private void Inputs() {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX += -Input.GetAxis("Mouse Y");
        mouseY += Input.GetAxis("Mouse X");
    }

    private void Movement() {

        directionX = new Vector2(horizontal * transform.right.x, horizontal * transform.right.z);
        directionZ = new Vector2(vertical * transform.forward.x, vertical * transform.forward.z);
        desiredVelocity = (directionX + directionZ).normalized * speed * Time.deltaTime * acceleration;

        if (horizontal != 0 || vertical != 0) {
            playerRB.velocity = new Vector3(desiredVelocity.x, playerRB.velocity.y, desiredVelocity.y);
        }

        Debug.DrawRay(transform.position, playerRB.velocity);


        transform.rotation = Quaternion.Euler(0, mouseY, 0);

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;

            if (Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
        }
    }
    #endregion
}
