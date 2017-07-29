using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.View.UserInterfaces.Battle.SelectTargetUI {
    public class TargetingPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


        public void OnPointerEnter(PointerEventData eventData) {
            this.gameObject.GetComponent<Image>().CrossFadeColor(Color.blue, 1, false, false);
        }

        public void OnPointerExit(PointerEventData eventData) {
            this.gameObject.GetComponent<Image>().CrossFadeColor(Color.white, 1, false, false);
        }
    }
}
