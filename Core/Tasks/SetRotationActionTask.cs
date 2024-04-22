﻿using StudioScor.Utilities;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.GridLayoutGroup;

namespace StudioScor.RotationSystem
{
    [Serializable]
    public class SetRotationActionTask : ActionTask, ISubActionTask
    {
        [Header(" [ Ser Rotation Action Task ] ")]
        [SerializeField] private bool _isImmediately = false;
        [SerializeReference]
#if SCOR_ENABLE_SERIALIZEREFERENCE
        [SerializeReferenceDropdown]
#endif
        private IDirectionVariable _direction = new LocalDirectionVariable(Vector3.forward);

        public bool IsFixedUpdate => false;

        private IRotationSystem _rotationSystem;

        private SetRotationActionTask _original;

        protected override void SetupTask()
        {
            base.SetupTask();

            _rotationSystem = Owner.GetRotationSystem();

            _direction.Setup(Owner);
        }

        public override IActionTask Clone()
        {
            var clone = new SetRotationActionTask();

            clone._original = this;
            clone._direction = _direction.Clone() as IDirectionVariable;

            return clone;
        }

        protected override void EnterTask()
        {
            base.EnterTask();

            var isImmediately = _original is null ? _isImmediately : _original._isImmediately;
            
            if (isImmediately)
            {
                Vector3 direction = _direction.GetValue();

                Quaternion rotation = Quaternion.LookRotation(direction, Owner.transform.up);

                _rotationSystem.SetRotation(rotation);
            }
            else
            {
                Vector3 direction = _direction.GetValue();

                _rotationSystem.SetLookDirection(direction);
            }
        }

        public void UpdateSubTask(float normalizedTime)
        {
        }
    }
}
