using System.Collections;
using System.Collections.Generic;
using UltimateXR.UI.UnityInputModule;
using UnityEngine;

namespace UltimateXR.UI
{
    public abstract class UxrInteractableEventDataProvider : MonoBehaviour
    {
        public class UxrInteractableEventData
        {
            /// <summary>
            /// RaycastResult associated with the current event.
            /// </summary>
            public float Distance { get; internal set; }

            /// <summary>
            ///     Gets whether the current raycast target can be interacted with
            /// </summary>
            public virtual bool IsInteractive { get; internal set; }

            /// <summary>
            ///     Gets whether the event data contains valid information.
            /// </summary>
            public virtual bool HasData { get; internal set; }
        }

        public abstract UxrInteractableEventData GetData();
    }
}
