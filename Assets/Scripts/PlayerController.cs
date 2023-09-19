using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction LeftMouseButton;
    public InputAction RightMouseButton;

    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private TextMeshProUGUI weaponGUI;
    private Weapon currentWeapon;
    private int currentWeaponIndex;
    private void OnEnable()
    {
        RightMouseButton.Enable();
        LeftMouseButton.Enable();
    }

    private void OnDisable()
    {
        RightMouseButton.Disable();
        LeftMouseButton.Disable();
    }
    private void Start()
    {
        UnequipAllWeapons();
        EquipWeapon(0);
        LeftMouseButton.performed += OnLeftButtonClicked;
        RightMouseButton.performed += OnRightButtonClicked;
    }

    private void OnRightButtonClicked(InputAction.CallbackContext callbackContext)
    {
        UnequipAllWeapons();
        EquipWeapon(currentWeaponIndex+1);
    }

    private void OnLeftButtonClicked(InputAction.CallbackContext callbackContext)
    {
        currentWeapon.Attack();
    }
    private void UnequipAllWeapons()
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.Unequip();
        }
    }

    private void EquipWeapon(int weaponIndex)
    {
        weaponIndex %= weapons.Count;
        currentWeapon = weapons[weaponIndex].Equip();
        currentWeaponIndex = weaponIndex;
        weaponGUI.text = currentWeapon.WeaponName;
    }

    private void EquipWeapon(string weaponName)
    {
        foreach (Weapon weapon in weapons)
        {
            if(weapon.WeaponName == weaponName)
            {
                weapon.Equip();
                currentWeaponIndex = weapons.IndexOf(weapon);
                weaponGUI.text = weaponName;
                return;
            }
        }
    }
}
