using UnityEngine;

namespace SyskenTLib.BasicUI
{
    public class AlertTextView : AlertView
    {
        [SerializeField] private BaseTextScrollView _baseTextScrollView;
        [SerializeField] private GameObject _textViewPrefab;

        protected void SetText(string txt)
        {
            _baseTextScrollView.SetText( txt);
        }
        
        
        protected override void StartOpenView()
        {
           
            _baseTextScrollView.HideView();
            
            base.StartOpenView();
            
        }
  
        
        protected override void OnCompletedOpen()
        {
            //
            // MEMO: Animationが終わって、レイアウト終了後に、スクロール位置を戻している
            // アニメーション中は、スクロール戻す位置が安定しないため。
            //
            
            _baseTextScrollView.ResetScrollPosition();
            _baseTextScrollView.ShowView();
        }

        

    }
}