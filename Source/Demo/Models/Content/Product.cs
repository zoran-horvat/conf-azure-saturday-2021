using Demo.Models.Authentication;

namespace Demo.Models.Content
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string OwnerKey { get; private set; }
        public string Key { get; private set; }

        public ProductRef Reference
        {
            get => new ProductRef(this.Key);
            private set => this.Key = value.Value;
        }

        public Product(int id, string name, UserRef owner, ProductRef reference)
        {
            this.Id = id;
            this.Name = name;
            this.OwnerKey = owner.Value;
            this.Reference = reference;
        }

        private Product() : this(0, string.Empty, UserRef.Empty, ProductRef.Empty) { }

        public static Product CreateNew(string name, UserRef owner) =>
            new Product(0, name, owner, ProductRef.CreateUnique());

        public override string ToString() => Name;
    }
}
