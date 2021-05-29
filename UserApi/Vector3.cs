using System;
using UserApi.WoWObjects;

namespace UserApi
{
    [Serializable]
    public class Vector3
    {
        #region Constructor

        public Vector3()
        {

        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        #region Props

        public float X
        {
            get;
            set;
        }

        public float Y
        {
            get;
            set;
        }

        public float Z
        {
            get;
            set;
        }

        public double Distance
        {
            get
            {
                return CalcDistanceToLocalPlayer();
            }
        }

        #endregion

        #region Public Methods

        public double CalcDistanceToObject(GameObject obj)
        {
            return CalcDistanceToVector3(obj.Location);
        }

        public double CalcDistanceToVector3(Vector3 loc)
        {
            float deltaX = (X - loc.X);
            float deltaY = (Y - loc.Y);
            float deltaZ = (Z - loc.Z);
            return (float)Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ));
        }

        #endregion

        #region Methods

        private double CalcDistanceToLocalPlayer()
        {
            return CalcDistanceToObject(WoW.LocalPlayer);
        }

        #endregion
    }
}
