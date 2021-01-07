using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{
    class AssetManager
    {

		#region Textures
		public static Texture2D Atsm_logo { get; private set; }
		public static Texture2D Backgroundwall0 { get; private set; }
		public static Texture2D Backgroundwall1 { get; private set; }
		public static Texture2D Basic_gun { get; private set; }
		public static Texture2D Bgmonster { get; private set; }
		public static Texture2D Bgpart1 { get; private set; }
		public static Texture2D Bgpart2 { get; private set; }
		public static Texture2D Bgpart3 { get; private set; }
		public static Texture2D Bloodwaterdeep { get; private set; }
		public static Texture2D Bloodwatertop { get; private set; }
		public static Texture2D Blueglow { get; private set; }
		public static Texture2D Bossdieparticles { get; private set; }
		public static Texture2D Bush_small { get; private set; }
		public static Texture2D Cimeterybackground0 { get; private set; }
		public static Texture2D Cimeterytileset { get; private set; }
		public static Texture2D Console { get; private set; }
		public static Texture2D Cursor { get; private set; }
		public static Texture2D Deadcircle { get; private set; }
		public static Texture2D Dialoguepannel { get; private set; }
		public static Texture2D Douille { get; private set; }
		public static Texture2D Dreamveloper { get; private set; }
		public static Texture2D Dungeon2tileset { get; private set; }
		public static Texture2D Dungeonlavatileset { get; private set; }
		public static Texture2D Dungeontilesetfull { get; private set; }
		public static Texture2D Dungeon_final1 { get; private set; }
		public static Texture2D Dungeon_final2 { get; private set; }
		public static Texture2D Enemyship { get; private set; }
		public static Texture2D Fireballmeteor { get; private set; }
		public static Texture2D Fleche { get; private set; }
		public static Texture2D Flocon { get; private set; }
		public static Texture2D Gamepad { get; private set; }
		public static Texture2D Gold { get; private set; }
		public static Texture2D Graveyard { get; private set; }
		public static Texture2D Gunimpactparticle { get; private set; }
		public static Texture2D Hammer { get; private set; }
		public static Texture2D Hero { get; private set; }
		public static Texture2D Jetpack { get; private set; }
		public static Texture2D Jetpackrelic { get; private set; }
		public static Texture2D Lavaship { get; private set; }
		public static Texture2D Levelupparticle { get; private set; }
		public static Texture2D Movingplatform1 { get; private set; }
		public static Texture2D Movingplatform2 { get; private set; }
		public static Texture2D Movingplatform3 { get; private set; }
		public static Texture2D Multisparklepuff { get; private set; }
		public static Texture2D Pillier { get; private set; }
		public static Texture2D Poony { get; private set; }
		public static Texture2D Portrait1 { get; private set; }
		public static Texture2D Portrait2 { get; private set; }
		public static Texture2D Projectile { get; private set; }
		public static Texture2D Purpleglow { get; private set; }
		public static Texture2D Relic_dash { get; private set; }
		public static Texture2D Relic_doublejump { get; private set; }
		public static Texture2D Relic_sprint { get; private set; }
		public static Texture2D Sablier { get; private set; }
		public static Texture2D Shoot1 { get; private set; }
		public static Texture2D Shoot2 { get; private set; }
		public static Texture2D Shoot3 { get; private set; }
		public static Texture2D Shoptileset { get; private set; }
		public static Texture2D Silver { get; private set; }
		public static Texture2D Spotlight { get; private set; }
		public static Texture2D Sprintdust { get; private set; }
		public static Texture2D Tilesetlaserzone { get; private set; }
		public static Texture2D Title2 { get; private set; }
		public static Texture2D Tonneau { get; private set; }
		public static Texture2D Traila { get; private set; }
		public static Texture2D Trailb { get; private set; }
		public static Texture2D Tutotileset { get; private set; }
		public static Texture2D Upkeyicon { get; private set; }
		public static Texture2D Van_tux_autoportrait { get; private set; }
		public static Texture2D Violentflame { get; private set; }
		public static Texture2D Vortexmenu { get; private set; }
		public static Texture2D Wallblock { get; private set; }
		public static Texture2D Waterdeep { get; private set; }
		public static Texture2D Watertop { get; private set; }
		public static Texture2D Xbox_b { get; private set; }
		public static Texture2D Xbox_y { get; private set; }
		public static Texture2D Lastzonebg { get; private set; }
		public static Texture2D Alternativebgfar { get; private set; }
		public static Texture2D Alternativebgmid { get; private set; }
		public static Texture2D Alternativebgnear { get; private set; }
		public static Texture2D Laserbackgroundfar { get; private set; }
		public static Texture2D Laserbackgroundmiddle { get; private set; }
		public static Texture2D Backgroundlava { get; private set; }
		public static Texture2D Church1 { get; private set; }
		public static Texture2D Church2 { get; private set; }
		public static Texture2D Church4 { get; private set; }
		public static Texture2D Church5 { get; private set; }
		public static Texture2D Column { get; private set; }
		public static Texture2D Bigchest { get; private set; }
		public static Texture2D Bubble { get; private set; }
		public static Texture2D Chest { get; private set; }
		public static Texture2D Flag { get; private set; }
		public static Texture2D Flagdark { get; private set; }
		public static Texture2D Powerboostatk { get; private set; }
		public static Texture2D Powerboostatkspeed { get; private set; }
		public static Texture2D Powerboostbulletspeed { get; private set; }
		public static Texture2D Powerboostrange { get; private set; }
		public static Texture2D Powerboostreloadspeed { get; private set; }
		public static Texture2D Beastexplode { get; private set; }
		public static Texture2D Beasticon { get; private set; }
		public static Texture2D Darkskull { get; private set; }
		public static Texture2D Dark_spear { get; private set; }
		public static Texture2D Demon { get; private set; }
		public static Texture2D Demonattack { get; private set; }
		public static Texture2D Demonattack2 { get; private set; }
		public static Texture2D Demonicon { get; private set; }
		public static Texture2D Fireskull { get; private set; }
		public static Texture2D Ghost { get; private set; }
		public static Texture2D Ghosticon { get; private set; }
		public static Texture2D Hellbeast { get; private set; }
		public static Texture2D Observer { get; private set; }
		public static Texture2D Observericon { get; private set; }
		public static Texture2D Robot { get; private set; }
		public static Texture2D Robotdestroyed { get; private set; }
		public static Texture2D Roboticon { get; private set; }
		public static Texture2D Skullicon { get; private set; }
		public static Texture2D Barrel { get; private set; }
		public static Texture2D Bigcrate { get; private set; }
		public static Texture2D Blob { get; private set; }
		public static Texture2D Bush1 { get; private set; }
		public static Texture2D Cage { get; private set; }
		public static Texture2D Chainea { get; private set; }
		public static Texture2D Chandellier { get; private set; }
		public static Texture2D Fountain { get; private set; }
		public static Texture2D Halolight { get; private set; }
		public static Texture2D Lantern { get; private set; }
		public static Texture2D Laserhalo { get; private set; }
		public static Texture2D Littletorch { get; private set; }
		public static Texture2D Redflag { get; private set; }
		public static Texture2D Smalllight { get; private set; }
		public static Texture2D Smalllight2 { get; private set; }
		public static Texture2D Smalltorch { get; private set; }
		public static Texture2D Balle { get; private set; }
		public static Texture2D Bat { get; private set; }
		public static Texture2D Bat2 { get; private set; }
		public static Texture2D Bouncehead { get; private set; }
		public static Texture2D Canon { get; private set; }
		public static Texture2D Crusher_a { get; private set; }
		public static Texture2D Crusher_b { get; private set; }
		public static Texture2D Crusher_c { get; private set; }
		public static Texture2D Crusher_d { get; private set; }
		public static Texture2D Crusher_e { get; private set; }
		public static Texture2D Earth_projectilesheet { get; private set; }
		public static Texture2D Earthwisp { get; private set; }
		public static Texture2D Executionersword { get; private set; }
		public static Texture2D Executionner { get; private set; }
		public static Texture2D Expparticle { get; private set; }
		public static Texture2D Expparticle2 { get; private set; }
		public static Texture2D Expparticle3 { get; private set; }
		public static Texture2D Fallingplatform { get; private set; }
		public static Texture2D Fire_ball { get; private set; }
		public static Texture2D Firewisp { get; private set; }
		public static Texture2D Firewispprojectile { get; private set; }
		public static Texture2D Fly { get; private set; }
		public static Texture2D Fly2 { get; private set; }
		public static Texture2D Fly3 { get; private set; }
		public static Texture2D Fly4 { get; private set; }
		public static Texture2D Kobold { get; private set; }
		public static Texture2D Laser { get; private set; }
		public static Texture2D Laser2 { get; private set; }
		public static Texture2D Laser3 { get; private set; }
		public static Texture2D Laser4 { get; private set; }
		public static Texture2D Laser5 { get; private set; }
		public static Texture2D Lava_fall { get; private set; }
		public static Texture2D Lava { get; private set; }
		public static Texture2D Lavafish { get; private set; }
		public static Texture2D Lavaman { get; private set; }
		public static Texture2D Minebig { get; private set; }
		public static Texture2D Ogre { get; private set; }
		public static Texture2D Pad { get; private set; }
		public static Texture2D Rocketsquare { get; private set; }
		public static Texture2D Saw { get; private set; }
		public static Texture2D Shieldman { get; private set; }
		public static Texture2D Shieldofshieldman { get; private set; }
		public static Texture2D Shootplant { get; private set; }
		public static Texture2D Slug { get; private set; }
		public static Texture2D Spider { get; private set; }
		public static Texture2D Spideregg { get; private set; }
		public static Texture2D Spiderweb { get; private set; }
		public static Texture2D Spike { get; private set; }
		public static Texture2D Stickyslime { get; private set; }
		public static Texture2D Stoneman { get; private set; }
		public static Texture2D Superstickyslime { get; private set; }
		public static Texture2D Toxic { get; private set; }
		public static Texture2D Toxicfall { get; private set; }
		public static Texture2D Water { get; private set; }
		public static Texture2D Waterfall { get; private set; }
		public static Texture2D Abutton { get; private set; }
		public static Texture2D Boxbubble { get; private set; }
		public static Texture2D Boxtriplejump { get; private set; }
		public static Texture2D Boxtripleshot { get; private set; }
		public static Texture2D Buttontype1_off { get; private set; }
		public static Texture2D Buttontype1_on { get; private set; }
		public static Texture2D Buttontype2_off { get; private set; }
		public static Texture2D Buttontype2_on { get; private set; }
		public static Texture2D Consoleview { get; private set; }
		public static Texture2D Dialoguebox { get; private set; }
		public static Texture2D Dialogueboxsouspart { get; private set; }
		public static Texture2D Ebutton { get; private set; }
		public static Texture2D Lbbutton { get; private set; }
		public static Texture2D Moins { get; private set; }
		public static Texture2D Plus { get; private set; }
		public static Texture2D Rbbutton { get; private set; }
		public static Texture2D Redcross { get; private set; }
		public static Texture2D Squareitem { get; private set; }
		public static Texture2D Staminabar { get; private set; }
		public static Texture2D Staminapannel { get; private set; }
		public static Texture2D Timersoul { get; private set; }
		public static Texture2D Timersoulsspritesheet { get; private set; }
		public static Texture2D Boomerang { get; private set; }
		public static Texture2D Boomerangicon { get; private set; }
		public static Texture2D Gun { get; private set; }
		public static Texture2D Gunicon { get; private set; }
		public static Texture2D Jetpackicon { get; private set; }
		public static Texture2D Shotgun { get; private set; }
		public static Texture2D Shotgunicon { get; private set; }
		public static Texture2D Shotgunprojectilemax { get; private set; }
		public static Texture2D Skulldeathgun { get; private set; }
		public static Texture2D Skulldeathgunicon { get; private set; }
		public static Texture2D Tornado { get; private set; }
		#endregion

		#region Songs
		public static Song Song_0_to_9 { get; private set; }
		public static Song Song_10_to_19 { get; private set; }
		public static Song Song_20_to_29 { get; private set; }
		public static Song Song_30_to_35 { get; private set; }
		public static Song Song_35_to_39 { get; private set; }
		public static Song Song_Blaze_of_destruction { get; private set; }
		public static Song Song_Boss1 { get; private set; }
		public static Song Song_Boss2 { get; private set; }
		public static Song Song_Boss4 { get; private set; }
		public static Song Song_Dark_presage { get; private set; }
		public static Song Song_Ending { get; private set; }
		public static Song Song_Finalboss1 { get; private set; }
		public static Song Song_Finalboss2 { get; private set; }
		public static Song Song_Gigantic_nebula { get; private set; }
		public static Song Song_Level_select_2 { get; private set; }
		public static Song Song_Level_select { get; private set; }
		public static Song Song_Mini_games { get; private set; }
		public static Song Song_Pervasive_pain { get; private set; }
		public static Song Song_Timeless_room { get; private set; }
		public static Song Song_Title_screen { get; private set; }
		public static Song Song_Training_room { get; private set; }
		public static Song Song_Wind_ambiance { get; private set; }
		public static Song Song_Worst_situation { get; private set; }
		#endregion

		#region Textures
		public static Texture2D Bg_wall { get; private set; }
		public static Texture2D Bookshelf_a { get; private set; }
		public static Texture2D Bookshelf_b { get; private set; }
		public static Texture2D Bookshelf_c { get; private set; }
		public static Texture2D Bookshelf_d { get; private set; }
		public static Texture2D Bookshelf_e { get; private set; }
		public static Texture2D Bookshelf_f { get; private set; }
		public static Texture2D Bookshelf_g { get; private set; }
		public static Texture2D Bookshelf_h { get; private set; }
		public static Texture2D Candle { get; private set; }
		public static Texture2D Cloud2 { get; private set; }
		public static Texture2D Cloudfog { get; private set; }
		public static Texture2D Oldman { get; private set; }
		public static Texture2D Triplejump { get; private set; }
		#endregion

		#region Sounds
		public static Sound Sound_Balltap { get; private set; }
		public static Sound Sound_Bigdeath { get; private set; }
		public static Sound Sound_Bigexplosion { get; private set; }
		public static Sound Sound_Bigwalk { get; private set; }
		public static Sound Sound_Boomerang { get; private set; }
		public static Sound Sound_Bossgethit { get; private set; }
		public static Sound Sound_Buy { get; private set; }
		public static Sound Sound_Cheatenabled { get; private set; }
		public static Sound Sound_Clock { get; private set; }
		public static Sound Sound_Crusherfall { get; private set; }
		public static Sound Sound_Crushertouchground { get; private set; }
		public static Sound Sound_Dash { get; private set; }
		public static Sound Sound_Die { get; private set; }
		public static Sound Sound_Dreamveloper { get; private set; }
		public static Sound Sound_Engine { get; private set; }
		public static Sound Sound_Exp { get; private set; }
		public static Sound Sound_Explosionparticle { get; private set; }
		public static Sound Sound_Fireballmeteorfalling { get; private set; }
		public static Sound Sound_Firewispprojectile { get; private set; }
		public static Sound Sound_Flydamage { get; private set; }
		public static Sound Sound_Flydeath { get; private set; }
		public static Sound Sound_Grasswalk1 { get; private set; }
		public static Sound Sound_Grasswalk2 { get; private set; }
		public static Sound Sound_Grasswalk3 { get; private set; }
		public static Sound Sound_Gunincrease { get; private set; }
		public static Sound Sound_Jump0 { get; private set; }
		public static Sound Sound_Justtouchedground { get; private set; }
		public static Sound Sound_Levelup { get; private set; }
		public static Sound Sound_Loadlaser { get; private set; }
		public static Sound Sound_Observerbeginlaser { get; private set; }
		public static Sound Sound_Observerchangedirection { get; private set; }
		public static Sound Sound_Observercrock { get; private set; }
		public static Sound Sound_Observerredlaser { get; private set; }
		public static Sound Sound_Observersneak { get; private set; }
		public static Sound Sound_Pold { get; private set; }
		public static Sound Sound_Powerup { get; private set; }
		public static Sound Sound_Relicdrawline { get; private set; }
		public static Sound Sound_Relicflash { get; private set; }
		public static Sound Sound_Relicobtained { get; private set; }
		public static Sound Sound_Reload { get; private set; }
		public static Sound Sound_Reversecamera { get; private set; }
		public static Sound Sound_Rewind { get; private set; }
		public static Sound Sound_Robotjump { get; private set; }
		public static Sound Sound_Select { get; private set; }
		public static Sound Sound_Shoot { get; private set; }
		public static Sound Sound_Shotgunshoot { get; private set; }
		public static Sound Sound_Spikefall { get; private set; }
		public static Sound Sound_Sprint { get; private set; }
		public static Sound Sound_Switchgun { get; private set; }
		public static Sound Sound_Switchmode { get; private set; }
		public static Sound Sound_Talk1 { get; private set; }
		public static Sound Sound_Talk2 { get; private set; }
		public static Sound Sound_Teleportend { get; private set; }
		public static Sound Sound_Teleportstart { get; private set; }
		public static Sound Sound_Thunder { get; private set; }
		public static Sound Sound_Timersoul { get; private set; }
		public static Sound Sound_Triplejump { get; private set; }
		public static Sound Sound_Uneffectivedamage { get; private set; }
		public static Sound Sound_Validate { get; private set; }
		public static Sound Sound_Vortex { get; private set; }
		public static Sound Sound_Walk0 { get; private set; }
		public static Sound Sound_Walk1 { get; private set; }
		public static Sound Sound_Walkwater1 { get; private set; }
		public static Sound Sound_Walkwater2 { get; private set; }
		public static Sound Sound_Walkwater3 { get; private set; }
		public static Sound Sound_Walkwater4 { get; private set; }
		public static Sound Sound_Watercrash { get; private set; }
		public static Sound Sound_Waterdrop { get; private set; }
		#endregion

		#region Textures
		public static Texture2D Streamer1 { get; private set; }
		public static Texture2D Streamer2 { get; private set; }
		public static Texture2D Streamer3 { get; private set; }
		public static Texture2D Streamer4 { get; private set; }
		public static Texture2D Streamer5 { get; private set; }
		public static Texture2D Winnerconcours { get; private set; }
		public static Texture2D Trainingroom_bg1 { get; private set; }
		public static Texture2D Trainingroom_bg2 { get; private set; }
		public static Texture2D Trainingroom_bg3 { get; private set; }
		public static Texture2D Dashtuto { get; private set; }
		public static Texture2D Doublejumptuto { get; private set; }
		public static Texture2D Explaindash { get; private set; }
		public static Texture2D Explainjump { get; private set; }
		public static Texture2D Explainplus { get; private set; }
		public static Texture2D Explainsprint { get; private set; }
		public static Texture2D Shoottuto { get; private set; }
		public static Texture2D Sprinttuto { get; private set; }
        #endregion

        public static SpriteFont FontPixelMaster28 { get; private set; }
        public static SpriteFont FontPixelMaster8 { get; private set; }

        public static Effect EffectCRT { get; private set; }
        public static Effect EffectChromatic { get; private set; }
        public static Effect EffectNegative { get; private set; }
        public static Effect EffectBlackAndWhite { get; private set; }
        public static Effect EffectGray { get; private set; }
        public static Effect EffectGameboy { get; private set; }

        private static T Load<T>(String contentName)
        {
            return MainGame.Instance.Content.Load<T>(contentName);
        }

        public static void Load()
        {
            // Effect 
            EffectCRT = Load<Effect>("Effects/OldTV");
            EffectChromatic = Load<Effect>("Effects/Chromatic");
            EffectNegative = Load<Effect>("Effects/Negative");
            EffectBlackAndWhite = Load<Effect>("Effects/BlackAndWhite");
            EffectGray = Load<Effect>("Effects/Gray");
            EffectGameboy = Load<Effect>("Effects/Gameboy");

            FontPixelMaster28 = Load<SpriteFont>("Fonts/Font28");
            FontPixelMaster8 = Load<SpriteFont>("Fonts/Font8");

            // Textures

            Atsm_logo = Load<Texture2D>("ATSM Logo");
			Backgroundwall0 = Load<Texture2D>("backgroundwall0");
			Backgroundwall1 = Load<Texture2D>("backgroundwall1");
			Basic_gun = Load<Texture2D>("Basic_Gun");
			Bgmonster = Load<Texture2D>("bgMonster");
			Bgpart1 = Load<Texture2D>("bgPart1");
			Bgpart2 = Load<Texture2D>("bgPart2");
			Bgpart3 = Load<Texture2D>("bgPart3");
			Bloodwaterdeep = Load<Texture2D>("bloodWaterDeep");
			Bloodwatertop = Load<Texture2D>("bloodWaterTop");
			Blueglow = Load<Texture2D>("blueGlow");
			Bossdieparticles = Load<Texture2D>("bossDieParticles");
			Bush_small = Load<Texture2D>("bush-small");
			Cimeterybackground0 = Load<Texture2D>("CimeteryBackground0");
			Cimeterytileset = Load<Texture2D>("CimeteryTileset");
			Console = Load<Texture2D>("Console");
			Cursor = Load<Texture2D>("cursor");
			Deadcircle = Load<Texture2D>("DeadCircle");
			Dialoguepannel = Load<Texture2D>("DialoguePannel");
			Douille = Load<Texture2D>("Douille");
			Dreamveloper = Load<Texture2D>("dreamveloper");
			Dungeon2tileset = Load<Texture2D>("Dungeon2Tileset");
			Dungeonlavatileset = Load<Texture2D>("DungeonLavaTileset");
			Dungeontilesetfull = Load<Texture2D>("DungeonTilesetFull");
			Dungeon_final1 = Load<Texture2D>("Dungeon_Final1");
			Dungeon_final2 = Load<Texture2D>("Dungeon_Final2");
			Enemyship = Load<Texture2D>("EnemyShip");
			Fireballmeteor = Load<Texture2D>("FireballMeteor");
			Fleche = Load<Texture2D>("fleche");
			Flocon = Load<Texture2D>("Flocon");
			Gamepad = Load<Texture2D>("gamepad");
			Gold = Load<Texture2D>("gold");
			Graveyard = Load<Texture2D>("graveyard");
			Gunimpactparticle = Load<Texture2D>("GunImpactParticle");
			Hammer = Load<Texture2D>("Hammer");
			Hero = Load<Texture2D>("hero");
			Jetpack = Load<Texture2D>("Jetpack");
			Jetpackrelic = Load<Texture2D>("JetpackRelic");
			Lavaship = Load<Texture2D>("LavaShip");
			Levelupparticle = Load<Texture2D>("LevelUpParticle");
			Movingplatform1 = Load<Texture2D>("MovingPlatform1");
			Movingplatform2 = Load<Texture2D>("MovingPlatform2");
			Movingplatform3 = Load<Texture2D>("MovingPlatform3");
			Multisparklepuff = Load<Texture2D>("MultiSparklePuff");
			Pillier = Load<Texture2D>("Pillier");
			Poony = Load<Texture2D>("Poony");
			Portrait1 = Load<Texture2D>("Portrait1");
			Portrait2 = Load<Texture2D>("Portrait2");
			Projectile = Load<Texture2D>("projectile");
			Purpleglow = Load<Texture2D>("purpleGlow");
			Relic_dash = Load<Texture2D>("relic_dash");
			Relic_doublejump = Load<Texture2D>("relic_doublejump");
			Relic_sprint = Load<Texture2D>("relic_sprint");
			Sablier = Load<Texture2D>("Sablier");
			Shoot1 = Load<Texture2D>("Shoot1");
			Shoot2 = Load<Texture2D>("Shoot2");
			Shoot3 = Load<Texture2D>("Shoot3");
			Shoptileset = Load<Texture2D>("ShopTileset");
			Silver = Load<Texture2D>("silver");
			Spotlight = Load<Texture2D>("spotLight");
			Sprintdust = Load<Texture2D>("SprintDust");
			Tilesetlaserzone = Load<Texture2D>("TilesetLaserZone");
			Title2 = Load<Texture2D>("Title2");
			Tonneau = Load<Texture2D>("Tonneau");
			Traila = Load<Texture2D>("TrailA");
			Trailb = Load<Texture2D>("TrailB");
			Tutotileset = Load<Texture2D>("TutoTileset");
			Upkeyicon = Load<Texture2D>("upKeyIcon");
			Van_tux_autoportrait = Load<Texture2D>("Van-Tux-Autoportrait");
			Violentflame = Load<Texture2D>("violentflame");
			Vortexmenu = Load<Texture2D>("VortexMenu");
			Wallblock = Load<Texture2D>("wallblock");
			Waterdeep = Load<Texture2D>("waterDeep");
			Watertop = Load<Texture2D>("waterTop");
			Xbox_b = Load<Texture2D>("xbox-b");
			Xbox_y = Load<Texture2D>("xbox-y");
			Lastzonebg = Load<Texture2D>("Background/FinalZone/lastZoneBG");
			Alternativebgfar = Load<Texture2D>("Background/LaserZone/AlternativeBgFar");
			Alternativebgmid = Load<Texture2D>("Background/LaserZone/AlternativeBgMid");
			Alternativebgnear = Load<Texture2D>("Background/LaserZone/AlternativeBgNear");
			Laserbackgroundfar = Load<Texture2D>("Background/LaserZone/LaserBackgroundFar");
			Laserbackgroundmiddle = Load<Texture2D>("Background/LaserZone/LaserBackgroundMiddle");
			Backgroundlava = Load<Texture2D>("Background/Lava Zone/BackgroundLava");
			Church1 = Load<Texture2D>("Background/SpikeZone/Church1");
			Church2 = Load<Texture2D>("Background/SpikeZone/Church2");
			Church4 = Load<Texture2D>("Background/SpikeZone/Church4");
			Church5 = Load<Texture2D>("Background/SpikeZone/Church5");
			Column = Load<Texture2D>("Background/SpikeZone/column");
			Bigchest = Load<Texture2D>("Bonus/bigChest");
			Bubble = Load<Texture2D>("Bonus/Bubble");
			Chest = Load<Texture2D>("Bonus/Chest");
			Flag = Load<Texture2D>("Bonus/Flag");
			Flagdark = Load<Texture2D>("Bonus/FlagDark");
			Powerboostatk = Load<Texture2D>("Bonus/PowerBoostAtk");
			Powerboostatkspeed = Load<Texture2D>("Bonus/PowerBoostAtkSpeed");
			Powerboostbulletspeed = Load<Texture2D>("Bonus/PowerBoostBulletSpeed");
			Powerboostrange = Load<Texture2D>("Bonus/PowerBoostRange");
			Powerboostreloadspeed = Load<Texture2D>("Bonus/PowerBoostReloadSpeed");
			Beastexplode = Load<Texture2D>("boss/BeastExplode");
			Beasticon = Load<Texture2D>("boss/BeastIcon");
			Darkskull = Load<Texture2D>("boss/DarkSkull");
			Dark_spear = Load<Texture2D>("boss/dark_spear");
			Demon = Load<Texture2D>("boss/Demon");
			Demonattack = Load<Texture2D>("boss/DemonAttack");
			Demonattack2 = Load<Texture2D>("boss/DemonAttack2");
			Demonicon = Load<Texture2D>("boss/DemonIcon");
			Fireskull = Load<Texture2D>("boss/FireSkull");
			Ghost = Load<Texture2D>("boss/Ghost");
			Ghosticon = Load<Texture2D>("boss/GhostIcon");
			Hellbeast = Load<Texture2D>("boss/HellBeast");
			Observer = Load<Texture2D>("boss/Observer");
			Observericon = Load<Texture2D>("boss/ObserverIcon");
			Robot = Load<Texture2D>("boss/Robot");
			Robotdestroyed = Load<Texture2D>("boss/RobotDestroyed");
			Roboticon = Load<Texture2D>("boss/RobotIcon");
			Skullicon = Load<Texture2D>("boss/SkullIcon");
			Barrel = Load<Texture2D>("Decor/Barrel");
			Bigcrate = Load<Texture2D>("Decor/BigCrate");
			Blob = Load<Texture2D>("Decor/Blob");
			Bush1 = Load<Texture2D>("Decor/Bush1");
			Cage = Load<Texture2D>("Decor/Cage");
			Chainea = Load<Texture2D>("Decor/ChaineA");
			Chandellier = Load<Texture2D>("Decor/Chandellier");
			Fountain = Load<Texture2D>("Decor/Fountain");
			Halolight = Load<Texture2D>("Decor/HaloLight");
			Lantern = Load<Texture2D>("Decor/Lantern");
			Laserhalo = Load<Texture2D>("Decor/LaserHalo");
			Littletorch = Load<Texture2D>("Decor/LittleTorch");
			Redflag = Load<Texture2D>("Decor/RedFlag");
			Smalllight = Load<Texture2D>("Decor/SmallLight");
			Smalllight2 = Load<Texture2D>("Decor/SmallLight2");
			Smalltorch = Load<Texture2D>("Decor/SmallTorch");
			Balle = Load<Texture2D>("Enemies/Balle");
			Bat = Load<Texture2D>("Enemies/Bat");
			Bat2 = Load<Texture2D>("Enemies/Bat2");
			Bouncehead = Load<Texture2D>("Enemies/bounceHead");
			Canon = Load<Texture2D>("Enemies/Canon");
			Crusher_a = Load<Texture2D>("Enemies/Crusher_A");
			Crusher_b = Load<Texture2D>("Enemies/Crusher_B");
			Crusher_c = Load<Texture2D>("Enemies/Crusher_C");
			Crusher_d = Load<Texture2D>("Enemies/Crusher_D");
			Crusher_e = Load<Texture2D>("Enemies/Crusher_E");
			Earth_projectilesheet = Load<Texture2D>("Enemies/earth-projectileSheet");
			Earthwisp = Load<Texture2D>("Enemies/earthWisp");
			Executionersword = Load<Texture2D>("Enemies/ExecutionerSword");
			Executionner = Load<Texture2D>("Enemies/Executionner");
			Expparticle = Load<Texture2D>("Enemies/ExpParticle");
			Expparticle2 = Load<Texture2D>("Enemies/ExpParticle2");
			Expparticle3 = Load<Texture2D>("Enemies/ExpParticle3");
			Fallingplatform = Load<Texture2D>("Enemies/fallingPlatform");
			Fire_ball = Load<Texture2D>("Enemies/fire-ball");
			Firewisp = Load<Texture2D>("Enemies/FireWisp");
			Firewispprojectile = Load<Texture2D>("Enemies/FireWispProjectile");
			Fly = Load<Texture2D>("Enemies/fly");
			Fly2 = Load<Texture2D>("Enemies/fly2");
			Fly3 = Load<Texture2D>("Enemies/fly3");
			Fly4 = Load<Texture2D>("Enemies/fly4");
			Kobold = Load<Texture2D>("Enemies/Kobold");
			Laser = Load<Texture2D>("Enemies/laser");
			Laser2 = Load<Texture2D>("Enemies/laser2");
			Laser3 = Load<Texture2D>("Enemies/laser3");
			Laser4 = Load<Texture2D>("Enemies/laser4");
			Laser5 = Load<Texture2D>("Enemies/laser5");
			Lava_fall = Load<Texture2D>("Enemies/lava-fall");
			Lava = Load<Texture2D>("Enemies/lava");
			Lavafish = Load<Texture2D>("Enemies/LavaFish");
			Lavaman = Load<Texture2D>("Enemies/LavaMan");
			Minebig = Load<Texture2D>("Enemies/MineBig");
			Ogre = Load<Texture2D>("Enemies/Ogre");
			Pad = Load<Texture2D>("Enemies/Pad");
			Rocketsquare = Load<Texture2D>("Enemies/RocketSquare");
			Saw = Load<Texture2D>("Enemies/Saw");
			Shieldman = Load<Texture2D>("Enemies/ShieldMan");
			Shieldofshieldman = Load<Texture2D>("Enemies/ShieldOfShieldMan");
			Shootplant = Load<Texture2D>("Enemies/shootPlant");
			Slug = Load<Texture2D>("Enemies/Slug");
			Spider = Load<Texture2D>("Enemies/Spider");
			Spideregg = Load<Texture2D>("Enemies/SpiderEgg");
			Spiderweb = Load<Texture2D>("Enemies/SpiderWeb");
			Spike = Load<Texture2D>("Enemies/Spike");
			Stickyslime = Load<Texture2D>("Enemies/StickySlime");
			Stoneman = Load<Texture2D>("Enemies/stoneMan");
			Superstickyslime = Load<Texture2D>("Enemies/SuperStickySlime");
			Toxic = Load<Texture2D>("Enemies/toxic");
			Toxicfall = Load<Texture2D>("Enemies/toxicfall");
			Water = Load<Texture2D>("Enemies/Water");
			Waterfall = Load<Texture2D>("Enemies/Waterfall");
			Abutton = Load<Texture2D>("GUI/AButton");
			Boxbubble = Load<Texture2D>("GUI/BoxBubble");
			Boxtriplejump = Load<Texture2D>("GUI/BoxTripleJump");
			Boxtripleshot = Load<Texture2D>("GUI/BoxTripleShot");
			Buttontype1_off = Load<Texture2D>("GUI/ButtonType1_Off");
			Buttontype1_on = Load<Texture2D>("GUI/ButtonType1_On");
			Buttontype2_off = Load<Texture2D>("GUI/ButtonType2_Off");
			Buttontype2_on = Load<Texture2D>("GUI/ButtonType2_On");
			Consoleview = Load<Texture2D>("GUI/ConsoleView");
			Dialoguebox = Load<Texture2D>("GUI/DialogueBox");
			Dialogueboxsouspart = Load<Texture2D>("GUI/DialogueBoxSousPart");
			Ebutton = Load<Texture2D>("GUI/EButton");
			Lbbutton = Load<Texture2D>("GUI/LBButton");
			Moins = Load<Texture2D>("GUI/Moins");
			Plus = Load<Texture2D>("GUI/Plus");
			Rbbutton = Load<Texture2D>("GUI/RBButton");
			Redcross = Load<Texture2D>("GUI/RedCross");
			Squareitem = Load<Texture2D>("GUI/SquareItem");
			Staminabar = Load<Texture2D>("GUI/StaminaBar");
			Staminapannel = Load<Texture2D>("GUI/StaminaPannel");
			Timersoul = Load<Texture2D>("GUI/TimerSoul");
			Timersoulsspritesheet = Load<Texture2D>("GUI/TimerSoulsSpritesheet");
			Boomerang = Load<Texture2D>("Gun/Boomerang");
			Boomerangicon = Load<Texture2D>("Gun/BoomerangIcon");
			Gun = Load<Texture2D>("Gun/Gun");
			Gunicon = Load<Texture2D>("Gun/GunIcon");
			Jetpackicon = Load<Texture2D>("Gun/JetpackIcon");
			Shotgun = Load<Texture2D>("Gun/ShotGun");
			Shotgunicon = Load<Texture2D>("Gun/ShotgunIcon");
			Shotgunprojectilemax = Load<Texture2D>("Gun/ShotGunProjectileMax");
			Skulldeathgun = Load<Texture2D>("Gun/SkullDeathGun");
			Skulldeathgunicon = Load<Texture2D>("Gun/SkullDeathGunIcon");
			Tornado = Load<Texture2D>("Gun/Tornado");

			// Songs

			Song_0_to_9 = Load<Song>("Musics/0 to 9");
			Song_Boss1 = Load<Song>("Musics/Boss1");
			Song_Level_select = Load<Song>("Musics/Level Select");
			Song_Mini_games = Load<Song>("Musics/Mini Games");
			Song_Pervasive_pain = Load<Song>("Musics/Pervasive Pain");
			Song_Timeless_room = Load<Song>("Musics/Timeless Room");
			Song_Title_screen = Load<Song>("Musics/Title Screen");
			Song_Training_room = Load<Song>("Musics/Training Room");
			Song_Wind_ambiance = Load<Song>("Musics/Wind Ambiance");
			Song_Worst_situation = Load<Song>("Musics/Worst Situation");

			// Textures

			Bg_wall = Load<Texture2D>("Shop/bg_wall");
			Bookshelf_a = Load<Texture2D>("Shop/bookshelf_A");
			Bookshelf_b = Load<Texture2D>("Shop/bookshelf_B");
			Bookshelf_c = Load<Texture2D>("Shop/bookshelf_C");
			Bookshelf_d = Load<Texture2D>("Shop/bookshelf_D");
			Bookshelf_e = Load<Texture2D>("Shop/bookshelf_E");
			Bookshelf_f = Load<Texture2D>("Shop/bookshelf_F");
			Bookshelf_g = Load<Texture2D>("Shop/bookshelf_G");
			Bookshelf_h = Load<Texture2D>("Shop/bookshelf_H");
			Candle = Load<Texture2D>("Shop/Candle");
			Cloud2 = Load<Texture2D>("Shop/Cloud2");
			Cloudfog = Load<Texture2D>("Shop/CloudFog");
			Oldman = Load<Texture2D>("Shop/OldMan");
			Triplejump = Load<Texture2D>("Shop/TripleJump");

			// Sounds

			Sound_Balltap = new Sound(Load<SoundEffect>("Sounds/ballTap"), MainGame.VOLUME_SFX, 0);
			Sound_Bigdeath = new Sound(Load<SoundEffect>("Sounds/BigDeath"), MainGame.VOLUME_SFX, 0);
			Sound_Bigexplosion = new Sound(Load<SoundEffect>("Sounds/BigExplosion"), MainGame.VOLUME_SFX, 0);
			Sound_Bigwalk = new Sound(Load<SoundEffect>("Sounds/bigWalk"), MainGame.VOLUME_SFX, 0);
			Sound_Boomerang = new Sound(Load<SoundEffect>("Sounds/boomerang"), MainGame.VOLUME_SFX, 0);
			Sound_Bossgethit = new Sound(Load<SoundEffect>("Sounds/bossGetHit"), MainGame.VOLUME_SFX, 0);
			Sound_Buy = new Sound(Load<SoundEffect>("Sounds/buy"), MainGame.VOLUME_SFX, 0);
			Sound_Cheatenabled = new Sound(Load<SoundEffect>("Sounds/cheatEnabled"), MainGame.VOLUME_SFX, 0);
			Sound_Clock = new Sound(Load<SoundEffect>("Sounds/Clock"), MainGame.VOLUME_SFX, 0);
			Sound_Crusherfall = new Sound(Load<SoundEffect>("Sounds/CrusherFall"), MainGame.VOLUME_SFX, 0);
			Sound_Crushertouchground = new Sound(Load<SoundEffect>("Sounds/CrusherTouchGround"), MainGame.VOLUME_SFX, 0);
			Sound_Dash = new Sound(Load<SoundEffect>("Sounds/Dash"), MainGame.VOLUME_SFX, 0);
			Sound_Die = new Sound(Load<SoundEffect>("Sounds/die"), MainGame.VOLUME_SFX, 0);
			Sound_Dreamveloper = new Sound(Load<SoundEffect>("Sounds/dreamveloper"), MainGame.VOLUME_SFX, 0);
			Sound_Engine = new Sound(Load<SoundEffect>("Sounds/engine"), MainGame.VOLUME_SFX, 0);
			Sound_Exp = new Sound(Load<SoundEffect>("Sounds/Exp"), MainGame.VOLUME_SFX, 0);
			Sound_Explosionparticle = new Sound(Load<SoundEffect>("Sounds/ExplosionParticle"), MainGame.VOLUME_SFX, 0);
			Sound_Fireballmeteorfalling = new Sound(Load<SoundEffect>("Sounds/FireballMeteorFalling"), MainGame.VOLUME_SFX, 0);
			Sound_Firewispprojectile = new Sound(Load<SoundEffect>("Sounds/FireWispProjectile"), MainGame.VOLUME_SFX, 0);
			Sound_Flydamage = new Sound(Load<SoundEffect>("Sounds/flyDamage"), MainGame.VOLUME_SFX, 0);
			Sound_Flydeath = new Sound(Load<SoundEffect>("Sounds/flydeath"), MainGame.VOLUME_SFX, 0);
			Sound_Grasswalk1 = new Sound(Load<SoundEffect>("Sounds/grassWalk1"), MainGame.VOLUME_SFX, 0);
			Sound_Grasswalk2 = new Sound(Load<SoundEffect>("Sounds/grassWalk2"), MainGame.VOLUME_SFX, 0);
			Sound_Grasswalk3 = new Sound(Load<SoundEffect>("Sounds/grassWalk3"), MainGame.VOLUME_SFX, 0);
			Sound_Gunincrease = new Sound(Load<SoundEffect>("Sounds/GunIncrease"), MainGame.VOLUME_SFX, 0);
			Sound_Jump0 = new Sound(Load<SoundEffect>("Sounds/jump0"), MainGame.VOLUME_SFX, 0);
			Sound_Justtouchedground = new Sound(Load<SoundEffect>("Sounds/justTouchedGround"), MainGame.VOLUME_SFX, 0);
			Sound_Levelup = new Sound(Load<SoundEffect>("Sounds/LevelUp"), MainGame.VOLUME_SFX, 0);
			Sound_Loadlaser = new Sound(Load<SoundEffect>("Sounds/LoadLaser"), MainGame.VOLUME_SFX, 0);
			Sound_Observerbeginlaser = new Sound(Load<SoundEffect>("Sounds/observerBeginLaser"), MainGame.VOLUME_SFX, 0);
			Sound_Observerchangedirection = new Sound(Load<SoundEffect>("Sounds/observerChangeDirection"), MainGame.VOLUME_SFX, 0);
			Sound_Observercrock = new Sound(Load<SoundEffect>("Sounds/observerCrock"), MainGame.VOLUME_SFX, 0);
			Sound_Observerredlaser = new Sound(Load<SoundEffect>("Sounds/observerRedLaser"), MainGame.VOLUME_SFX, 0);
			Sound_Observersneak = new Sound(Load<SoundEffect>("Sounds/observerSneak"), MainGame.VOLUME_SFX, 0);
			Sound_Pold = new Sound(Load<SoundEffect>("Sounds/pold"), MainGame.VOLUME_SFX, 0);
			Sound_Powerup = new Sound(Load<SoundEffect>("Sounds/PowerUp"), MainGame.VOLUME_SFX, 0);
			Sound_Relicdrawline = new Sound(Load<SoundEffect>("Sounds/relicDrawLine"), MainGame.VOLUME_SFX, 0);
			Sound_Relicflash = new Sound(Load<SoundEffect>("Sounds/relicFlash"), MainGame.VOLUME_SFX, 0);
			Sound_Relicobtained = new Sound(Load<SoundEffect>("Sounds/relicObtained"), MainGame.VOLUME_SFX, 0);
			Sound_Reload = new Sound(Load<SoundEffect>("Sounds/reload"), MainGame.VOLUME_SFX, 0);
			Sound_Reversecamera = new Sound(Load<SoundEffect>("Sounds/ReverseCamera"), MainGame.VOLUME_SFX, 0);
			Sound_Rewind = new Sound(Load<SoundEffect>("Sounds/rewind"), MainGame.VOLUME_SFX, 0);
			Sound_Robotjump = new Sound(Load<SoundEffect>("Sounds/robotJump"), MainGame.VOLUME_SFX, 0);
			Sound_Select = new Sound(Load<SoundEffect>("Sounds/select"), MainGame.VOLUME_SFX, 0);
			Sound_Shoot = new Sound(Load<SoundEffect>("Sounds/shoot"), MainGame.VOLUME_SFX, 0);
			Sound_Shotgunshoot = new Sound(Load<SoundEffect>("Sounds/shotgunShoot"), MainGame.VOLUME_SFX, 0);
			Sound_Spikefall = new Sound(Load<SoundEffect>("Sounds/SpikeFall"), MainGame.VOLUME_SFX, 0);
			Sound_Sprint = new Sound(Load<SoundEffect>("Sounds/Sprint"), MainGame.VOLUME_SFX, 0);
			Sound_Switchgun = new Sound(Load<SoundEffect>("Sounds/SwitchGun"), MainGame.VOLUME_SFX, 0);
			Sound_Switchmode = new Sound(Load<SoundEffect>("Sounds/SwitchMode"), MainGame.VOLUME_SFX, 0);
			Sound_Talk1 = new Sound(Load<SoundEffect>("Sounds/talk1"), MainGame.VOLUME_SFX, 0);
			Sound_Talk2 = new Sound(Load<SoundEffect>("Sounds/talk2"), MainGame.VOLUME_SFX, 0);
			Sound_Teleportend = new Sound(Load<SoundEffect>("Sounds/teleportEnd"), MainGame.VOLUME_SFX, 0);
			Sound_Teleportstart = new Sound(Load<SoundEffect>("Sounds/teleportStart"), MainGame.VOLUME_SFX, 0);
			Sound_Thunder = new Sound(Load<SoundEffect>("Sounds/thunder"), MainGame.VOLUME_SFX, 0);
			Sound_Timersoul = new Sound(Load<SoundEffect>("Sounds/TimerSoul"), MainGame.VOLUME_SFX, 0);
			Sound_Triplejump = new Sound(Load<SoundEffect>("Sounds/TripleJump"), MainGame.VOLUME_SFX, 0);
			Sound_Uneffectivedamage = new Sound(Load<SoundEffect>("Sounds/UneffectiveDamage"), MainGame.VOLUME_SFX, 0);
			Sound_Validate = new Sound(Load<SoundEffect>("Sounds/validate"), MainGame.VOLUME_SFX, 0);
			Sound_Vortex = new Sound(Load<SoundEffect>("Sounds/vortex"), MainGame.VOLUME_SFX, 0);
			Sound_Walk0 = new Sound(Load<SoundEffect>("Sounds/walk0"), MainGame.VOLUME_SFX, 0);
			Sound_Walk1 = new Sound(Load<SoundEffect>("Sounds/walk1"), MainGame.VOLUME_SFX, 0);
			Sound_Walkwater1 = new Sound(Load<SoundEffect>("Sounds/walkWater1"), MainGame.VOLUME_SFX, 0);
			Sound_Walkwater2 = new Sound(Load<SoundEffect>("Sounds/walkWater2"), MainGame.VOLUME_SFX, 0);
			Sound_Walkwater3 = new Sound(Load<SoundEffect>("Sounds/walkWater3"), MainGame.VOLUME_SFX, 0);
			Sound_Walkwater4 = new Sound(Load<SoundEffect>("Sounds/walkWater4"), MainGame.VOLUME_SFX, 0);
			Sound_Watercrash = new Sound(Load<SoundEffect>("Sounds/waterCrash"), MainGame.VOLUME_SFX, 0);
			Sound_Waterdrop = new Sound(Load<SoundEffect>("Sounds/WaterDrop"), MainGame.VOLUME_SFX, 0);

			// Textures

			Streamer1 = Load<Texture2D>("Streamers/Streamer1");
			Streamer2 = Load<Texture2D>("Streamers/Streamer2");
			Streamer3 = Load<Texture2D>("Streamers/Streamer3");
			Streamer4 = Load<Texture2D>("Streamers/Streamer4");
			Streamer5 = Load<Texture2D>("Streamers/Streamer5");
			Winnerconcours = Load<Texture2D>("Streamers/WinnerConcours");
			Trainingroom_bg1 = Load<Texture2D>("TrainingRoom/TrainingRoom_bg1");
			Trainingroom_bg2 = Load<Texture2D>("TrainingRoom/TrainingRoom_bg2");
			Trainingroom_bg3 = Load<Texture2D>("TrainingRoom/TrainingRoom_bg3");
			Dashtuto = Load<Texture2D>("Tuto/DashTuto");
			Doublejumptuto = Load<Texture2D>("Tuto/DoubleJumpTuto");
			Explaindash = Load<Texture2D>("Tuto/ExplainDash");
			Explainjump = Load<Texture2D>("Tuto/ExplainJump");
			Explainplus = Load<Texture2D>("Tuto/ExplainPlus");
			Explainsprint = Load<Texture2D>("Tuto/ExplainSprint");
			Shoottuto = Load<Texture2D>("Tuto/ShootTuto");
			Sprinttuto = Load<Texture2D>("Tuto/SprintTuto");
		}

	}
}