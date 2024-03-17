using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SyskenTLib.BasicUI
{
    public class AlertView : MonoBehaviour
    {
        [SerializeField] protected Animator _targetAnimator;
        [SerializeField] protected GameObject _targetRoot;


        private Coroutine _currentCoroutine;


        #region 表示、閉じる
        [ContextMenu("Show")]
        public  void ShowAlert()
        {
            StartOpenView();
        }

        [ContextMenu("Hide")]
        public void HideAlert()
        {
            StartCloseView();
        }

        /// <summary>
        /// すぐ閉じる
        /// </summary>
        public void HideSoonAlert()
        {
            StartCloseView(0.01f);
        }
        #endregion

        public void OnTouchedCloseButton()
        {
            HideAlert();
        }


        #region Open


        protected virtual void StartOpenView()
        {
            StopOpenView();

            AnimationClip[] animationClipArray = _targetAnimator.runtimeAnimatorController.animationClips;

            float viewAnimationTimeSec = 0.01f;
            foreach (var animationClip in animationClipArray)
            {
                if (animationClip.name == "Open")
                {
                    viewAnimationTimeSec = animationClip.length;
                }
            }
            
            _currentCoroutine = StartCoroutine(OpenProcess(viewAnimationTimeSec+0.01f));
        }
        
        protected virtual  void StopOpenView()
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
                _currentCoroutine = null;
            }
        }

        protected virtual  IEnumerator OpenProcess(float viewAnimationTimeSec)
        {
            _targetRoot.SetActive(true);
            _targetAnimator.SetBool("isOpen",true);
            
            yield return new WaitForSeconds(viewAnimationTimeSec);
            OnCompletedOpen();//完了
            yield return null;
        }

        protected virtual void OnCompletedOpen()
        {
            
        }

        

        #endregion

        #region Close



        protected virtual  void StartCloseView(float viewAnimationTimeSec = 3.0f)
        {
            StopCloseView();
            _currentCoroutine = StartCoroutine(CloseProcess(viewAnimationTimeSec));
        }

        protected virtual  void StopCloseView()
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
                _currentCoroutine = null;
            }
        }

        protected virtual  IEnumerator CloseProcess(float viewAnimationTimeSec)
        {
            _targetAnimator.SetBool("isOpen",false);
            yield return new WaitForSeconds(viewAnimationTimeSec);
            _targetRoot.SetActive(false);
            
            yield return null;
        }
        
                

        #endregion
        
        
    }
}
