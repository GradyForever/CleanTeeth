namespace CleanTeeth.Domain.Enums;

/// <summary>
/// 预约状态枚举
/// </summary>
public enum AppiontmentStatus
{
    /// <summary>
    /// 已预约
    /// </summary>
    Scheduled = 1,

    /// <summary>
    /// 已取消
    /// </summary>
    Canceled = 2,

    /// <summary>
    /// 已完成
    /// </summary>
    Completed = 3,
}
