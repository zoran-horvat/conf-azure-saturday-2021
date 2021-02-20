namespace Demo.Models.Common
{
    public abstract class ModelRef
    {
        public string Value { get; }

        public ModelRef(string value)
        {
            this.Value = value;
        }

        public override int GetHashCode() =>
            this.Value.GetHashCode();

        public override bool Equals(object obj) =>
            this.Equals(obj as ModelRef);

        public bool Equals(ModelRef other) =>
            !(other is null) && 
            other.GetType() == this.GetType() &&
            other.Value.Equals(this.Value);

        public static bool operator ==(ModelRef a, ModelRef b) =>
            a?.Equals(b) ?? b is null;

        public static bool operator !=(ModelRef a, ModelRef b) =>
            !(a == b);
    }
}
