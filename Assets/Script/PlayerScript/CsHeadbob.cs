using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsHeadbob : MonoBehaviour
{
    public Camera Camera;
    public CsCurveControlledBob motionBob = new CsCurveControlledBob();
    public CsPlayer fpsPlayer;
    public float StrideInterval;
    [Range(0f, 100f)] public float RunningStrideLengthen;

    // private CameraRefocus m_CameraRefocus;
    private bool m_PreviouslyGrounded;
    private Vector3 m_OriginalCameraPosition;


    private void Start()
    {
        motionBob.Setup(Camera, StrideInterval);
        m_OriginalCameraPosition = Camera.transform.localPosition;
        //     m_CameraRefocus = new CameraRefocus(Camera, transform.root.transform, Camera.transform.localPosition);
    }


    private void Update()
    {
        //  m_CameraRefocus.GetFocusPoint();
        Vector3 newCameraPosition;
        if (fpsPlayer.MoveMent.magnitude > 0)
        {
            Camera.transform.localPosition = motionBob.DoHeadBob(fpsPlayer.MoveMent.magnitude * (fpsPlayer.Running ? RunningStrideLengthen : 1f));
            newCameraPosition = Camera.transform.localPosition;
        }
        else
        {
            newCameraPosition = Camera.transform.localPosition;
        }
        Camera.transform.localPosition = newCameraPosition;
        
        //  m_CameraRefocus.SetFocusPoint();
    }
}
