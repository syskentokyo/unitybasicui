using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SyskenTLib.BasicUI
{
    public class AlertView : MonoBehaviour
    {
        [SerializeField] private Animator _targetAnimator;
        [SerializeField] private GameObject _targetRoot;


        private Coroutine _currentCoroutine;
        
        // Start is called before the first frame update
        void Start()
        {
            _targetRoot.SetActive(false);
        }


        #region 表示、閉じる
        [ContextMenu("Show")]
        public void ShowAlert()
        {
            StopCloseView();
            
            _targetRoot.SetActive(true);
            _targetAnimator.SetBool("isOpen",true);
        }

        [ContextMenu("Hide")]
        public void HideAlert()
        {
            StartCloseView();
        }
        #endregion

        public void OnTouchedCloseButton()
        {
            HideAlert();
        }

        private void StartCloseView()
        {
            StopCloseView();
            _currentCoroutine = StartCoroutine(CloseProcess());
        }

        private void StopCloseView()
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
                _currentCoroutine = null;
            }
        }

        private IEnumerator CloseProcess()
        {
            _targetAnimator.SetBool("isOpen",false);
            yield return new WaitForSeconds(3.0f);
            _targetRoot.SetActive(false);
            
            yield return null;
        }
        
        
        
        
    }
}
