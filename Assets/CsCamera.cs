using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsCamera : MonoBehaviour
{
    public enum CAMERA_STATE
    {
        CAMERA_AWAKE,
        CAMERA_IDLE,
        CAMERA_DEATH
    }

    private CAMERA_STATE cameraState = CAMERA_STATE.CAMERA_AWAKE;

    private Animator animator;

    public CAMERA_STATE CameraState
    {
        get
        {
            return (CAMERA_STATE)animator.GetInteger("PlayerCinemaScene");
        }
        set
        {
            animator.SetInteger("PlayerCinemaScene", (int)value);
            animator.enabled = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraState == CAMERA_STATE.CAMERA_IDLE) return;
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            CameraState = CAMERA_STATE.CAMERA_IDLE;
            animator.enabled = false;
        }
    }
}