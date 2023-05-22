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
        protected float _distance;

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

        /// <summary>
        /// Gets called by the Laserpointer for the UxrLaserPointerEventDataProvider that is closest to avatar.
        /// Implement this method to create and return a UxrLaserPointerEventData object
        /// </summary>
        /// <returns>UxrLaserPointerEventData data object</returns>
        public abstract UxrLaserPointerEventData ProcessData();

        /// <summary>
        /// Gets the distance of the "hit" object
        /// Implement a custom distance calucation (e.g. a raycast) for your object type here
        /// </summary>
        /// <returns>The distance to the hit object</returns>
        public abstract float GetDistance();
    }
}
