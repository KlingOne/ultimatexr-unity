using System.Collections;
using System.Collections.Generic;
using UltimateXR.UI.UnityInputModule;
using UnityEngine;

namespace UltimateXR.UI
{
    public class UxrUIPointerEventDataProvider : UxrPointerEventDataProvider
    {
        private UxrLaserPointer pointer;
        private UxrFingerTip tip;

        private void Start()
        {
            //TODO: This is only necessary since UxrPointerInputModule.Instance.GetPointerEventData works with distinct types. Maybe this can be simplified?
            pointer = GetComponent<UxrLaserPointer>();
            tip = GetComponent<UxrFingerTip>();
        }

        public override IUxrPointerEventData GetData()
        {
            if(pointer != null )
                return UxrPointerInputModule.Instance != null ? UxrPointerInputModule.Instance.GetPointerEventData(pointer) : null;
            else if(tip != null )
                return UxrPointerInputModule.Instance != null ? UxrPointerInputModule.Instance.GetPointerEventData(tip) : null;

            return null;
        }
    }
}
