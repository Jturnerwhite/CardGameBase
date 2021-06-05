using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI {
	public class PercentScale : MonoBehaviour {

		[SerializeField]
		private int Percent;
		private Transform VariableBar { get; set; }
        private Transform BarFront { get; set; }

		// Use this for initialization
		void Awake() {
			VariableBar = transform;
			BarFront = VariableBar.Find("BarFront");
			UpdateScale(100);
		}

		void Update() {
			UpdateScale();
		}

		public void UpdateScale(int? newPercent = null) {
			if(newPercent.HasValue) {
				Percent = newPercent.Value;
			}
			
			if (Percent < 0) {
				Percent = 0;
			}

			if(VariableBar != null) {
				float newScale = GetNewScale();
				if(VariableBar.localScale.x != newScale) {
					VariableBar.localScale = new Vector3(newScale, VariableBar.localScale.y, VariableBar.localScale.z);
				}
			}
		}

		private float GetNewScale() {
			return ((float)Percent / 100f);
		}

		public void SetColor(Color color) {
            var BarSprite = BarFront.GetComponent<SpriteRenderer>();
			BarSprite.color = color;
		}
	}
}
