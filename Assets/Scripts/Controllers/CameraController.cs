using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region ##### VARIABLES #####
    public Transform target;
    public Vector3 offset;
    public PlayerControler playerControler;

    public float mouseSensitivity = 20f;
    #endregion

    #region ##### EVENTS #####
    
    void FixedUpdate() {
        FollowTarget();
    }
    #endregion

    #region ##### METHODS #####

    private void FollowTarget() {
        transform.position = Vector3.MoveTowards(transform.position, target.position + offset, Time.fixedDeltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Mathf.Clamp(playerControler.mouseX, -90f, 90f), playerControler.mouseY, 0), mouseSensitivity);
    }


    #endregion
}
