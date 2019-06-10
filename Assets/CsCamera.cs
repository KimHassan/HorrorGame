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

    [SerializeField]
    private CAMERA_STATE cameraState = CAMERA_STATE.CAMERA_AWAKE;

    private Animator animator;
    private Camera camComponent;

    public CAMERA_STATE CameraState
    {
        get
        {
            return (CAMERA_STATE)animator.GetInteger("PlayerCinemaScene");
        }
        set
        {
            animator.SetInteger("PlayerCinemaScene", (int)value);
            if(CameraState == CAMERA_STATE.CAMERA_IDLE)
                animator.enabled = false;
            else
                animator.enabled = true;   
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        CameraState = cameraState;
        camComponent = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (CameraState)
        {
            case CAMERA_STATE.CAMERA_AWAKE:
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                {
                    CameraState = CAMERA_STATE.CAMERA_IDLE;
                }
                break;
            case CAMERA_STATE.CAMERA_IDLE:

                break;
            case CAMERA_STATE.CAMERA_DEATH:
                camComponent.fieldOfView = 35;
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                {
                    CameraState = CAMERA_STATE.CAMERA_IDLE;
                }
                break;
        }
    }
}