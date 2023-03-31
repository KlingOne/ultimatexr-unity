using System.Collections;
using System.Collections.Generic;
using UltimateXR.UI.UnityInputModule;
using UnityEngine;

namespace UltimateXR.UI
{
    public class UxrUIInteractableEventDataProvider : UxrInteractableEventDataProvider
    {
        private UxrLaserPointer pointer;
        private UxrFingerTip tip;
        private UxrInteractableEventData _data = new UxrInteractableEventData();
        private void Start()
        {
            //TODO: This is only necessary since UxrPointerInputModule.Instance.GetPointerEventData works with distinct types. Maybe this can be simplified?
            pointer = GetComponent<UxrLaserPointer>();
            tip = GetComponent<UxrFingerTip>();
        }

        public override UxrInteractableEventData GetData()
        {
            UxrPointerEventData uiData = null;

            if (pointer != null )
               uiData = UxrPointerInputModule.Instance != null ? UxrPointerInputModule.Instance.GetPointerEventData(pointer) : null;
            else if(tip != null )
               uiData = UxrPointerInputModule.Instance != null ? UxrPointerInputModule.Instance.GetPointerEventData(tip) : null;

            if (uiData != null)
            {
                _data.HasData = uiData.HasData;
                _data.Distance = uiData.pointerCurrentRaycast.distance;
                _data.IsInteractive = uiData.IsInteractive;
            }
            else
            {
                //reset the data (instead of new to prevent garbage)
                _data.HasData = false;
                _data.Distance = float.MaxValue;
                _data.IsInteractive = false;
            }

            return _data;
        }
    }
}
