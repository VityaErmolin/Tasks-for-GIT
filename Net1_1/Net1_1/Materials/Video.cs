using System;
using Net1_1.Enums;
using Net1_1.Interface;

namespace Net1_1.Materials
{
    public class Video : Material, IVersionable
    {
        private string _urivideo;
        private const int _sizeVersion = 8;
        private byte[] _version = new byte[_sizeVersion];

        public string UriPicture { get; set; }
        public VideoType VideoTypeVideo { get; set; }
        public string UriVideo
        {
            get => _urivideo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Video link can't be empty"); 
                }
                _urivideo = value;
            }
        }
        
        public Video(string uriVideo, string uriPicture, VideoType ofVideoTypeVideo, string description=null) : base(description)
        {
            VideoTypeVideo = ofVideoTypeVideo;
            UriPicture = uriPicture;
            UriVideo = uriVideo;
            Description = description;
        }

        public byte[] GetVersion()
        {
            return _version;
        }

        public void SetVersion(byte[] bytes)
        {
            if (bytes.Length != _sizeVersion || bytes==null)
            {
                throw new ArgumentException($"The size of the array isn't {_sizeVersion} ");
            }

            for (var i = 0; i < _sizeVersion; i++)
            {
                _version[i] = bytes[i];
            }
        }

        public override Material Clone()
        {
            var copyVersion = new byte[_version.Length];
            for (var i = 0; i < _version.Length; i++)
            {
                copyVersion[i] = _version[i];
            }

            return new Video(UriVideo, UriPicture, VideoTypeVideo) {Id = Id, _version = copyVersion};
        }
    }
}