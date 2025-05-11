using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal.NRExamples;
using NRKernal;

public class GestureRPSTip : GestureSimpleTip
{
    public class GestureRPSName
    {
        public const string Gesture_Point = "Point";
        public const string Gesture_Rock = "Rock";
        public const string Gesture_Scissor = "Scissor";
        public const string Gesture_Paper = "Paper";
    }

   public override void UpdateGestureTip()
    {
        var handState = NRInput.Hands.GetHandState(handEnum);
        if (handState == null)
        {
            dinoHandInteract.SetBool("hitting2",false);
            return;
        }
        switch (handState.currentGesture)
        {
            case HandGesture.Point:
                gestureTxt.text = string.Empty;
                break;
            case HandGesture.Grab:
                gestureTxt.text = GetHandEnumLabel() + GestureRPSName.Gesture_Rock;
                break; ;
            case HandGesture.Victory:
                dinoHandInteract.SetBool("hitting2",true);
                gestureTxt.text = GetHandEnumLabel() + GestureRPSName.Gesture_Scissor;
                break;
            case HandGesture.OpenHand:
                gestureTxt.text = GetHandEnumLabel() + GestureRPSName.Gesture_Paper;
                break;
            default:
                gestureTxt.text = string.Empty;
                break;
        }

        if (handState.isTracked)
        {
            Pose palmPose;
            if (handState.jointsPoseDict.TryGetValue(HandJointID.Palm, out palmPose))
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
}
