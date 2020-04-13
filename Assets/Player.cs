using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float xSpeed = 4f;
    [SerializeField] float ySpeed = 4f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    Rigidbody rigidBody;

    float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToControlThrow+pitchDueToPosition;

        float yaw = transform.localPosition.x *positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xSpeed * xThrow * Time.deltaTime;
        float yOffset = ySpeed * yThrow * Time.deltaTime;

        float newXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);
        float newYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        //transform.Rotate(Vector3.forward*horizontalThrow);
        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }
}
