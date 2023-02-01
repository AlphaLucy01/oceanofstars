using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;

namespace oceanofstars.Content.NPCs.enemies.CrystalHeart
{
    [AutoloadBossHead]
    internal class CrystalHeartBody : ModNPC
    {
        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Crystal Heart");
            //Main.npcFrameCount[Type] = 6;
            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                CustomTexturePath = "oceanofstars/Content/NPCs/enemies/CrystalHeart/CrystalHeartPreview",
                PortraitScale = 0.6f, // Portrait refers to the full picture when clicking on the icon in the bestiary
                PortraitPositionYOverride = 0f,
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            // Automatically group with other bosses
            NPCID.Sets.BossBestiaryPriority.Add(Type);


            //immune
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[]
                {
                    BuffID.OnFire
                    ,
                    BuffID.Confused
				}
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);

        }
        public override void SetDefaults()
        {
            NPC.width = 560;
            NPC.height = 400;
            NPC.damage = 12;
            NPC.defense = 10;
            NPC.lifeMax = 1000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = false;
            NPC.value = Item.buyPrice(gold: 5);
            NPC.SpawnWithHigherTime(30);
            NPC.boss = true;
            NPC.npcSlots = 10f; // Take up open spawn slots, preventing random NPCs from spawning during the fight

            // Don't set immunities like this as of 1.4:
            // NPC.buffImmune[BuffID.Confused] = true;
            // immunities are handled via dictionaries through NPCID.Sets.DebuffImmunitySets

            // Custom AI, 0 is "bound town NPC" AI which slows the NPC down and changes sprite orientation towards the target
            NPC.aiStyle = -1;

            // Custom boss bar
            //NPC.BossBar = ModContent.GetInstance<>();

            // The following code assigns a music track to the boss in a simple way.
            if (!Main.dedServ)
            {
                //Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/Ropocalypse2");
            }

        }
        public override void OnSpawn(IEntitySource source)
        {
            
        }
        public override void AI()
        {
            int midstage = 0;
            int stage;
            int part = NPC.lifeMax / 4;
            int result = (int)((float)NPC.life / (float)part);
            switch (result)
            {
                case 0:
                    stage = 4;
                    // HP is 25% or less
                    break;
                case 1:
                    stage = 3;
                    // HP is between 26% and 50%
                    break;
                case 2:
                    stage = 2;
                    // HP is between 51% and 75%
                    break;
                default:
                    stage = 1;
                    // HP is more than 75%
                    break;
            }
            ref float attackTimer = ref NPC.ai[0];
            int timerMult = NPC.lifeMax / NPC.life;
            if(timerMult > 10) timerMult = 10;
            attackTimer++;
            //
            if (NPC.Distance(Main.player[NPC.target].position) / 16 < 20) { NPC.immortal = true; } else { NPC.immortal = false; }
            if(midstage == 1 || midstage == 2 || midstage == 3 || midstage == 4) { NPC.immortal = true; } else { NPC.immortal = false; }
            //
            #region dust circle
            UsefulFunctions.DustRing(NPC.Center, 160, DustID.AmberBolt);
            #endregion
        }
        public void SpawnVein()
        {

        }
        public void SpawnCrawler()
        {

        }
    }
}
