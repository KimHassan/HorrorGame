﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsPlayer : MonoBehaviour
{
    public GameObject ui;

    public GameObject cam;

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

    // 숨기 관련====================

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

    }

    // Update is called once per frame
    void Update()
    {
        SightUpdate();
        RayCastUdpate();
        
    }

    private void FixedUpdate()
    {
        MoveUpdate();
    }
    void MoveUpdate() // 캐릭터의 움직임
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveMent = new Vector3(h, 0, v) * moveSpeed;
        Running = (moveMent.magnitude != 0);

        Vector3 forward = moveMent.z * transform.forward * moveSpeed * Time.deltaTime;
        Vector3 right = moveMent.x * transform.right * moveSpeed * Time.deltaTime;

        rigidBody.MovePosition(transform.position + (forward + right));
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

        if (Physics.Raycast(ray, out hit, 3.0f))
        {
            RayEvent();
        }

    }

    void RayEvent()
    {

        if (hit.transform.tag == "ActiveObject")
        {
            ui.GetComponent<CsUIControll>().TextUp(true, "활성화하려면 E를 누르시오");

            ui.GetComponent<CsUIControll>().RayCast();

            hit.transform.gameObject.GetComponent<CsObject>().RayCast();

            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.transform.gameObject.GetComponent<CsObject>().Active();

            }
        }

    }

}
