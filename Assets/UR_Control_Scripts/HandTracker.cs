using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using MixedReality.Toolkit; // MRTK3 unificado
using MixedReality.Toolkit.Input;
using MixedReality.Toolkit.Subsystems;

public class HandTracker : MonoBehaviour
{
    private HandsAggregatorSubsystem aggregator;

    void Start()
    {
        aggregator = XRSubsystemHelpers.GetFirstRunningSubsystem<HandsAggregatorSubsystem>();

        if (aggregator == null)
        {
            Debug.LogError("No se encontró el HandsAggregatorSubsystem. Verifica que esté activo en tu MRTK Profile.");
        }
    }

    void Update()
    {
        if (aggregator == null) return;

        // 1. Detectar mano derecha y mostrar su posición
        if (aggregator.TryGetJoint(TrackedHandJoint.Palm, XRNode.RightHand, out HandJointPose rightPalm))
        {
            Debug.Log("Mano derecha detectada en posición: {rightPalm.Position}");
        }

        // 2. Detectar mano izquierda
        if (aggregator.TryGetJoint(TrackedHandJoint.Palm, XRNode.LeftHand, out HandJointPose leftPalm))
        {
            Debug.Log("Mano izquierda detectada en posición: {leftPalm.Position}");
        }

        // 3. Detectar gesto de cerrar mano (pinch) en derecha
        if (aggregator.TryGetPinchProgress(XRNode.RightHand, out bool isReadyToPinchRight, out bool isPinchingRight, out float pinchAmountRight))
        {
            if (isPinchingRight)
                Debug.Log("Mano derecha haciendo pinch (cerrando)");
        }
        // 4. Detectar gesto de cerrar mano (pinch) en izquierda
        if (aggregator.TryGetPinchProgress(XRNode.LeftHand, out bool isReadyToPinchLeft, out bool isPinchingLeft, out float pinchAmountLeft))
        {
            if (isPinchingLeft)
                Debug.Log("Mano izquierda haciendo pinch (cerrando)");
        }
    }
}

