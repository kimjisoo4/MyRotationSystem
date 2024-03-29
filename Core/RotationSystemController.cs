﻿using UnityEngine;
using StudioScor.Utilities;

namespace StudioScor.RotationSystem
{
    [AddComponentMenu("StudioScor/RotationSystem/Simple Rotation System Controller Component", order: 30)]
    public class SimpleRotationSystemController : BaseMonoBehaviour
    {
        [Header(" [ Rotation System Controller ] ")]
        [SerializeField] private RotationSystemComponent _RotationSystem;

        [Header(" [ Rotation States] ")]
        [SerializeField] private RotationToLookDirection _LookDirectionState;
        [SerializeField] private RotationToLookTarget _LookTargetState;
        [SerializeField] private RotationToCameraDirection _LookCameraDirectionState;

        private void Reset()
        {
            gameObject.TryGetComponentInParentOrChildren(out _RotationSystem);
            gameObject.TryGetComponentInParentOrChildren(out _LookDirectionState);
            gameObject.TryGetComponentInParentOrChildren(out _LookTargetState);
            gameObject.TryGetComponentInParentOrChildren(out _LookCameraDirectionState);
        }
        private void Awake()
        {
            if (!_RotationSystem)
            {
                if (!gameObject.TryGetComponentInParentOrChildren(out _RotationSystem))
                {
                    LogError("Rotation System Is NULL!!");
                }
            }
            if (!_LookDirectionState)
            {
                if (!gameObject.TryGetComponentInParentOrChildren(out _LookDirectionState))
                {
                    LogError("Rotation Look Direction State Is NULL!!");
                }
            }
            if (!_LookTargetState)
            {
                if (!gameObject.TryGetComponentInParentOrChildren(out _LookTargetState))
                {
                    LogError("Rotation Look Target State Is NULL!!");
                }
            }
            if (!_LookCameraDirectionState)
            {
                if (!gameObject.TryGetComponentInParentOrChildren(out _LookCameraDirectionState))
                {
                    LogError("Rotation Camera Direction State Is NULL!!");
                }
            }
        }
        private void LateUpdate()
        {
            _RotationSystem.UpdateRotation(Time.deltaTime); 
        }

        public void SetTurnSpeed(float newSpeed)
        {
            
        }

        public void SetLookTarget(Transform target)
        {
            _RotationSystem.SetLookTarget(target);
        }
        public void SetLookDirection(Vector3 direction)
        {
            _RotationSystem.SetLookDirection(direction);
        }

        public void OnLookDirection()
        {
            //_RotationSystem.TrySetState(_LookDirectionState);
        }
        public void OnLookCameraDirection()
        {
            //_RotationSystem.TrySetState(_LookCameraDirectionState);
        }
        public void OnLookTargetDirection()
        {/*
            if (!_RotationSystem.TrySetState(_LookTargetState))
            {
                _RotationSystem.TrySetState(_LookDirectionState);
            }
*/
        }

    }
}