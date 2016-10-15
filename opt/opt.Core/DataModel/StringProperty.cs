using System;

// TODO: Consider using generics

namespace opt.DataModel
{
    /// <summary>
    /// Defines string property
    /// </summary>
    [Serializable]
    public sealed class StringProperty : CustomProperty
    {
        public string Value { get; set; }

        public StringProperty(string value)
        {
            Value = value;
        }

        public override CustomProperty Clone()
        {
            return new StringProperty(Value);
        }

        public override string Name
        {
            get { return typeof(StringProperty).Name; }
        }
    }
}