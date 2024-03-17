using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace SyskenTLib.BasicUI
{
    public class BaseTextScrollView : MonoBehaviour
    {
        [SerializeField] private GameObject _targetRoot;
        [SerializeField] private ScrollRect _mainScrollRect;
        [SerializeField] private ContentSizeFitter _mainContentSizeFilter;
        [SerializeField] private TextMeshProUGUI _targetTextView;

        public void SetText(string txt)
        {
            _targetTextView.text = txt;
        }
        
        
        public void ShowView()
        {
            _targetRoot.SetActive(true);
        }
        
        
        public void HideView()
        {
            _targetRoot.SetActive(false);
        }

        public void ResetScrollPosition()
        {
            _mainScrollRect.StopMovement(); 
            _mainScrollRect.verticalNormalizedPosition = 1.0f;
            _mainContentSizeFilter.SetLayoutVertical();
        }
    }
}
