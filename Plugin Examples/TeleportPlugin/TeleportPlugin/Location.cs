using System;
using UserApi;

namespace TeleportPlugin
{
    [Serializable]
    public class Location
    {
        public string Name
        {
            get; set;
        }

        public Vector3 Vector
        {
            get; set;
        }
    }
}
