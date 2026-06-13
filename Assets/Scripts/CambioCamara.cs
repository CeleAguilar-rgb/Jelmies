using Unity.Cinemachine;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    public CinemachineCamera camara1;
    public CinemachineCamera camara2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (camara1.Priority > camara2.Priority)
            {
                camara1.Priority = 0;
                camara2.Priority = 10;
            }
            else
            {
                camara1.Priority = 10;
                camara2.Priority = 0;
            }
        }
    }
}