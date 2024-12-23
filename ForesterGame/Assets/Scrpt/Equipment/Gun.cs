using UnityEngine;
using Scrpt.Equipment;

public class Gun : Items
{
    [SerializeField] private Light _light;
    public override void Use()
    {
        _light.enabled = !_light.enabled;
    }
}

