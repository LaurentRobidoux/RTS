using RTS.Actions.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RTS.Tech
{
    public abstract class Technology : ScriptableObject
    {
        public Texture2D _Thumbnail;
        public Texture2D Thumbnail
        {
            get
            {
                return _Thumbnail;
            }
        }

        /// <summary>
        /// Apply a technology to a player
        /// </summary>
        /// <param name="playerIndex">the index of the player who gets the tech</param>
        public abstract void ApplyTech(int playerIndex);

    }
}
