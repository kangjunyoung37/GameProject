using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Inventory : InventoryBehaviour
{
    #region FIELDS
    
    /// <summary>
    /// ���� �迭, �� ������Ʈ�� �ڽ� �迭�� ������� �����ɴϴ�.
    /// </summary>
    private WeaponBehaviour[] weapons;

    /// <summary>
    /// ���� ������ WeaponBehaviour
    /// </summary>
    private WeaponBehaviour equipped;

    /// <summary>
    /// ���� �����ϰ� �ִ� index
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
        //���Ⱑ ������ �ƹ��͵� ����� �� �����ϴ�.
        if (weapons == null)
            return equipped;

        //�ε��� �迭 ���� ���� �־���մϴ�.
        if (index > weapons.Length - 1)
            return equipped;

        //�̹� ������ ���⸦ �����Ϸ��� �Ѵٸ�
        if (equippedIndex == index)
            return equipped;

        //���� �����ϰ� �ִ� ���Ⱑ ������ ��Ȱ��ȭ �մϴ�.
        if (equipped != null)
            equipped.gameObject.SetActive(false);
        
        //�ε��� ������Ʈ
        equippedIndex = index;
        //������ ���⸦ ������Ʈ �մϴ�.
        equipped = weapons[equippedIndex];
        //���Ӱ� ������ ���⸦ Ȱ��ȭ �մϴ�.
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