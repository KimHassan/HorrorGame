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

    public enum CAMERA_VOLUME
    {
        CAMERA_MAIN,
        CAMERA_FILL
    }

    [SerializeField]
    private CAMERA_STATE cameraState = CAMERA_STATE.CAMERA_AWAKE;
    private CAMERA_VOLUME cameraVolume = CAMERA_VOLUME.CAMERA_MAIN;

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

    public CAMERA_VOLUME CameraVolume
    {
        get => cameraVolume;
        set
        {
            cameraVolume = value;
            if (cameraVolume == CAMERA_VOLUME.CAMERA_FILL)
            {
                postProcessingFill.transform.Translate(new Vector3(5, 0, 0));
            }
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
        switch (CameraVolume)
        {
            case CAMERA_VOLUME.CAMERA_MAIN:
                postProcessingMain.SetActive(true);
                postProcessingFill.SetActive(false);
                break;
            case CAMERA_VOLUME.CAMERA_FILL:
                postProcessingMain.SetActive(false);
                postProcessingFill.SetActive(true);
                postProcessingFill.transform.position = Vector3.MoveTowards(
                    postProcessingFill.transform.position, transform.position, 0.1f);
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