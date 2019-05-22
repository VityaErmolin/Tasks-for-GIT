namespace Net1_1.Interface
{
    public interface IVersionable
    {
        byte[] GetVersion();
        void SetVersion(byte[] bytes);
    }
}