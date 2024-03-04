using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SyskenTLib.BasicUI
{
    public class VirtualKeyBoardManager : MonoBehaviour
    {
        public UnityEvent<VirtualKeyboardKey> _onInputKeyEvent;
        
        public void OnInputKey(VirtualKeyboardKey key)
        {
            Debug.Log("VirtualKeyBoard= "+key);
            _onInputKeyEvent?.Invoke(key);
        }
    }
}
