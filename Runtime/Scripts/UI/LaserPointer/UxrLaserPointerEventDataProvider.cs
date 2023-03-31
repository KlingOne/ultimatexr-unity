using System.Collections;
using System.Collections.Generic;
using UltimateXR.UI.UnityInputModule;
using UnityEngine;

namespace UltimateXR.UI
{
    /// <summary>
    /// Base class to provide EventData for the LaserPointer
    /// </summary>
    public abstract class UxrLaserPointerEventDataProvider : MonoBehaviour
    {
        public class UxrLaserPointerEventData
        {
            /// <summary>
            /// RaycastResult associated with the current event.
            /// </summary>
            public float Distance { get; set; }

            /// <summary>
            ///     Gets whether the current raycast target can be interacted with
            /// </summary>
            public virtual bool IsInteractive { get; set; }

            /// <summary>
            ///     Gets whether the event data contains valid information.
            /// </summary>
            public virtual bool HasData { get; set; }
        }

        public abstract UxrLaserPointerEventData GetData();
    }
}
