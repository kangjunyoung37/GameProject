using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LaserType { LaserSight, Flashlight }

public class Laser : LaserBehaviour
{
    #region FIELDS SERIALIZED
    [Title(label: "Settings")]

    [Tooltip("사용자 인터페이스에 보일 Sprite")]
    [SerializeField]
    private Sprite sprite;

    [Tooltip("레이저 타입")]
    [SerializeField]
    private LaserType laserType;

    [Tooltip("레이저 사이트를 킬 수 있다면 참을 반환")]
    [SerializeField]
    private bool active = true;

    [Tooltip("True면 캐릭터가 달리는 동안 레이저가 자동으로 꺼집니다")]
    [SerializeField]
    private bool turnOffWhileRunning = true;

    [Tooltip("True면 캐릭터가 에임을 하는 동안 레이저가 자동으로 꺼집니다")]
    [SerializeField]
    private bool turnOffWhileAiming = true;

    [Title(label: "Audio")]
    [Tooltip("레이저를 토글하는 동안 플레이되는 AudioClip")]
    [SerializeField]
    private AudioClip toggleClip;

    [Tooltip("토글클립에 사용되는 오디오 세팅")]
    [SerializeField]
    private InfimaGames.LowPolyShooterPack.AudioSettings toggleAudioSettings;
    [Title(label: "Expandes Settings")]

    [Tooltip("레이저의 Transform")]
    [SerializeField]
    private Transform laserTransform;

    [ShowIf("laserType", LaserType.LaserSight)]
    [Tooltip("레이저 빔의 두께를 결정합니다")]
    [SerializeField]
    private float beamThickness = 1.2f;
    [ShowIf("laserType", LaserType.LaserSight)]
    [Tooltip("레이저 빔이 최대로 갈 수 있는 거리")]
    [SerializeField]
    private float beamMaxDistance = 500.0f;

    [Title(label:"Renderer")]

    [Tooltip("Laser의 Renderer")]
    [SerializeField]
    private Renderer LaserRender;

    //[Tooltip("플래쉬 라이트 렌더러")]
    //[SerializeField]
    private Light FlashRightLenderer;
    #endregion
    #region FIELDS

    /// <summary>
    /// 빔의 부모 오브젝트
    /// </summary>
    private Transform beamParent;

    /// <summary>
    /// 빔의 Renderer
    /// </summary>
    private Renderer beam;


    #endregion

    #region GETTERS

    public override Sprite GetSprite() => sprite;

    public override bool GetTurnOffWhileRunning() => turnOffWhileRunning;

    public override bool GetTurnOffWhileAiming() => turnOffWhileAiming;

    #endregion

    #region METHODS

    public override void Toggle()
    {
        active = !active;
        //재적용
        Reapply();

    }
    public override void Reapply()
    {
        if(laserTransform != null)
        {
            laserTransform.gameObject.SetActive(active);
        }
    }
    public override void Hide()
    {
        if(laserTransform != null)
        {
            laserTransform.gameObject.SetActive(false);
        }
    }

    public override void FPLaserOff()
    {
        LaserRender.enabled = false;
        if (beam != null)
            beam.enabled = false;

    }

    #endregion

    #region UNITY

    private void Awake()
    {

        if (laserTransform == null)
            return;
        beamParent = laserTransform.parent;
        beam = laserTransform.GetComponent<Renderer>();
        FlashRightLenderer = laserTransform.GetComponent<Light>();

    }
    private void Update()
    {
        if (laserTransform == null)
            return;
        float targetScale = beamMaxDistance;
        if (Physics.Raycast(new Ray(laserTransform.position,beamParent.forward),out RaycastHit hit,beamMaxDistance,8))
        {
            targetScale = hit.distance * 5.0f;
        }
        beamParent.localScale = new Vector3(beamThickness, beamThickness, targetScale);
    }
    #endregion



}
