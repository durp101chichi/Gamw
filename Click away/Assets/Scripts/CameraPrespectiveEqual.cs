using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraPrespectiveEqual : MonoBehaviour
{
    [SerializeField] private Camera uiCamera;
    private Camera m_Camera;

    private void Start()
    {
        m_Camera = GetComponent<Camera>();
    }

    private void Update()
    {
        uiCamera.fieldOfView = m_Camera.fieldOfView;
    }
}
