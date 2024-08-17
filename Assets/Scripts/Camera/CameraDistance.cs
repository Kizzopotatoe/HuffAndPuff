using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraDistance : MonoBehaviour
{
    public Pufferfish pufferfish;
    public CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        pufferfish = FindObjectOfType<Pufferfish>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pufferfish.bigMode == true)
        {
            CinemachineComponentBase componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
            if (componentBase is CinemachineFramingTransposer)
            {
                (componentBase as CinemachineFramingTransposer).m_CameraDistance = 30f;
            }
        }
    }
}
