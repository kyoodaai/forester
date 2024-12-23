using System;
using UnityEngine;

namespace Scrpt.Equipment
{
    public abstract class Items : MonoBehaviour, UseCase
    {
        private Animator _animator;
        private string OnItemTrigger = "UseON";
        private string OffItemTrigger = "UseOff";

        private void Start()
        {
            _animator = gameObject.GetComponent<Animator>();
        }

        public virtual void Use()
        {
        }

        public void TurnOn()
        {
            _animator.SetTrigger(OnItemTrigger);
        }

        public void TurnOff()
        {
            _animator.SetTrigger(OffItemTrigger);
        }
    }
}
