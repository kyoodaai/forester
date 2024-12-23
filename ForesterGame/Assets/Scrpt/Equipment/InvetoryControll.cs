using UnityEngine;

namespace Scrpt.Equipment
{
    public class InvetoryControll : MonoBehaviour
    {
        [SerializeField] private Items[] _itemsArray;
        private int currentItem = -1;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchItem(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchItem(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SwitchItem(2);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && currentItem >= 0)
            {
                _itemsArray[currentItem].Use();
            }
        }

        void SwitchItem(int index)
        {
            if (currentItem == index)
            {
                _itemsArray[currentItem].TurnOff();
                currentItem = -1;
                return;
            }
            if (currentItem >= 0)
            {
                _itemsArray[currentItem].TurnOff();
            }
        
            _itemsArray[index].TurnOn();
            currentItem = index;
        }
    }
}
