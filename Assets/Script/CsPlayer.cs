using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsPlayer : MonoBehaviour
{
    public GameObject ui;

    public GameObject cam;

    //움직임 관련=================
    float moveSpeed = 3f;

    Vector3 moveMent;

    RaycastHit hit;

    float xSensitivity = 2.0f;

    float ySensitivity = 2.0f;

    float angle;

    CapsuleCollider myCollider;

    Rigidbody rigidBody;

    bool isRunning = false;

    // 숨기 관련====================
    bool isHide = false;

    Vector3 pastPosition;

    Quaternion pastRotation;

    public Vector3 MoveMent { get => moveMent; set => moveMent = value; }
    public bool Running { get => isRunning; set => isRunning = value; }

    //==============================

    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;//마우스 커서 고정

        Cursor.visible = false;

        myCollider = GetComponent<CapsuleCollider>();

        rigidBody = GetComponent<Rigidbody>();
       

    }
    void Start()
    {
        isHide = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
        HideUpdate();
        SightUpdate();
        RayCastUdpate();
        
    }

    void MoveUpdate() // 캐릭터의 움직임
    {
        if (isHide == true)
            return;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveMent = new Vector3(h, 0, v);
        Running = moveMent.magnitude != 0;
        transform.Translate(moveMent * moveSpeed * Time.deltaTime);
    }


    void SightUpdate() // 시야 움직임
    { 
        float yRot = Input.GetAxis("Mouse X") * xSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * ySensitivity;

        this.transform.localRotation *= Quaternion.Euler(0, yRot, 0);
        cam.transform.localRotation *= Quaternion.Euler(-xRot, 0, 0);
        
    }

    void RayCastUdpate() // 광선을 쏴서 물체를 감지
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        

        Debug.DrawRay(ray.origin, ray.direction * 2, Color.red);

        if (Physics.Raycast(ray, out hit, 3.0f))
        {
            RayEvent();
        }

    }

    void HideUpdate() // 물체에 숨었을 때
    {
        if (isHide == false)
            return;
        if (Input.GetKeyDown(KeyCode.E))
        {

            myCollider.enabled = true;

            rigidBody.isKinematic = false;

            isHide = false;

            gameObject.transform.position = pastPosition;

            gameObject.transform.rotation = pastRotation;
        }
    }

    void Hide()
    {
        myCollider.enabled = false;

        rigidBody.isKinematic = true;

        isHide = true;

        pastPosition = gameObject.transform.position;

        pastRotation = gameObject.transform.rotation;


    }

    void RayEvent()
    {

        if(hit.transform.tag == "HideObject")
        {
            ui.GetComponent<CsUIControll>().TextUp(true, "숨으려면 E를 누르시오");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Hide();

                hit.transform.gameObject.GetComponent<CsObjectHide>().Active(this.gameObject);
            }
        }
        else if (hit.transform.tag == "ActiveObject")
        {
            ui.GetComponent<CsUIControll>().TextUp(true, "활성화하려면 E를 누르시오");

            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.transform.gameObject.GetComponent<CsObjectActiveItem>().Active();

               GetActiveItem();
            }
        }

    }

    void GetActiveItem()
    {


    }

    public void SetNormalEvent()
    {

    }
}
