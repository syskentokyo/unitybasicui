using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SyskenTLib.BasicUI
{
    public enum VirtualKeyboardKey : int
    {
        A=1,
        B=2,
        C=3,
        D=4,
        E=5,
        F=6,
        G=7,
        H=8,
        I=9,
        J=10,
        K=11,
        L=12,
        M=13,
        N=14,
        
    }
    
    public class VirtualKeyBoardButton : MonoBehaviour
    {
        [SerializeField] private VirtualKeyboardKey _key= VirtualKeyboardKey.A;
        
        public UnityEvent<VirtualKeyboardKey> _onInputKeyEvent;

        public void OnInputKey()
        {
            _onInputKeyEvent?.Invoke(_key);
        }
        
        
    }
}
