using System;
namespace Net1_1
{
    public static class Identification
    {
        public static void GenerationId(this Entity entity)
        {
            entity.Id = Guid.NewGuid();
        }
    }
}