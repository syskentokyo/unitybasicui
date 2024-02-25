using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SyskenTLib.BasicUI
{
    public class FirstClickAutoDeleteButton : MonoBehaviour
    {

        public void OnTouchedFirstClick(ButtonEventType eventType)
        {
            if (eventType == ButtonEventType.FirstClick
                &&this.gameObject != null)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
