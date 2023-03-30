using UnityEngine.EventSystems;

namespace UltimateXR.UI.UnityInputModule
{
    public interface IUxrPointerEventData
    {
        /// <summary>
        /// RaycastResult associated with the current event.
        /// </summary>
        public RaycastResult pointerCurrentRaycast { get; set; }

        /// <summary>
        ///     Gets whether the current raycast target can be interacted with
        /// </summary>
        public bool IsInteractive { get; }

        /// <summary>
        ///     Gets whether the event data contains valid information.
        /// </summary>
        public bool HasData { get; }
    }
}
