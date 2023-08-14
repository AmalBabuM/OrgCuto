using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pragma : MonoBehaviour
{
    private bool isDrawing = false;

#if UNITY_STANDALONE_WIN
    private void Update()
    {
        // Windows-specific input handling
        HandleWindowsInput();
    }
#elif UNITY_ANDROID
    private void Update()
    {
        // Android-specific input handling
        HandleAndroidInput();
    }
#else
    private void Update()
    {
        // Default input handling for other platforms
        HandleDefaultInput();
    }
#endif

    private void HandleWindowsInput()
    {
#if UNITY_STANDALONE_WIN
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("App running in Windows");
            StartDrawing();
        }
        else if (Input.GetMouseButton(0))
        {
            // Draw based on mouse position
            Draw(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }
#endif
    }

    private void HandleAndroidInput()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
           
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("App running in Android");
                StartDrawing();
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Draw based on touch position
                Draw(touch.position);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                StopDrawing();
            }
        }
#endif
    }

    private void HandleDefaultInput()
    {
        // Default input handling for other platforms
    }

    private void StartDrawing()
    {
        isDrawing = true;
        Debug.Log("Started Drawing");
        // Add logic to start drawing based on the platform
    }

    private void Draw(Vector2 position)
    {
        if (isDrawing)
        {
           /* Debug.Log("Is Drawing");*/
            // Add logic to perform drawing based on the platform and input position
        }
    }

    private void StopDrawing()
    {
        isDrawing = false;
        Debug.Log("Drawing Stopped");
        // Add logic to stop drawing based on the platform
    }
}
