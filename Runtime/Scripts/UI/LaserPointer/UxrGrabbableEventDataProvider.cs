using System.Collections;
using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Manipulation;
using UltimateXR.UI.UnityInputModule;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UltimateXR.UI
{
    public class UxrGrabbableEventDataProvider : UxrInteractableEventDataProvider
    {
        private class UxrGrabbablePointerEventData : UxrInteractableEventData
        {
            public UxrGrabbableObject Grabbable;
        }

        private UxrLaserPointer _laserPointer;
        private UxrGrabbablePointerEventData _data;
        private void Start()
        {
            _laserPointer = GetComponent<UxrLaserPointer>();
        }

        private void Update()
        {
            var ray = new Ray(_laserPointer.LaserPos, _laserPointer.LaserDir);

            if (Physics.Raycast(ray,
                    out RaycastHit hit,
                    _laserPointer.MaxRayLength,
                    _laserPointer.BlockingMask,
                    _laserPointer.TriggerCollidersInteraction))
            {
                var grabbable = hit.collider.gameObject.GetComponentInChildren<UxrGrabbableObject>();

                _data = new UxrGrabbablePointerEventData()
                {
                    Distance = hit.distance,
                    HasData = grabbable != null,
                    IsInteractive = grabbable != null ? grabbable.IsGrabbable : false,
                    Grabbable = grabbable
                };
            }

            if(_laserPointer.IsClickedThisFrame() && _data.HasData)
            {
                Debug.Log("Grabbed!", this);
                //TODO: This does grab the object but the behaviour of the grabber and the grabbed objects are wonky...
                UxrGrabManager.Instance.GrabObject(UxrAvatar.LocalAvatar.GetGrabber(_laserPointer.HandSide), _data.Grabbable, 0, false);
            }
        }

        public override UxrInteractableEventData GetData()
        {
            return _data;
        }
    }
}
