using UnityEngine;
using Resources;
using UnityEngine.UI;

namespace UI {
    public class ReagentUI : MonoBehaviour {
        public Text ReagentName;
        public Text ReagentAction;

        void Awake() {

        }

        public void Set(Reagent reagent = null) {
            ReagentName.text = "";
            ReagentAction.text = "";

            if(reagent != null) {
                ReagentName.text = reagent.Name;

                string piecesText = "";
                foreach(var piece in reagent.Pieces) {
                    piecesText += piece.Origin.Type.ToString() + ",";
                }

                ReagentAction.text = piecesText;
            }
        }
    }
}