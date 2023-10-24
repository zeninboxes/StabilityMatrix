﻿using System;
using System.Collections.Generic;
using StabilityMatrix.Core.Models.Api.Comfy.Nodes;
using StabilityMatrix.Core.Models.Api.Comfy.NodeTypes;

namespace StabilityMatrix.Avalonia.Models.Inference;

public class ModuleApplyStepEventArgs : EventArgs
{
    public required ComfyNodeBuilder Builder { get; init; }

    public NodeDictionary Nodes => Builder.Nodes;

    /// <summary>
    /// Temporary conditioning apply step, used by samplers to apply control net.
    /// </summary>
    public (
        ConditioningNodeConnection Positive,
        ConditioningNodeConnection Negative
    ) Conditioning { get; set; }

    /// <summary>
    /// Index of the step in the pipeline.
    /// </summary>
    public int StepIndex { get; init; }

    /// <summary>
    /// Index
    /// </summary>
    public int StepTypeIndex { get; init; }

    /// <summary>
    /// Generation overrides (like hires fix generate, current seed generate, etc.)
    /// </summary>
    public IReadOnlyDictionary<Type, bool> IsEnabledOverrides { get; init; } =
        new Dictionary<Type, bool>();
}
