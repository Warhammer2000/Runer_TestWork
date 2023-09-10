using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runer
{
    //public class VisabilityRegister : MonoBehaviour
    //{
    //    private List<Renderer> renderers;

    //    public event Action Disappeared;
    //    public event Action Appeared;

    //    public bool IsVisible { get; private set; }

    //    public void Awake()
    //    {
    //        renderers = new List<Renderer>();
    //        GetComponentsInChildren(renderers);
    //    }

    //    public void Update()
    //    {
    //        foreach (Renderer r in renderers)
    //        {
    //            if (r.isVisible)
    //            {
    //                bool wasVsisble = IsVisible;
    //                IsVisible = true;
    //                if (!wasVsisble)
    //                {
    //                    Appeared?.Invoke();
    //                }
    //                return;
    //            }
    //        }

    //        if (IsVisible == true)
    //        {
    //            IsVisible = false;
    //            Disappeared?.Invoke();
    //        }
    //    }
    //}
}