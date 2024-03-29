﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class NavigationGestureOn : MonoBehaviour, INavigationHandler
{
    private float rotationFactor;
    public float RotationSensitivity = 10.0f;

    public void OnNavigationStarted(NavigationEventData eventData)
    {
    }

    public void OnNavigationUpdated(NavigationEventData eventData)
    {
        // Do a raycast into the world from your head direction.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        // Use the navigation gesture to rotate the object.
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, Mathf.Infinity))
        {
            rotationFactor = eventData.CumulativeDelta.x * RotationSensitivity;
            hitInfo.transform.Rotate(new Vector3(0, -1 * rotationFactor, 0));
        }
    }

    public void OnNavigationCompleted(NavigationEventData eventData)
    {
    }

    public void OnNavigationCanceled(NavigationEventData eventData)
    {
    }
}
