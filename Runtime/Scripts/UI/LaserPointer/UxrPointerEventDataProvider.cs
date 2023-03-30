using System.Collections;
using System.Collections.Generic;
using UltimateXR.UI.UnityInputModule;
using UnityEngine;

namespace UltimateXR.UI
{
    public abstract class UxrPointerEventDataProvider : MonoBehaviour
    {
        public abstract IUxrPointerEventData GetData();
    }
}
