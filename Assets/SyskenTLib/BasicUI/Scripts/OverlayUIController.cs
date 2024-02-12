using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SyskenTLib.BasicUI
{
    [DefaultExecutionOrder(-998)]
    public class OverlayUIController : MonoBehaviour
    {
        public static OverlayUIController Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
