﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NRKernal.NRExamples
{
    public class GestureSimpleTip : MonoBehaviour
    {
        public class GestureName
        {
            public const string Gesture_Open_Hand = "Open Hand";
            public const string Gesture_Grab = "Grab";
            public const string Gesture_Pinch = "Pinch";
            public const string Gesture_Point = "Point";
            public const string Gesture_Victory = "Victory";
            public const string Gesture_Call = "Call";
            public const string Gesture_System = "System";
        }

        public HandEnum handEnum;
        public Transform tipAnchor;
        public Text gestureTxt;
        public Animator dinoHandInteract;

        private const string RIGHT_HAND_LABEL = "R:";
        private const string LEFT_HAND_LABEL = "L:";

        private void Update()
        {
            UpdateGestureTip();
        }

        virtual public void UpdateGestureTip()
        {
            var handState = NRInput.Hands.GetHandState(handEnum);
            if (handState == null)
            {
                return;
            }
            switch (handState.currentGesture)
            {
                case HandGesture.OpenHand:
                    gestureTxt.text = GetHandEnumLabel() + GestureName.Gesture_Open_Hand;
                    break;
                case HandGesture.Grab:
                    gestureTxt.text = GetHandEnumLabel() + GestureName.Gesture_Grab;
                    break;
                case HandGesture.Pinch:
                    gestureTxt.text = GetHandEnumLabel() + GestureName.Gesture_Pinch;
                    break;
                case HandGesture.Point:
                    gestureTxt.text = GetHandEnumLabel() + GestureName.Gesture_Point;
                    break;
                case HandGesture.Victory:
                    gestureTxt.text = GetHandEnumLabel() + GestureName.Gesture_Victory;
                    break;
                case HandGesture.Call:
                    gestureTxt.text = GetHandEnumLabel() + GestureName.Gesture_Call;
                    break;
                case HandGesture.System:
                    gestureTxt.text = GetHandEnumLabel() + GestureName.Gesture_System;
                    break;
                default:
                    gestureTxt.text = string.Empty;
                    break;
            }

            if (handState.isTracked)
            {
                Pose palmPose;
                if(handState.jointsPoseDict.TryGetValue(HandJointID.Palm, out palmPose))
                {
                    UpdateAnchorTransform(palmPose.position);
                }
                tipAnchor.gameObject.SetActive(!string.IsNullOrEmpty(gestureTxt.text));
            }
            else
            {
                tipAnchor.gameObject.SetActive(false);
            }
        }

        virtual public string GetHandEnumLabel()
        {
            switch (handEnum)
            {
                case HandEnum.RightHand:
                    return RIGHT_HAND_LABEL;
                case HandEnum.LeftHand:
                    return LEFT_HAND_LABEL;
                default:
                    break;
            }
            return string.Empty;
        }

        virtual public void UpdateAnchorTransform(Vector3 jointPos)
        {
            var vec_from_head = jointPos - Camera.main.transform.position;
            var vec_horizontal = Vector3.Cross(Vector3.down, vec_from_head).normalized;
            tipAnchor.position = jointPos + Vector3.up * 0.08f - vec_horizontal * 0.015f;
            tipAnchor.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(vec_from_head, Vector3.up), Vector3.up);
        }
    }
}
