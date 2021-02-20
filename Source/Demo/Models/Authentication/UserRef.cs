using Demo.Models.Common;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Demo.Models.Authentication
{
    public class UserRef : ModelRef, IEquatable<UserRef>
    {
        public UserRef(string value) : base(value)
        {
        }

        public static UserRef Empty => 
            new UserRef(string.Empty);

        public bool Equals([AllowNull] UserRef other) =>
            base.Equals(other);
    }
}
