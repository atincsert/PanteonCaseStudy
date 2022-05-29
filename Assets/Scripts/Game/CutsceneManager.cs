using Cinemachine;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera playerFollowerCam;
    [SerializeField] private CinemachineVirtualCamera panCam;

    private void OnEnable()
    {
        FindObjectOfType<GameManager>().OnFinish += EnablePanCamera;
    }

    private void EnablePanCamera()
    {
        int bufferPriority = playerFollowerCam.Priority;

        playerFollowerCam.Priority = panCam.Priority;
        panCam.Priority = bufferPriority;
    }  
}