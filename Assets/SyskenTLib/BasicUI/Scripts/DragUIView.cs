using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

namespace SyskenTLib.BasicUI
{
    public class DragUIView : MonoBehaviour
    {
        private Touch _lastTargetTouch;

        private void Update()
        {
            #if !UNITY_EDITOR &&( UNITY_IOS || UNITY_ANDROID)
            
            
            //
            // TouchPhase.Beganを取得するためにUpdateで処理
            //
            if (Input.touches.Length > 0)
            {
                Input.touches.ToList().ForEach(touchInfo =>
                {
                    if (touchInfo.phase == TouchPhase.Began)
                    {
                        //今開始されたタップの座標を使う
                        _lastTargetTouch = touchInfo;
                    }
                });



            }
            #endif
        }

        public void OnDragUI(BaseEventData eventData)
        {
            GameObject selectedUIObject = this.gameObject;
            RectTransform targetRectTransform = selectedUIObject.GetComponent<RectTransform>();


            Vector2 currentDragPosition = GetTouchPosition();
            
            // Debug.Log(currentDragPosition);
            
            targetRectTransform.position=currentDragPosition;

        }
        
        

        private Vector2 GetTouchPosition()
        {
            #if !UNITY_EDITOR &&( UNITY_IOS || UNITY_ANDROID)
            if (Input.touches.Length > 0)
            {
                Input.touches.ToList().ForEach(touchInfo =>
                {
                    if (touchInfo.fingerId == _lastTargetTouch.fingerId)
                    {
                        //今開始されたタップの座標を使う
                        _lastTargetTouch = touchInfo;
                    }
                });



            }

            Vector2 currentDragPosition =_lastTargetTouch.position;

            
            return currentDragPosition;


#else

            Vector2 currentDragPosition = Input.mousePosition;

            return currentDragPosition;
            
            #endif


            return Vector2.zero;
        }
    }
}
