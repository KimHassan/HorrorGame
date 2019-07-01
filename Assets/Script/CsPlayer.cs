using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsPlayer : MonoBehaviour
{
    public GameObject ui;


    //움직임 관련=================
    [SerializeField]
    float moveSpeed = 3f;

    Vector3 moveMent;

    RaycastHit hit;

    float xSensitivity = 2.0f;

    float ySensitivity = 2.0f;

    float angle;

    CapsuleCollider myCollider;

    Rigidbody rigidBody;

    bool isRunning = false;

    public Vector3 MoveMent { get => moveMent; set => moveMent = value; }
    public bool Running { get => isRunning; set => isRunning = value; }

    // 카메라 관련==============================
    public GameObject cam;
    private CsCamera csCamera;

    // 상태 관련==============================

    bool isDead = false;

    public bool isBatteryHaving;

    public bool isAbleEscape;

    public enum CAMERA_VOLUME
    {
        CAMERA_MAIN,
        CAMERA_FILL
    }
    private CAMERA_VOLUME cameraVolume = CAMERA_VOLUME.CAMERA_MAIN;

    public CAMERA_VOLUME CameraVolume
    {
        get => cameraVolume;
        set
        {
            cameraVolume = value;
            if (cameraVolume == CAMERA_VOLUME.CAMERA_FILL)
            {
                csCamera.postProcessingFill.transform.Translate(new Vector3(5, 0, 0));

                StartCoroutine(FillCoroutine());
            }
        }
    }

    AudioSource audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;//마우스 커서 고정

        Cursor.visible = false;

        myCollider = GetComponent<CapsuleCollider>();

        rigidBody = GetComponent<Rigidbody>();

        csCamera = cam.GetComponent<CsCamera>();

        isBatteryHaving = false;

        isAbleEscape = false;

        audioSource = GetComponent<AudioSource>();


    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (csCamera.CameraState != CsCamera.CAMERA_STATE.CAMERA_IDLE) return;
        PlayerStateMachine();
        SightUpdate();
        RayCastUdpate();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            PlayerDie(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        switch (csCamera.CameraState)
        {
            case CsCamera.CAMERA_STATE.CAMERA_AWAKE:
                return;
            case CsCamera.CAMERA_STATE.CAMERA_DEATH:
                Running = false;
                MoveMent = Vector3.zero;
                return;
        }
        MoveUpdate();

    }
    void MoveUpdate() // 캐릭터의 움직임
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        Vector3 forward = v * Vector3.Normalize(transform.forward);
        Vector3 right = h * transform.right;

        moveMent = Vector3.Normalize(forward + right);
        Running = (moveMent.magnitude != 0);

        rigidBody.MovePosition(transform.position + moveMent * moveSpeed * Time.deltaTime);
    }

    void PlayerDie(GameObject monster)
    {
        if (csCamera.CameraState == CsCamera.CAMERA_STATE.CAMERA_DEATH)
            return;
        CsMonster csMonster = monster.gameObject.GetComponent<CsMonster>();
        csMonster.AttackPlayer(transform.position, transform.forward);

        csCamera.ChangeCameraState(CsCamera.CAMERA_STATE.CAMERA_DEATH);
        cam.transform.localRotation = Quaternion.Euler(0, 0, 0);

        transform.Translate(new Vector2(0, 0.4f));
        rigidBody.useGravity = false;

        cam.transform.LookAt(monster.transform.position + new Vector3(0, 0.8f));

        isDead = true;
    }

    void SightUpdate() // 시야 움직임
    { 
        float yRot = Input.GetAxis("Mouse X") * xSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * ySensitivity;


        this.transform.localRotation *= Quaternion.Euler(0, yRot, 0);

        Quaternion tempY = cam.transform.localRotation * Quaternion.Euler(-xRot, 0, 0);

        if (tempY.x * Mathf.Rad2Deg > -45 && tempY.x * Mathf.Rad2Deg < 45)  
            cam.transform.localRotation = tempY;

        //cam.transform.localRotation *= Quaternion.Euler(-xRot, 0, 0);

    }

    void RayCastUdpate() // 광선을 쏴서 물체를 감지
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);        

        Debug.DrawRay(ray.origin, ray.direction * 2, Color.red);

        if (Physics.Raycast(ray, out hit, 1.0f))
        {
            RayEvent();
        }

    }

    void RayEvent()
    {

        if (hit.transform.tag == "ActiveObject")
        {
            ui.GetComponent<CsUIControll>().RayCast();

            hit.transform.gameObject.GetComponent<CsObject>().RayCast();

            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.transform.gameObject.GetComponent<CsObject>().Active();

            }
        }

    }

    public void PlaySoundEffect(string _fileName)
    {
        AudioClip ac = Resources.Load<AudioClip>("Sound/EffectSound/" + _fileName);

        if (ac == null)
            return;

        audioSource.PlayOneShot(ac);
    }

    void PlayerStateMachine()
    {
        if(isDead == true)
        {
            myCollider.enabled = false;
        }
        switch (CameraVolume)
        {
            case CAMERA_VOLUME.CAMERA_MAIN:
                csCamera.postProcessingMain.SetActive(true);
                csCamera.postProcessingFill.SetActive(false);

                break;
            case CAMERA_VOLUME.CAMERA_FILL:
                csCamera.postProcessingMain.SetActive(false);
                csCamera.postProcessingFill.SetActive(true);

                csCamera.postProcessingFill.transform.position = Vector3.MoveTowards(
                csCamera.postProcessingFill.transform.position, csCamera.transform.position, 0.1f);
                break;
        }
    }

    IEnumerator FillCoroutine()
    {
        float time = 0;
        while(true)
        {
            if (time > 5)
                break;
            time += 1;
            yield return new WaitForSeconds(1.0f);
        }
        cameraVolume = CAMERA_VOLUME.CAMERA_MAIN;
    }
}
