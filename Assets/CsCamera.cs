using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject postProcessingMain;
    public GameObject postProcessingFill;

    private Animator animator;
    private Camera camComponent;
    private Vector3 originPos = new Vector3(0, 0, 0);

    public CAMERA_STATE CameraState
    {
        get
        {
            return (CAMERA_STATE)animator.GetInteger("PlayerCinemaScene");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeCameraState(cameraState);
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
                    ChangeCameraState(CAMERA_STATE.CAMERA_IDLE);
                }
                break;
            case CAMERA_STATE.CAMERA_IDLE:

                break;
            case CAMERA_STATE.CAMERA_DEATH:
                camComponent.fieldOfView = 35;
                
                break;
        }
    }

    public void ChangeCameraState(CAMERA_STATE state)
    {
        animator.SetInteger("PlayerCinemaScene", (int)state);
        switch (state)
        {
            case CAMERA_STATE.CAMERA_AWAKE:
                animator.enabled = true;
                break;
            case CAMERA_STATE.CAMERA_IDLE:
                animator.enabled = false;
                break;
            case CAMERA_STATE.CAMERA_DEATH:
                originPos = transform.localPosition;
                StartCoroutine(Shake(0.02f, 3));
                animator.enabled = false;

                break;
        }
    }

    public IEnumerator Shake(float _amount, float _duration)
    {
        float timer = 0;
        while (timer <= _duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += 0.03f;
            yield return new WaitForSeconds(0.03f);
        }
        transform.localPosition = originPos;
        SceneManager.LoadScene("GameOverScene");
    }
}