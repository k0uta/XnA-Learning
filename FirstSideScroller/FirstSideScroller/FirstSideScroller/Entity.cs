using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstSideScroller
{
    class Entity
    {

        //The position Vector
        protected Vector2 position;

        //The entity texture
        protected Texture2D texture;

        //The source rectangle, pointing where (X and Y) and the size of the entity
        protected Rectangle source;


    }
}
