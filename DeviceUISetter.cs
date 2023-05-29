using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DeviceUISetter : MonoBehaviour
{
    public CinemachineVirtualCamera CMCamera;
    public CinemachineTargetGroup targetGroup;
    public GameObject iPadBackground,iPhoneBackground;

    void Start()
    {
        var identifier = SystemInfo.deviceModel;
        if (identifier.StartsWith("iPhone"))
        {
            //iphone logic

            iPhoneBackground.SetActive(true);
            return;

        }
        else if (identifier.StartsWith("iPad"))
        {
            iPadBackground.SetActive(true);
            // iPad logic
            var transposer = CMCamera.GetCinemachineComponent<CinemachineTransposer>();
            Vector3 originalOffset = transposer.m_FollowOffset;
            originalOffset.z = -60f;
            transposer.m_FollowOffset = originalOffset;
            for (int i = 0; i < targetGroup.m_Targets.Length; i++)
            {
                targetGroup.m_Targets[i].radius = 3f;
            }
        }
        else
        {
            iPhoneBackground.SetActive(true);
        }
    }
}
