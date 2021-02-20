using Demo.Models.Common;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Demo.Models.Content
{
    public class ProductRef : ModelRef, IEquatable<ProductRef>
    {
        public ProductRef(string value) : base(value)
        {
        }

        public static ProductRef Empty => 
            new ProductRef(string.Empty);

        public static ProductRef CreateUnique() =>
            new ProductRef(Guid.NewGuid().ToString());

        public bool Equals([AllowNull] ProductRef other) =>
            base.Equals(other);
    }
}
