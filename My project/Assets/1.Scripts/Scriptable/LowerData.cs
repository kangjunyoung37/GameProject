using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터가 모션과 오프셋으로 무기를 내리는 데 필요한 정보를 포함합니다.
/// </summary>
[CreateAssetMenu(fileName ="SO_Lower_Name",menuName = "FPS Game/Shooter Pack/Lower Data",order = 0)]
public class LowerData : ScriptableObject
{
    #region PROPERTIES

    /// <summary>
    /// 보간 설정
    /// </summary>
    public SpringSettings Interpolation => interpolation;

    /// <summary>
    /// 위치 오프셋
    /// </summary>
    public Vector3 LocationOffset => locationOffset;

    /// <summary>
    /// 로테이션 오프셋
    /// </summary>
    public Vector3 RotationOffset => RotationOffset;

    #endregion

    #region FIELDS SERIALIZED

    [Title(label: "Interpolation")]

    [Tooltip("보간 설정")]
    [SerializeField]
    private SpringSettings interpolation = SpringSettings.Default();

    [Title(label: "Offsets")]

    [Tooltip("무기를 내린 상태에서 적용된 위치 오프셋값")]
    [SerializeField]
    private Vector3 locationOffset;

    [Tooltip("무기를 내린 상태에서 적용된 로테이션 오프셋")]
    [SerializeField]
    private Vector3 rotationOffset;

    #endregion
}
