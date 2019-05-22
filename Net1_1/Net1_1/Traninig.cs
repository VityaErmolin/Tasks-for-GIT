using System;
using Net1_1.Enums;
using Net1_1.Interface;
using Net1_1.Materials;

namespace Net1_1
{
    public class Traninig : Entity, IVersionable, ICloneable
    {
        private const int _sizeVersion = 8;
        private byte[] _version = new byte[_sizeVersion];
        private int _count;
        public Material[] _trainingMaterial = new Material[0];

        public Traninig(string description = null) : base(description)
        {
        }

        public byte[] GetVersion()
        {
            return _version;
        }

        public void SetVersion(byte[] bytes)
        {
            if (bytes.Length != _sizeVersion)
            {
                throw new ArgumentException($"The size of the array isn't {_sizeVersion} "); 
            }

            for (var i = 0; i < _sizeVersion; i++)
            {
                _version[i] = bytes[i];
            }
        }

        public void Add(Material obj)
        {
            Array.Resize(ref _trainingMaterial, _trainingMaterial.Length + 1);
            _trainingMaterial[_trainingMaterial.Length-1] = obj; 
        }

        public LessonType TypeLesson()
        {
            for (var i = 0; i < _trainingMaterial.Length; i++)
            {
                if (_trainingMaterial[i] is Video)
                {
                    return LessonType.VideoLesson;
                }
            }
            return LessonType.TextLesson;
        }


        public object Clone()
        {
            var newMaterials = new Material[_trainingMaterial.Length];
            for (var i = 0; i < _trainingMaterial.Length; i++)
            {
                newMaterials[i] = _trainingMaterial[i].Clone();
            }

            var copyVersion = new byte[_version.Length];
            for (var i = 0; i < _version.Length; i++)
            {
                copyVersion[i] = _version[i];
            }

            return new Traninig
            {
                _trainingMaterial = newMaterials,
                _version = copyVersion,
                _count = _count,
                Id = Id,
                Description = Description
            };
        }
    }
}