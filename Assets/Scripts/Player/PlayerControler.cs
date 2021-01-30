using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    #region ##### VARIABLES #####

    [Header("Movement")]
    public Vector2 speedMinAndMax = new Vector2(5f, 8f);
    public float speed = 0f;
    public float acceleration = 20f;
    private bool isCrouching = false;

    [Header("Objects Detection")]
    public LayerMask interactuableLayer;
    public float maxInteractionDistance = 0.5f;
    public GameObject interactionText;
    private bool interactionAction = false;
    private Ray interactionRay;
    private GameObject interactionTarget;

    
    public float horizontal, vertical, mouseX = 0f, mouseY = 0f;

    private Vector2 directionX, directionZ, desiredVelocity;
    private bool isSprinting = false;
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
        if (GameManager.instance.paused) {
            return;
        }
        Inputs();
        CheckInteraction();
        Movement();
    }
    #endregion

    #region ##### METHODS #####

    private void Inputs() {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX += -Input.GetAxis("Mouse Y");
        mouseY += Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.LeftShift)) {
            isSprinting = true;
        } else {
            isSprinting = false;
        }

        if (Input.GetKeyDown(KeyCode.F) && interactionAction) {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            ToggleCrouch();
        }


    }

    private void Movement() {

        if (isCrouching) {
            return;
        }

        if (!isSprinting) {
            speed = speedMinAndMax.x;
        } else {
            speed = speedMinAndMax.y;
        }


        directionX = new Vector2(horizontal * transform.right.x, horizontal * transform.right.z);
        directionZ = new Vector2(vertical * transform.forward.x, vertical * transform.forward.z);
        desiredVelocity = (directionX + directionZ).normalized * speed * Time.deltaTime * acceleration;

        if (horizontal != 0 || vertical != 0) {
            playerRB.velocity = new Vector3(desiredVelocity.x, playerRB.velocity.y, desiredVelocity.y);
        }

        Debug.DrawRay(transform.position, playerRB.velocity);


        transform.rotation = Quaternion.Euler(0, mouseY, 0);
    }

    private void CheckInteraction() {
        if (GameManager.instance.isGameOver) {
            interactionText.SetActive(false);
            return;
        }
        
        interactionRay.origin = Camera.main.transform.position;
        interactionRay.direction = Camera.main.transform.forward;

        RaycastHit interactionHit;
        if (interactionAction = Physics.Raycast(interactionRay, out interactionHit, maxInteractionDistance, interactuableLayer)) {
            interactionTarget = interactionHit.collider.gameObject;
        } else {
            interactionTarget = null;
        }

            interactionText.SetActive(interactionAction);

    }


    private void Interact() {
        if (interactionTarget == null) {
            return;
        }
            Debug.Log("Interaction");
    }

    private void ToggleCrouch() {
        isCrouching = !isCrouching;

        if (isCrouching) {
            transform.localScale /= 5;
        } else {
            transform.localScale *= 5;
        }
    }

    #endregion
}
