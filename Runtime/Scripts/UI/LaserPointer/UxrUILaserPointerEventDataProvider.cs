using System.Collections;
using System.Collections.Generic;
using UltimateXR.UI.UnityInputModule;
using UnityEngine;

namespace UltimateXR.UI
{
    /// <summary>
    /// Implementation of the <see cref="UxrLaserPointerEventDataProvider"/> to make the <see cref="UxrLaserPointer"/> work with UI Canvases
    /// </summary>
    public class UxrUILaserPointerEventDataProvider : UxrLaserPointerEventDataProvider
    {
        private UxrLaserPointer pointer;
        private UxrLaserPointerEventData _data = new UxrLaserPointerEventData();
        private void Start()
        {
            pointer = GetComponent<UxrLaserPointer>();
        }

        public override UxrLaserPointerEventData GetData()
        {
            UxrPointerEventData uiData = null;

            if (pointer != null )
               uiData = UxrPointerInputModule.Instance != null ? UxrPointerInputModule.Instance.GetPointerEventData(pointer) : null;

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
