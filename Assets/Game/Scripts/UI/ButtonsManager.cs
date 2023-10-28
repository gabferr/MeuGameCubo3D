using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ButtonsManager : MonoBehaviour
    {
        public List<MenuButtons> buttons;

        private void Awake()
        {
            ActivateButtons();
        }

        public void ActivateButtons()
        {
            foreach (MenuButtons button in buttons)
            {
                if (button != null)
                {
                    button.gameObject.SetActive(true);
                }
            }
        }
    }
}
