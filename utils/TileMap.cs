using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace HydroGene.utils
{
    class TileMap : IActor
    {
        private MainGame mainGame;


        // IActor :
        /// <summary>
        /// Represent the Hitbox of the current Sprite. By default it as bigger as the sprite Size multiply by his Scale.
        /// </summary>
        public Rectangle BoundingBox { get; protected set; }
        /// <summary>
        /// Position of the Sprite on the Screen. If you don't set anything, this value will be Vector2.Zero
        /// </summary>
        public Vector2 Position { get; set; } = Vector2.Zero;
        /// <summary>
        /// Pass this variable to true to remove it to the listActor of you scene, and remove it from the screen. Don't forget to call Clean() function in your Update() function of your Scene or it will do nothing.
        /// </summary>
        public bool ToRemove { get; set; }

        private TmxMap Map;

        private Texture2D Tileset;

        /// <summary>
        /// Get the number of lines of the map. Use MapWidth instead if you want the real length.
        /// </summary>
        public int MapWidthInLines { get; }

        /// <summary>
        /// Get the number of column of the map. Use MapHeight instead if you want the real length.
        /// </summary>
        public int MapHeightInColumn { get; }

        private bool HAS_SOLID_LAYER = false;
        private int SOLID_LAYER;

        /// <summary>
        /// Get the width of the map.
        /// </summary>
        public int MapWidth { get; }

        /// <summary>
        /// Get the height of the map.
        /// </summary>
        public int MapHeight { get; }

        /// <summary>
        /// Get the number of lines of the Tileset.
        /// </summary>
        public int TilesetLines { get; }

        /// <summary>
        /// Get the number of columns of the Tileset
        /// </summary>
        public int TilesetColumns { get; }


        /// <summary>
        /// Get the Width of one tile.
        /// </summary>
        public int TileWidth { get; }

        /// <summary>
        /// Get the Height of one tile.
        /// </summary>
        public int TileHeight { get; }

        /// <summary>
        /// Get the number of layers of this TileMap.
        /// </summary>
        public int NbLayer { get; }

        /// <summary>
        /// Indicate on which layer the entities is put.
        /// </summary>
        public int LayerEntity { get; set; } = 0;

        /// <summary>
        /// Indicate if the actor is visible. If this is false, it will not drawing it anymore.
        /// </summary>
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// Indicate if you want the actor to be Active. If this variable is put to false, it will stop Update and Drawing it.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Get the list of all the SolidTiles of this TileMap.
        /// </summary>
        public List<int> SolidTiles { get; }

        /// <summary>
        /// Indicate the Slopes oriented to the North East. [IS NOT WORKING YET]
        /// </summary>
        public List<int> SlopesTiles_NorthEast { get; set; }

        /// <summary>
        /// Indicate the Scale of the TileMap. By default it's Vector.One.
        /// </summary>
        public Vector2 Scale { get; set; } = Vector2.One;

        /// <summary>
        /// Indicate the Angle of the TileMap. By default it's 0. No need to convert it, it's already done.
        /// </summary>
        public float Angle { get; set; } = 0f;

        /// <summary>
        /// Indicate the Origin of the Tilemap. By default it's set to the upper left corner, so it's default value is Vector2.Zero.
        /// </summary>
        public Vector2 Origin { get; set; } = Vector2.Zero;

        /// <summary>
        /// Indicate the current flip effect of the Tilemap. By default, the TileMap is not flipped.
        /// </summary>
        public Flip Flip;

        private SpriteEffects flipEffect;

        /// <summary>
        /// Create a new Tilemap. Don't forget to Call the Draw() Method of this class on the Draw() of your Scene.
        /// </summary>
        /// <param name="mapPath"> The path to your .tmx file location. </param>
        /// <param name="pTileset"> The Tileset of your map. </param>
        public TileMap(string mapPath, Texture2D pTileset)
        {
            this.mainGame = MainGame.Instance;

            Flip = new Flip();
            flipEffect = SpriteEffects.None;

            // Load the Map : 
            Map = new TmxMap(mapPath); // Example : "Content/level/level1.tmx"
            Tileset = pTileset;

            TileWidth = Map.Tilesets[0].TileWidth;
            TileHeight = Map.Tilesets[0].TileHeight;

            MapWidthInLines = Map.Width;
            MapHeightInColumn = Map.Height;

            TilesetColumns = Tileset.Width / TileWidth;
            TilesetLines = Tileset.Height / TileHeight;

            MapWidth = MapWidthInLines * TileWidth;
            MapHeight = MapHeightInColumn * TileHeight;

            NbLayer = Map.Layers.Count;

            SolidTiles = new List<int>();
            SlopesTiles_NorthEast = new List<int>();
        }


        /// <summary>
        /// Check if the current sprite is visible on the screen.
        /// </summary>
        /// <returns></returns>
        public bool IsOnScreen()
        {
            if (Util.Overlaps(this, Camera.VisibleArea)) return true;
            return false;
        }

        /// <summary>
        ///  Function to write if you want to do something when this sprite collide with an other actor
        /// </summary>
        /// <param name="By"> Represent the IActor who touch this sprite </param>
        public virtual void TouchedBy(IActor By)
        {

        }


        // ============================ Tiles Information ============================ 

        /// <summary>
        /// Say if there is an entire layer you can collide with. So you don't need to apply SetSolidTiles()
        /// </summary>
        /// <param name="layer"> The layer on which all your collision tiles are.</param>
        public void SetSolidLayer(int layer)
        {
            HAS_SOLID_LAYER = true;
            SOLID_LAYER = layer;
        }

        /// <summary>
        /// You can give an array of all Solid tiles. So you don't need to apply SetSolidLayer()
        /// </summary>
        public void SetSolidTiles(int[] arraySolidTiles)
        {
            foreach (var i in arraySolidTiles)
            {
                SolidTiles.Add(i);
            }
        }


        private bool isSolid(int pID)
        {
            foreach (var tile in SolidTiles)
            {
                if (tile == pID) return true;
            }

            return false;
        }

        private bool isSolid(int pID, int layer)
        {
            int gid = pID;

            if (gid == 0 || gid == -1) return false;

            else return true;
        }


        /// <summary>
        ///  Identify if the current tile (pID) is a North East Slopes tile
        /// </summary>
        /// <param name="pID"> Represente the Tile ID </param>
        /// <param name="layer"> Represent the current Layer you want to find this ID </param>
        /// <returns></returns>
        private bool isSlopesNorthEast(int pID, int layer)
        {
            int gid = pID;

            foreach (int tile in SlopesTiles_NorthEast)
            {
                if (tile == gid) return true;
            }

            return false;
        }

        /// <summary>
        ///  Return the tile ID of a Position X and Y (both are float).
        /// </summary>
        /// <param name="pX"> The position X </param>
        /// <param name="pY"> The position Y</param>
        /// <param name="layer"> The layer you want to check. By default it is set to 0</param>
        /// <returns></returns>
        public int GetTileAt(float pX, float pY, int layer = 0)
        {

            int col = (int)pX / (TileWidth);
            int lig = (int)pY / (TileHeight);

            if (col >= 0 && lig >= 0 && col < MapWidthInLines && lig < MapHeightInColumn)
            {

                int index = col + (lig * MapWidthInLines);
                int id = Map.Layers[layer].Tiles[index].Gid - 1;

                if (id == -1 || id == 0) return 0;

                return id;
            }

            return 0;
        }

        /// <summary>
        ///  Return the tile ID of a Position X and Y (both are float).
        /// </summary>
        /// <param name="pos"> The Vector2 position. </param>
        /// <param name="layer"> The layer you want to check. By default it is set to 0</param>
        /// <returns></returns>
        public int GetTileAt(Vector2 pos, int layer = 0)
        {
            int col = (int)pos.X / (TileWidth);
            int lig = (int)pos.Y / (TileHeight);

            if (col >= 0 && lig >= 0 && col < MapWidth && lig < MapHeight)
            {

                int index = col + (lig * MapWidthInLines);
                int id = Map.Layers[layer].Tiles[index].Gid - 1;

                if (id == -1 || id == 0) return 0;

                return id;
            }

            return 0;
        }

        // ============================ Collisions ============================ 

        /// <summary>
        /// Check the collision to the Right of a given sprite.
        /// </summary>
        public bool CollideRight(Sprite pSprite, bool useBoundingBox = false, float offsetX = 0)
        {
            int id1, id2;

            if (HAS_SOLID_LAYER)
            {
                if (!useBoundingBox)
                {
                    id1 = GetTileAt(pSprite.Position.X - pSprite.Origin.X + pSprite.Width +2 +offsetX, pSprite.Position.Y - pSprite.Origin.Y + (pSprite.Height*0.5f), SOLID_LAYER);
                    id2 = GetTileAt(pSprite.Position.X - pSprite.Origin.X + pSprite.Width +2 +offsetX, pSprite.Position.Y - pSprite.Origin.Y + (pSprite.Height*0.5f) , SOLID_LAYER);

                    if (isSolid(id1, SOLID_LAYER) || isSolid(id2, SOLID_LAYER)) return true;
                }

                else
                {
                    id1 = GetTileAt(pSprite.BoundingBox.X + pSprite.BoundingBox.Width + 1 +offsetX, pSprite.BoundingBox.Y + 2, SOLID_LAYER);
                    id2 = GetTileAt(pSprite.BoundingBox.X + pSprite.BoundingBox.Width + 1 +offsetX, pSprite.BoundingBox.Y + pSprite.BoundingBox.Height - 2, SOLID_LAYER);

                    if (isSolid(id1, SOLID_LAYER) || isSolid(id2, SOLID_LAYER)) return true;
                }
            }

            else
            {
                id1 = GetTileAt(pSprite.Position.X + pSprite.Width + 2, pSprite.Position.Y + pSprite.Scale.Y);
                id2 = GetTileAt(pSprite.Position.X + pSprite.Width + 2, pSprite.Position.Y + pSprite.Height - pSprite.Scale.Y);

                if (isSolid(id1) || isSolid(id2)) return true;
            }

            return false;
        }

        /// <summary>
        /// Check the collision to the Left of a given sprite.
        /// </summary>
        public bool CollideLeft(Sprite pSprite, bool useBoundingBox = false, float offsetX = 0)
        {
            int id1, id2;

            if (HAS_SOLID_LAYER)
            {
                if (!useBoundingBox)
                {

                    id1 = GetTileAt(pSprite.Position.X - pSprite.Origin.X - 2 +offsetX, pSprite.Position.Y - pSprite.Origin.Y + (pSprite.Height *0.5f)-0, SOLID_LAYER);
                    id2 = GetTileAt(pSprite.Position.X - pSprite.Origin.X - 2 +offsetX, pSprite.Position.Y - pSprite.Origin.Y + (pSprite.Height * 0.5f)+0, SOLID_LAYER);

                    if (isSolid(id1, SOLID_LAYER) || isSolid(id2, SOLID_LAYER)) return true;
                }

                else
                {
                    id1 = GetTileAt(pSprite.BoundingBox.X - 1 +offsetX, pSprite.BoundingBox.Y + 2, SOLID_LAYER);
                    id2 = GetTileAt(pSprite.BoundingBox.X - 1 +offsetX, pSprite.BoundingBox.Y + pSprite.BoundingBox.Height - 2, SOLID_LAYER);

                    if (isSolid(id1, SOLID_LAYER) || isSolid(id2, SOLID_LAYER)) return true;
                }
            }

            else
            {
                id1 = GetTileAt(pSprite.Position.X - 1, pSprite.Position.Y + pSprite.Scale.Y);
                id2 = GetTileAt(pSprite.Position.X - 1, pSprite.Position.Y + pSprite.Height - pSprite.Scale.Y);

                if (isSolid(id1) || isSolid(id2)) return true;
            }

            return false;
        }

        /// <summary>
        /// Check the collision to the Bottom of a given sprite.
        /// </summary>
        public bool CollideBelow(Sprite pSprite, bool useBoundingBox = false)
        {
            int id1, id2;

            if (HAS_SOLID_LAYER)
            {
                if (useBoundingBox)
                {
                    id1 = GetTileAt(pSprite.BoundingBox.X + 4, pSprite.BoundingBox.Y + pSprite.BoundingBox.Height, SOLID_LAYER);
                    id2 = GetTileAt(pSprite.BoundingBox.X + pSprite.BoundingBox.Width - 4, pSprite.BoundingBox.Y + pSprite.BoundingBox.Height, SOLID_LAYER);

                    if (isSolid(id1, SOLID_LAYER) || isSolid(id2, SOLID_LAYER)) return true;
                }

                else
                {
                    id1 = GetTileAt(pSprite.Position.X - pSprite.Origin.X + 14, pSprite.Position.Y - pSprite.Origin.Y + (pSprite.Height * pSprite.Scale.Y), SOLID_LAYER);
                    id2 = GetTileAt(pSprite.Position.X - pSprite.Origin.X + pSprite.Width - 14, pSprite.Position.Y - pSprite.Origin.Y + (pSprite.Height * pSprite.Scale.Y), SOLID_LAYER);

                    if (isSolid(id1, SOLID_LAYER) || isSolid(id2, SOLID_LAYER))
                    {
                        return true;
                    }
                }
            }

            else
            {
                id1 = GetTileAt(pSprite.Position.X + 2, pSprite.Position.Y + pSprite.Height);
                id2 = GetTileAt(pSprite.Position.X + (pSprite.Width * pSprite.Scale.X) - 2, pSprite.Position.Y + (pSprite.Height * pSprite.Scale.Y));

                if (isSolid(id1) || isSolid(id2)) return true;
            }


            return false;
        }


        /// <summary>
        /// Check the collision to the Top of a given sprite.
        /// </summary>
        public bool CollideAbove(Sprite pSprite, bool useBoundingBox = false)
        {
            int id1, id2;

            if (HAS_SOLID_LAYER)
            {

                if (useBoundingBox)
                {
                    id1 = GetTileAt(pSprite.BoundingBox.X + 2, pSprite.BoundingBox.Y - 2, SOLID_LAYER);
                    id2 = GetTileAt(pSprite.BoundingBox.X + pSprite.BoundingBox.Width - 2, pSprite.BoundingBox.Y - 2, SOLID_LAYER);

                }

                else
                {
                    id1 = GetTileAt(pSprite.Position.X - pSprite.Origin.X + 2, pSprite.Position.Y - pSprite.Origin.Y - 2, SOLID_LAYER);
                    id2 = GetTileAt(pSprite.Position.X - pSprite.Origin.X + pSprite.Width - 2, pSprite.Position.Y - pSprite.Origin.Y - 2, SOLID_LAYER);
                }

                if (isSolid(id1, SOLID_LAYER) || isSolid(id2, SOLID_LAYER)) return true;
            }

            else
            {
                id1 = GetTileAt(pSprite.Position.X - pSprite.Origin.X - 2, pSprite.Position.Y - pSprite.Origin.Y + 2);
                id2 = GetTileAt(pSprite.Position.X - pSprite.Origin.X - 2, pSprite.Position.Y - pSprite.Origin.Y + pSprite.Height - 2);

                if (isSolid(id1) || isSolid(id2)) return true;
            }

            return false;
        }


        /// <summary>
        /// Align the Sprite (Position Y) to the tilemap.
        /// </summary>
        public void AlignOnLine(Sprite pSprite, float offsetY = 0)
        {
            int lig = (int)Math.Floor((pSprite.Position.Y + (TileHeight / 2)) / TileHeight) + 1;

            pSprite.Position = new Vector2(pSprite.Position.X, ((lig - 1) * TileHeight) + offsetY);

        }
        /// <summary>
        /// Align the Sprite (Position X) to the tilemap.
        /// </summary>
        public void AlignOnColumn(Sprite pSprite, float offsetX = 0)
        {

            int col = (int)Math.Floor((pSprite.Position.X -pSprite.Origin.X + TileHeight / 2) / TileHeight) + 1;
            pSprite.Position = new Vector2(((col - 1) * TileHeight) + offsetX, pSprite.Position.Y);
            pSprite.Velocity.X = 0;

        }


        /// <summary>
        /// Check if there are collision on a North East Slopes tile. [IS NOT WORKING YET]
        /// </summary>
        /// <param name="pSprite"> The sprite you want to check the collisions with.</param>
        /// <returns></returns>
        public bool CollideNorthEastSlopes(Sprite pSprite)
        {
            int id1, id2;

            if (HAS_SOLID_LAYER)
            {
                id1 = GetTileAt(pSprite.BoundingBox.X + 1, pSprite.Position.Y + pSprite.Height, SOLID_LAYER);
                id2 = GetTileAt(pSprite.BoundingBox.X + pSprite.BoundingBox.Width - 2, pSprite.Position.Y + pSprite.Height, SOLID_LAYER);

                if (isSlopesNorthEast(id1, SOLID_LAYER) || isSlopesNorthEast(id2, SOLID_LAYER))
                {
                    int col1 = (int)pSprite.BoundingBox.X + 1 / (TileWidth);
                    int lig1 = (int)pSprite.Position.Y + pSprite.Height / (TileHeight);

                    int col2 = (int)pSprite.BoundingBox.X + pSprite.BoundingBox.Width - 2 / (TileWidth);
                    int lig2 = (int)pSprite.Position.Y + pSprite.Height / (TileHeight);


                    int mod = col1 % 64;
                    Console.WriteLine("MODULO = " + mod);

                    //Console.Write("id1 Position = " + col1 + " | " + lig1 + " <===> ");
                    //Console.WriteLine("id2 Position = " + col2 + " | " + lig2 + " DELTA = " + deltaY);

                    //AlignOnLine(pSprite, mod);

                    return true;
                }
            }

            else
            {
                id1 = GetTileAt(pSprite.Position.X + 1, pSprite.Position.Y + pSprite.Height);
                id2 = GetTileAt(pSprite.Position.X + pSprite.Width - 2, pSprite.Position.Y + pSprite.Height);

                if (isSolid(id1) || isSolid(id2)) return true;
            }

            return false;
        }


        public virtual void Update(GameTime gameTime)
        {

        }

        // ============================ Drawing stuffs and Checking Entity ============================ 

        /// <summary>
        /// Check if there is an entity and return his Vector2 position.
        /// </summary>
        /// <param name="pID"> The ID the entity you want to check. </param>
        /// <param name="pLayer"> The layer the entity is on. </param>
        /// <returns></returns>
        public List<Vector2> CheckEntity(int pID, int pLayer = 0)
        {
            List<Vector2> list_positions = new List<Vector2>();

            if (pLayer >= Map.Layers.Count) Console.WriteLine("ERROR!! because : " + pLayer + " does not exist on the " + (Map.Layers.Count - 1) + " nb of Layers of this Tilemap!");

            else
            {
                int line = 0, column = 0;

                for (int i = 0; i < Map.Layers[pLayer].Tiles.Count; i++)
                {
                    int gid = Map.Layers[pLayer].Tiles[i].Gid;

                    if (gid != 0)
                    {
                        int tileFrame = gid - 1;

                        if (tileFrame == pID)
                        {
                            // Console.WriteLine("ID = " + tileFrame);
                            int tilesetColumn = tileFrame % TilesetColumns;
                            int tilesetLine = (int)Math.Floor((double)tileFrame / (double)TilesetColumns);

                            float x = column * TileWidth;
                            float y = line * TileHeight;

                            // Console.WriteLine("Column = " + column + " | Line = "+line);
                            // Console.WriteLine("X = " + x + " | Y = " + y);

                            list_positions.Add(new Vector2(x, y));
                        }
                    }

                    column++;

                    if (column == MapWidthInLines)
                    {
                        column = 0;
                        line++;
                    }
                }
            }

            return list_positions;
        }

        /// <summary>
        /// Put this on your Draw function to print the tilemap on the screen.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {

                // Traitement du flip
                flipEffect = SpriteEffects.None;
                if (Flip.X) flipEffect = SpriteEffects.FlipHorizontally;
                if (Flip.Y) flipEffect = SpriteEffects.FlipVertically;
                if (Flip.X && Flip.Y) flipEffect = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

                int line;
                int column;


                for (int nLayer = 0; nLayer < NbLayer - 1; nLayer++)
                {
                    line = 0;
                    column = 0;

                    for (int i = 0; i < Map.Layers[nLayer].Tiles.Count; i++)
                    {
                        int gid = Map.Layers[nLayer].Tiles[i].Gid;

                        if (gid != 0 && !Map.Layers[nLayer].Name.Contains("Entities"))
                        {
                            float x = column * (TileWidth * Scale.X);
                            float y = line * (TileHeight * Scale.Y);


                            if (Util.DistanceBetween(new Vector2(x, y), new Vector2(Camera.Position.X, Camera.Position.Y)) <= Camera.VisibleArea.Width * 1.5f)
                            {

                                int tileFrame = gid - 1;

                                int tilesetColumn = tileFrame % TilesetColumns;
                                int tilesetLine = (int)Math.Floor((double)tileFrame / (double)TilesetColumns);

                                Rectangle tilesetRec = new Rectangle(TileWidth * tilesetColumn, TileHeight * tilesetLine, TileWidth, TileHeight);

                                mainGame.spriteBatch.Draw(Tileset,
                                                          new Vector2(x, y),
                                                          tilesetRec,
                                                          Color.White,
                                                          MathHelper.ToRadians((float)Angle),
                                                          Origin, Scale, flipEffect, 0f
                                                         );
                            }
                        }

                        column++;

                        if (column == MapWidthInLines)
                        {
                            column = 0;
                            line++;
                        }
                    }
                }

            }
        }

    }
}
