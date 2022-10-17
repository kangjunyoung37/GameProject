using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBehaviour : MonoBehaviour
{
    #region UNITY
    protected virtual void Awake(){}
    protected virtual void Start() {}
    protected virtual void Update() {}
    protected virtual void LateUpdate() {}
    #endregion UNITY

    #region GETTER
    
    /// <summary>
    /// ĳ���Ͱ� ���������� �߻��� ���� ���� ��ȯ�ϴ� �Լ�
    /// �ݵ��� �����ϰ� �������带 �����ϱ� ���� ��� 
    /// </summary>
    public abstract int GetShotsFired();
    /// <summary>
    /// ĳ���Ͱ� ���⸦ ������ �ִ��� Ȯ���ϴ� �Լ�
    /// </summary>
    public abstract bool IsLowered();
    
    /// <summary>
    /// �÷��̾��� ���� ī�޶� ����
    /// </summary>
    public abstract Camera GetCameraWold();

    /// <summary>
    /// �÷��̾��� �� ī�޶� ����
    /// </summary>
    public abstract Camera GetCameraDepth();

    //�κ��丮 ������ҿ� ���� ������ ����
    //public abstract InventoryBehaviour GetInventory();

    /// <summary>
    /// ��ź�� ���� ���� ��ȯ
    /// </summary>
    public abstract int GetGrenadesCurrent();
    
    /// <summary>
    /// ��ź�� �� ������ ��ȯ
    /// </summary>
    public abstract int GetGrenadesTotal();

    /// <summary>
    /// ���� ĳ���Ͱ� �޸��� �ִ��� ��ȯ
    /// </summary>
    public abstract bool IsRunning();

    /// <summary>
    /// ĳ���Ͱ� ���⸦ ��� �ִ��� ��ȯ
    /// </summary>
    public abstract bool IsHolstered();

    /// <summary>
    /// ĳ���Ͱ� ��ũ���� �ִ��� ��ȯ
    /// </summary>
    public abstract bool IsCrouching();

    /// <summary>
    /// ������������ ��ȯ
    /// </summary>
    public abstract bool IsReloading();

    /// <summary>
    /// ����ź�� ������ �ִ��� ��ȯ
    /// </summary>
    public abstract bool IsTrowingGrenade();

    /// <summary>
    /// �������������� ��ȯ
    /// </summary>
    public abstract bool IsMeleeing();
    
    /// <summary>
    /// ĳ���Ͱ� ���������� ��ȯ
    /// </summary>
    public abstract bool IsAiming();

    /// <summary>
    /// ���� Ŀ���� ����ִ��� ��ȯ
    /// </summary>
    public abstract bool isCursorLocked();

    /// <summary>
    /// ������ ��ǲ�� ��ȯ
    /// </summary>
    public abstract Vector2 GetInputMovement();

    /// <summary>
    /// Look��ǲ�� ��ȯ(��� ���� �ִ���)
    /// </summary>
    public abstract Vector2 GetInputLook();

    /// <summary>
    /// ĳ���Ͱ� ����ź�� �������� �÷��� �Ǵ� ����� Ŭ���� ��ȯ
    /// </summary>
    public abstract AudioClip[] GetAudioClipsGrenadeThrow();

    /// <summary>
    /// ĳ���Ͱ� ���������Ҷ� �÷��� �Ǵ� ����� Ŭ���� ��ȯ
    /// </summary>
    /// <returns></returns>
    public abstract AudioClip[] GetAudioClipsMelee();

    /// <summary>
    /// �÷��̾ �˻��������� ����
    /// </summary>
    public abstract bool IsInspecting();

    /// <summary>
    /// �÷��̾ �߻��ư�� ��� ������ �ִ��� ��ȯ
    /// </summary>
    public abstract bool isHoldingButtonFire();
    #endregion GETTER

    #region ANIMATION

    /// <summary>
    /// ������ ���⿡�� ź�Ǹ� ������ �ִϸ��̼�
    /// </summary>
    public abstract void EjectCasing();

    /// <summary>
    /// ĳ���Ͱ� ������ ������ ź���� ������ ä��ų� -1�� �����ϸ� ������ ä��ϴ�.
    /// </summary>
    /// <param name="amount">ź���� ��</param>
    public abstract void FillAmmunition(int amount);

    /// <summary>
    /// ����ź�� �����ϴ�.
    /// </summary>
    public abstract void Grenade();

    /// <summary>
    /// ���� ������ źâ�� Ȱ��ȭ�ϰų� ��Ȱ��ȭ �մϴ�.
    /// </summary>
    public abstract void SetActiveMagzine(int active);

    /// <summary>
    /// ��Ʈ �ִϸ��̼� ����
    /// </summary>
    public abstract void AnimationEndedBolt();

    /// <summary>
    /// ������ �ִϸ��̼� ����
    /// </summary>
    public abstract void AnimationEndedReload();

    /// <summary>
    /// ����ź ������ �ִϸ��̼� ����
    /// </summary>
    public abstract void AnimationEndedGrenadeThrow();

    /// <summary>
    /// ���� ���� �ִϸ��̼� ����
    /// </summary>
    public abstract void AnimationEndedMelee();

    /// <summary>
    /// �˻� �ִϸ��̼� ����
    /// </summary>
    public abstract void AnimationEndedInspect();

    /// <summary>
    /// ���⸦ ��� �ִϸ��̼� ����
    /// </summary>
    public abstract void AnimationEndedHolster();

    /// <summary>
    /// �������� ������ �����̵� �� ��� �����մϴ�.
    /// </summary>
    public abstract void SetSlideBack(int back);

    /// <summary>
    /// Į Active Ȱ��ȭ
    /// </summary>
    public abstract void SetActiveKnife(int active);
    #endregion ANIMATION


}