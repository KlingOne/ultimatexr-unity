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
        private UxrPointerEventData uiData = null;

        private void Start()
        {
            pointer = GetComponent<UxrLaserPointer>();
        }

        public override UxrLaserPointerEventData ProcessData()
        {
            if (uiData != null && uiData.pointerCurrentRaycast.distance > 0)
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

        public override float GetDistance()
        {
            _distance = -1f;

            if (pointer != null)
                uiData = UxrPointerInputModule.Instance != null ? UxrPointerInputModule.Instance.GetPointerEventData(pointer) : null;

            if (uiData != null && !uiData.IsNonUI && uiData.pointerCurrentRaycast.distance > 0)
                _distance = uiData.pointerCurrentRaycast.distance;
            else
                uiData = null;

            return _distance;
        }
    }
}
