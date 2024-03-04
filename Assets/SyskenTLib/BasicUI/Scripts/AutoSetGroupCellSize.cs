using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SyskenTLib.BasicUI
{
    public class AutoSetGroupCellSize : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;

        private int _cellHorizonCount = 3;
        
        // Start is called before the first frame update
        void Start()
        {
            AutoSet();  
        }

        // Update is called once per frame
        void Update()
        {
                  
        }

        private void AutoSet()
        {
            float viewOriginalWidth = this.gameObject.GetComponent<RectTransform>().rect.width;
            float spaceDistance = viewOriginalWidth/100.0f / _cellHorizonCount;

            float cellSize = (viewOriginalWidth - spaceDistance * _cellHorizonCount) / _cellHorizonCount;
            
            
            _gridLayoutGroup.spacing = new Vector2(spaceDistance, spaceDistance);

            _gridLayoutGroup.cellSize = new Vector2(cellSize, cellSize);
        }
    }
}
