using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Inventory : InventoryBehaviour
{
    #region FIELDS
    
    /// <summary>
    /// 무기 배열, 이 오브젝트의 자식 배열을 순서대로 가져옵니다.
    /// </summary>
    private WeaponBehaviour[] weapons;

    /// <summary>
    /// 현재 장착된 WeaponBehaviour
    /// </summary>
    private WeaponBehaviour equipped;

    /// <summary>
    /// 현재 장착하고 있는 index
    /// </summary>
    private int equippedIndex = -1;

    #endregion

    #region METHODS

    public override void Init(int equippedAtStart = 0)
    {
        weapons = GetComponentsInChildren<WeaponBehaviour>(true);

        foreach(WeaponBehaviour weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
        Equip(equippedAtStart);
    }

    public override WeaponBehaviour Equip(int index)
    {
        //무기가 없으면 아무것도 장비할 수 없습니다.
        if (weapons == null)
            return equipped;

        //인덱스 배열 범위 내에 있어야합니다.
        if (index > weapons.Length - 1)
            return equipped;

        //이미 장착한 무기를 장착하려고 한다면
        if (equippedIndex == index)
            return equipped;

        //현재 장착하고 있는 무기가 있으면 비활성화 합니다.
        if (equipped != null)
            equipped.gameObject.SetActive(false);
        
        //인덱스 업데이트
        equippedIndex = index;
        //장착된 무기를 업데이트 합니다.
        equipped = weapons[equippedIndex];
        //새롭게 장착된 무기를 활성화 합니다.
        equipped.gameObject.SetActive(true);

        return equipped;
    }


    #endregion

    #region GETTERS

    public override int GetLastIndex()
    {
        //
        int newIndex = equippedIndex - 1;
        if (newIndex < 0)
            newIndex = weapons.Length - 1;

        return newIndex;
    }

    public override int GetNextIndex()
    {
        int newIndex = equippedIndex + 1;
        if (newIndex > weapons.Length - 1)
            newIndex = 0;

        return newIndex;
    }

    public override WeaponBehaviour GetEquipped() => equipped;
    public override int GetEquippedIndex() => equippedIndex;


    #endregion
}
