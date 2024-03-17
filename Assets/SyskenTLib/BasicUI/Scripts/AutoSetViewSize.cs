using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace SyskenTLib.BasicUI
{
    public class AutoSetViewSize : MonoBehaviour
    {

        [SerializeField] private RectTransform _targetRectTransform;

        [SerializeField] private float _sizeRatio = 0.8f;
        
        
        void Start()
        {
            
            if (Screen.width > Screen.height)
            {
                //横長
                _targetRectTransform.sizeDelta = new Vector2(Screen.width , Screen.height* _sizeRatio);
            }
            else
            {
                //縦長
                _targetRectTransform.sizeDelta = new Vector2(Screen.width * _sizeRatio, Screen.height);
            }
        }
    }
}
