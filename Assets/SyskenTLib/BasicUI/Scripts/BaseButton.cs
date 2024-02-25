using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SyskenTLib.BasicUI
{

    /// <summary>
    /// 取得できるボタンイベント
    /// </summary>
    public enum ButtonEventType:int 
    {
        Click=0,
        FirstClick=10,
        LongPress=100,
        Down=2101,
        Up=3102,
        Enter=4103,
        Exit=5105,
        Drag=6107,
    }
    
    public class BaseButton : MonoBehaviour
    {

        /// <summary>
        /// ボタンのイベント通知先
        /// </summary>
        public UnityEvent<ButtonEventType> _onUIEvent;

        [Header("細かい調整")]
        ///
        /// 長押ししたとするまでの時間
        ///
        [SerializeField] private float _longPressTimeSec = 3.0f;


        /// <summary>
        /// 連続クリックを無視するか
        /// </summary>
        [SerializeField] private bool _isIgnoreContinusClick = true;
        
        ///
        /// 次のクリック無視するまでの時間
        ///
        [SerializeField] private float _ignoreClickTimeSec = 0.3f;
        

        [Header("内部")] 
        private Coroutine _currentLongPressCheckCoroutine;

        private DateTime _lastClickTime=DateTime.Now;
        
        /// <summary>
        /// 最初のクリックか判定する
        /// </summary>
        private bool _isDoneFirstClick = false;
        
        
        
        
        #region 長押し

        private void CheckLongPress(bool isDown)
        {
            if (isDown == true)
            {
                //イベント通知
                _onUIEvent?.Invoke(ButtonEventType.Down);

                StartCheckLongPressTime();
            }
            else
            {
                //指を上げたとき
                
                //イベント通知
                _onUIEvent?.Invoke(ButtonEventType.Up);

                StopCheckLongPressTime();

                // Debug.Log("ボタンから手を上げました");
            }
        }

        private void StartCheckLongPressTime()
        {
            if (_currentLongPressCheckCoroutine != null)
            {
                StopCoroutine(_currentLongPressCheckCoroutine);
                _currentLongPressCheckCoroutine = null;
            }

            _currentLongPressCheckCoroutine = StartCoroutine(CheckLongPressTime());
        }

        private void StopCheckLongPressTime()
        {
            if (_currentLongPressCheckCoroutine != null)
            {
                StopCoroutine(_currentLongPressCheckCoroutine);
                _currentLongPressCheckCoroutine = null;
            }
        }

        private IEnumerator CheckLongPressTime()
        {
            yield return new WaitForSeconds(_longPressTimeSec);
            
            //長押し条件を満たした場合
            // Debug.Log("長押ししました");
            
            
            _onUIEvent?.Invoke(ButtonEventType.LongPress);
            
            
            yield return null;
        }
        

        #endregion

        #region クリック

        private void CheckClick()
        {
            DateTime nowTime = DateTime.Now;
            TimeSpan clickProgressTime = nowTime - _lastClickTime;
            
            // Debug.Log("クリックしています。"+clickProgressTime.TotalSeconds );

            if (_isDoneFirstClick == false)
            {
                //最初のクリック時
                _isDoneFirstClick = true;
                
                // Debug.Log("最初のクリックしています。");
                
                //イベント通知
                _onUIEvent?.Invoke(ButtonEventType.FirstClick);
            }
            
            
            

            if (_isIgnoreContinusClick == true)
            {
                //
                // 連続クリック防止がオンの場合
                //
                if (clickProgressTime.TotalSeconds > _ignoreClickTimeSec)
                {
                    //前回クリックしてから一定時間立った場合に、再度クリックした場合
                    
                    _lastClickTime = DateTime.Now;
                    
                    //イベント通知
                    _onUIEvent?.Invoke(ButtonEventType.Click);
                }
                else
                {
                    _lastClickTime = DateTime.Now;
                    
                    // Debug.Log("連続クリックしています。" );
                }
            }
            else
            {
                //
                // 連続クリック防止がオフの場合
                //
            
                //イベント通知
                _onUIEvent?.Invoke(ButtonEventType.Click);
            }
            
        }

        #endregion


        #region イベント受信先

        public void OnButtonEventDown(BaseEventData eventData)
        {
            CheckLongPress(isDown: true);
        }
        
        public void OnButtonEventUp(BaseEventData eventData)
        {
            CheckLongPress(isDown: false);
        }
        
        public void OnButtonEventEnter(BaseEventData eventData)
        {
            // Debug.Log("押し込み中");
            
            //イベント通知
            _onUIEvent?.Invoke(ButtonEventType.Enter);
        }
        
        public void OnButtonEventExit(BaseEventData eventData)
        {

            
            // Debug.Log("押し込み終了");
            
            //イベント通知
            _onUIEvent?.Invoke(ButtonEventType.Exit);
            
        }
        
        public void OnButtonEventDrag(BaseEventData eventData)
        {
            //イベント通知
            _onUIEvent?.Invoke(ButtonEventType.Drag);
            
            
            // Debug.Log("ドラッグ中");
        }

        public void OnButtonEventClick()
        {

            CheckClick();
 
        }
        

        #endregion
    }
}
