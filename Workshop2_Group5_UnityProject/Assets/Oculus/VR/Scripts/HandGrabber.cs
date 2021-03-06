﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrabber : OVRGrabber
{
    OVRHand hand;
    [SerializeField] float pinchThreshold = 0.7f;

    protected override void Start()
    {
        base.Start();
        hand = GetComponentInChildren<OVRHand>();
    }

    public override void Update()
    {
        base.Update();
        CheckIndexPinch();
        m_lastRot = transform.rotation;
        m_lastPos = transform.position;
    }

    void CheckIndexPinch()
    {
        float pinchStrenght = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        bool isPinching = pinchStrenght > pinchThreshold;

        if (!m_grabbedObj && isPinching && m_grabCandidates.Count > 0)
            GrabBegin();
        else if (m_grabbedObj && !isPinching)
            GrabEnd();
    }

    public override void GrabEnd()
    {
        if (m_grabbedObj != null)
        {
            Vector3 linearVelocity = (transform.position - m_lastPos) / Time.deltaTime;
            Vector3 angularVelocity = (transform.eulerAngles - m_lastRot.eulerAngles) / Time.deltaTime;

            print(linearVelocity + " - " + angularVelocity);

            GrabbableRelease(linearVelocity, angularVelocity);
        }

        // Re-enable grab volumes to allow overlap events
        GrabVolumeEnable(true);
    }
}
