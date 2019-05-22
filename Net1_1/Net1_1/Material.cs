namespace Net1_1
{
    public abstract class Material : Entity
    {
        public Material(string description = null) : base(description)
        {
        }

        public abstract Material Clone();
    }
}