using UnityEngine;

public class SimpleModelsRotator : MonoBehaviour {

    public Transform model;
    public SimpleModelsRotator_Preset preset;

    private Camera mainCamera;


    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (preset.rotating.rightMouseButtonInput)
        {
            if (Input.GetMouseButton(1))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                Rotate();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Rotate();
        }

        Zoom();
    }

    private void Rotate()
    {
        float rotX = Input.GetAxis("Mouse X");
        float rotY = Input.GetAxis("Mouse Y");

        Vector3 inputRot = new Vector3(rotY, rotX, 0);
        Vector3 currentRot = new Vector3(model.rotation.eulerAngles.x, model.rotation.eulerAngles.y, model.rotation.eulerAngles.z);
        Quaternion newRot = Quaternion.Euler(currentRot + inputRot);
        model.rotation = newRot;
    }

    private void Zoom()
    {
        float zoomInput = Input.GetAxis("Mouse ScrollWheel") * preset.zooming.zoomSpeed;

        float zoomValue = mainCamera.fieldOfView - zoomInput;
        zoomValue = Mathf.Clamp(zoomValue, preset.zooming.zoomMin, preset.zooming.zoomMax);

        mainCamera.fieldOfView = zoomValue;
    }
}
