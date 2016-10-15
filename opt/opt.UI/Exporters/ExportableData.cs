using System;

// TODO: Add XML comments

namespace opt.UI.Exporters
{
    [Flags]
    public enum ExportableData
    {
        None = 0,
        Parameters = 1,
        // Constants = 2,
        Criteria = 4,
        FunctionalConstraints = 8,
        // CriterialConstraints = 16
        Experiments = 32,
        ValidExperiments = 64,
        // Properties = 128,
        ParetoFront = 256,
        Results = 512
    }
}