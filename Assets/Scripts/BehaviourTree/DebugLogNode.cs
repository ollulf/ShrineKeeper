using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphViewBehaviorTree;

public abstract class DebugLogNode : Node
{
    public string message;

    #region Overrides of Node

    /// <inheritdoc/>
    protected override void OnStart() =>
        Debug.Log($"OnStart: {message}");

    /// <inheritdoc/>
    protected override void OnStop() =>
        Debug.Log($"OnStart: {message}");

    /// <inheritdoc/>
    protected override State OnUpdate()
    {
        Debug.Log($"OnStart: {message}");
        return State.Success;
    }

    #endregion
}
