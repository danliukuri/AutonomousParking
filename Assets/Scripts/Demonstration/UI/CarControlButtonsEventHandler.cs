using System.Collections.Generic;
using System.Linq;
using AutomaticParking.Demonstration.Architecture;
using TMPro;
using UnityEngine;

namespace AutomaticParking.Demonstration.UI
{
    public class CarControlButtonsEventHandler : MonoBehaviour
    {
        private const string AiOnText = "Ai: on";
        private const string AiOffText = "Ai: off";

        [SerializeField] private TextMeshProUGUI swapControlButtonTMP;
        [SerializeField] private List<GameObject> aiBlocks;
        [SerializeField] private List<GameObject> playerBlocks;

        public void OnSwapControlButtonClick()
        {
            CarControlTypeChanger carControlTypeChanger = ServiceLocator.Instance.Get<CarControlTypeChanger>().First();
            carControlTypeChanger.ChangeCarControlType();
            SetTextAboutControl();
        }

        private void SetTextAboutControl()
        {
            bool isAiControlCar = ServiceLocator.Instance.Get<CarControlTypeChanger>().First().IsAiControlCar;
            swapControlButtonTMP.text = isAiControlCar ? AiOnText : AiOffText;
            aiBlocks.ForEach(block => block.SetActive(isAiControlCar));
            playerBlocks.ForEach(block => block.SetActive(!isAiControlCar));
        }
    }
}