using UnityEngine;

namespace SyskenTLib.BasicUI
{

    [DefaultExecutionOrder(-999)]
    public class AutoDontDestroy : MonoBehaviour
    {
        private void Awake()
        {
            if (gameObject.scene.name != "DontDestroyOnLoad")
            {
                DontDestroyOnLoad(gameObject);   
            }
            else
            {
                //すでに登録済みだった場合
                Destroy(gameObject);
            }
        }
    }
}
