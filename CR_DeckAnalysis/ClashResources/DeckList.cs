using CR_DeckAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClashResources
{
    public static class DeckList
    {
        public static List<Deck> getRecommendedDecks()
        {
            var r = new List<Deck>();

            //Arena 4: !GiantTrifecta !HogTrifecta4 !BarrelHog !BarrelGiant

            r.Add(new Deck("GiantTrifecta", "Giant, Musketeer, Mini Pekka, Bomber, Arrows, Fireball, Minions, Cannon"));
            r.Add(new Deck("HogTrifecta4", "Hog Rider, Musketeer, Valkyrie, Goblins, Minions, Cannon, Fireball, Arrows"));
            r.Add(new Deck("BarrelHog", "Hog Rider, Goblin Barrel, Minion Horde, Barbarians, Musketeer, Goblins, Arrows, Fireball"));
            r.Add(new Deck("BarrelGiant", "Giant, Witch, Musketeer, Knight, Goblin Barrel, Goblin Hut, Spear Goblins, Arrows"));

            //Arena 5: !HogBarrel !HogMini !GWRage !HogPrince !BarrelHog !BarrelGiant

            r.Add(new Deck("HogBarrel", "Hog Rider, Goblin Barrel, Mini Pekka, Fire Spirits, Goblins, Zap, Inferno Tower, Fireball"));
            r.Add(new Deck("HogMini", "Hog Rider, Mini Pekka, Valkyrie, Fire Spirits, Goblins, Zap, Fireball, Inferno Tower"));
            r.Add(new Deck("GWRage", "Giant, Witch, Rage, Mini Pekka, Musketeer, Minions, Fire Spirits, Zap"));
            r.Add(new Deck("HogPrince", "Hog Rider, Prince, Valkyrie, Fire Spirits, Goblins, Fireball, Zap, Inferno Tower"));

            //Arena 6: !ValkPrince !MinerBarrel !HogTrifecta !GWRage !GiantHog !HogFreeze !Mortar !GiantBarrel !IceHog !GolemPoison !HogMiner2

            r.Add(new Deck("ValkPrince", "Valkyrie, Prince, Elixir Collector, Freeze, Musketeer, Mini Pekka, Barbarians, Arrows"));
            r.Add(new Deck("MinerBarrel1", "Miner, Goblin Barrel, Fire Spirits, Barbarians, Elixir Collector, Zap, Inferno Tower, Fireball"));
            r.Add(new Deck("MinerBarrel2", "Miner, Goblin Barrel, Ice Wizard, Princess, Minion Horde, Mini Pekka, Cannon, Zap"));
            r.Add(new Deck("HogTrifecta", "Hog Rider, Valkyrie, Musketeer, Zap, Fireball, Skeletons, Cannon, Minions"));
            r.Add(new Deck("GiantHog", "Giant, Hog Rider, Musketeer, Barbarians, Minions, Fireball, Zap, Elixir Collector"));
            r.Add(new Deck("HogFreeze", "Hog Rider, Freeze, Barbarians, Knight, Archers, Cannon, Fireball, Elixir Collector"));
            r.Add(new Deck("Mortar", "Mortar, Barbarians, Minion Horde, Skeletons, Arrows, Fireball, Inferno Tower, Elixir Collector"));
            r.Add(new Deck("GiantBarrel", "Giant, Goblin Barrel, Goblins, Minion Horde, Minions, Fireball, Zap, Elixir Collector"));
            r.Add(new Deck("IceHog", "Hog Rider, Ice Wizard, Goblins, Spear Goblins, Inferno Tower, Fireball, Zap, Elixir Collector"));
            r.Add(new Deck("GolemPoison", "Golem, Witch, Musketeer, Mini Pekka, Minions, Poison, Zap, Elixir Collector"));
            r.Add(new Deck("HogMiner2", "Hog Rider, Miner, Skeleton Army, Minion Horde, Goblins, Ice Wizard, Inferno Tower, Zap"));

            //Arean 7:  !GiantPoison !ValkPrince !MinerBarrel !HogTrifecta !LavaHound !ValkPrince !DPMega !MinerFurnace !MinerPrincess !RoyalCheese !RGBarrel 
            // !GolemPoison !GiantHog !PDPL3M !LavaLoon !Giant3M !HogFreeze !Mortar !PekkaDP 
            // !SparkyBait !HogMiner !GiantBarrel !MegaRG !MinerDP !IceHog !HogFreeze2 !BabyLava !SkarmyBait !HogMiner2

            r.Add(new Deck("GiantPoison", "Giant, Poison, Elixir Collector, Zap, Ice Spirit, Mega Minion, Prince, Musketeer"));
            r.Add(new Deck("LavaHound", "Lava Hound, Minions, Mega Minion, Ice Spirit, Tombstone, Fireball, Zap, Miner"));
            r.Add(new Deck("DPMega", "Prince, Dark Prince, Mega Minion, Musketeer, Guards, Arrows, Zap, Elixir Collector"));
            r.Add(new Deck("MinerFurnace", "Miner, Musketeer, Mini Pekka, Furnace, Guards, Fireball, Zap, Princess"));
            r.Add(new Deck("MinerPrincess", "Miner, Princess, Mini Pekka, Zap, Guards, Log, Inferno Tower, Elixir Collector"));
            r.Add(new Deck("RoyalCheese", "Royal Giant, Miner, Ice Wizard, Mini Pekka, Fireball, Elixir Collector, Zap, Cannon"));
            r.Add(new Deck("RGBarrel", "Royal Giant, Goblin Barrel, Minion Horde, Barbarians, Elixir Collector, Cannon, Zap, Fire Spirits"));

            r.Add(new Deck("GolemPoison", "Golem, Witch, Musketeer, Mini Pekka, Minions, Poison, Zap, Elixir Collector"));
            r.Add(new Deck("PDPL3M", "Pekka, Three Musketeers, Prince, Dark Prince, Lumberjack, Minion Horde, Arrows, Elixir Collector"));
            r.Add(new Deck("LavaLoon", "Lava Hound, Balloon, Mega Minion, Mini Pekka, Guards, Lightning, Arrows, Elixir Collector"));
            r.Add(new Deck("Giant3M", "Giant, Three Musketeers, Miner, Minion Horde, Skeleton Army, Ice Spirit, Zap, Elixir Collector"));
            r.Add(new Deck("PekkaDP", "Pekka, Prince, Dark Prince, Mega Minion, Princess, Freeze, Arrows, Elixir Collector"));

            r.Add(new Deck("SparkyBait", "Sparky, Goblin Barrel, Giant, Princess, Guards, Minions, Zap, Elixir Collector"));
            r.Add(new Deck("HogMiner", "Hog Rider, Miner, Princess, Barbarians, Minion Horde, Goblins, Zap, Fireball"));
            r.Add(new Deck("MegaRG", "Royal Giant, Mega Minion, Miner, Princess, Barbarians, Fireball, Zap, Elixir Collector"));
            r.Add(new Deck("MinerDP", "Miner, Prince, Dark Prince, Princess, Spear Goblins, Barbarians, Zap, Elixir Collector"));
            r.Add(new Deck("HogFreeze2", "Hog Rider, Freeze, Fireball, Mega Minion, Skeletons, Ice Spirit, Inferno Tower, Elixir Collector"));
            r.Add(new Deck("BabyLava", "Lava Hound, Baby Dragon, Mega Minion, Barbarians, Tombstone, Lightning, Zap, Elixir Collector"));
            r.Add(new Deck("SkarmyBait", "Miner, Princess, Goblin Barrel, Skeleton Army, Minion Horde, Goblins, Inferno Tower, Zap"));


            //Arena8:  !HogTrifecta !HogLightning !HogCycle !HogCycle2 !HogInferno !HogRocket !HogFreeze !HogFreeze2 !HogFreeze3 !HogMiner 
            //!HogMiner2 !IceHog !HogLog !HogBowler !GiantLightning !GiantMega !InfernoGiant !InfernoGiant2 !LumberGiant !Giant3M !GiantBarrel 

            r.Add(new Deck("HogTrifecta", "Hog Rider, Valkyrie, Musketeer, Zap, Fireball, Skeletons, Cannon, Ice Spirit"));
            r.Add(new Deck("HogLightning", "Hog Rider, Lightning, Zap, Mega Minion, Ice Spirit, Ice Wizard, Inferno Tower, Elixir Collector"));
            r.Add(new Deck("HogCycle", "Hog Rider, Princess, Mini Pekka, Ice Spirit, Skeletons, Zap, Fireball, Elixir Collector"));
            r.Add(new Deck("HogCycle2", "Hog Rider, Guards, Skeletons, Ice Spirit, Inferno Tower, Zap, Fireball, Elixir Collector"));
            r.Add(new Deck("HogInferno", "Hog Rider, Inferno Dragon, Bowler, Ice Spirit, Skeletons, Zap, Fireball, Inferno Tower"));
            r.Add(new Deck("HogRocket", "Hog Rider, Rocket, Freeze, Mega Minion, Mini Pekka, Princess, Guards, Ice Spirit"));
            r.Add(new Deck("HogFreeze", "Hog Rider, Freeze, Barbarians, Knight, Archers, Cannon, Fireball, Elixir Collector"));
            r.Add(new Deck("HogFreeze2", "Hog Rider, Freeze, Fireball, Mega Minion, Skeletons, Ice Spirit, Inferno Tower, Elixir Collector"));
            r.Add(new Deck("HogFreeze3", "Hog Rider, Freeze, Princess, Mega Minion, Mini Pekka, Skeleton Army, Ice Spirit, Zap"));
            r.Add(new Deck("HogMiner2", "Hog Rider, Miner, Skeleton Army, Minion Horde, Goblins, Ice Wizard, Inferno Tower, Zap"));
            r.Add(new Deck("IceHog", "Hog Rider, Ice Wizard, Goblins, Spear Goblins, Inferno Tower, Fireball, Zap, Elixir Collector"));
            r.Add(new Deck("HogLog", "Hog Rider, The Log, Princess, Ice Wizard, Mini Pekka, Guards, Ice Spirit, Rocket"));
            r.Add(new Deck("HogBowler", "Hog Rider, Bowler, Mega Minion, Ice Spirit, Skeletons, Zap, Fireball, Inferno Tower"));
            r.Add(new Deck("GiantLightning", "Giant, Lightning, Mega Minion, Prince, Elixir Collector, Zap, Ice Spirit, Ice Wizard"));
            r.Add(new Deck("GiantMega", "Giant, Mega Minion, Bowler, Musketeer, Fireball, Zap, Ice Spirit, Elixir Collector"));
            r.Add(new Deck("InfernoGiant", "Inferno Dragon, Giant, Mega Minion, Ice Spirit, Skeletons, Zap, Fireball, Elixir Collector"));
            r.Add(new Deck("InfernoGiant2", "Giant, Inferno Dragon, Mega Minion, Skeleton Army, Ice Spirit, Zap, The Log, Elixir Collector"));
            r.Add(new Deck("LumberGiant", "Giant, Lumberjack, Mega Minion, Musketeer, Ice Spirit, Zap, Poison, Elixir Collector"));
            r.Add(new Deck("Giant3M", "Giant, Three Musketeers, Miner, Minion Horde, Skeleton Army, Ice Spirit, Zap, Elixir Collector"));
            r.Add(new Deck("GiantBarrel", "Giant, Goblin Barrel, Goblins, Minion Horde, Minions, Fireball, Zap, Elixir Collector"));


            //!GiantMirror !GiantLog !GiantLumber !GiantPoison !LavaHound !IceLava !LavaLightning !InfernoLava !LavaLoon !BabyLava !LavaMiner 
            //!HoundLumber !SparkyBarrel !OPSparky !MegaSparky !SparkyBait !MinerFurnace !MinerFurnace2 !MinerFurnace3 !MinerPrincess 

            r.Add(new Deck("GiantMirror", "Giant, Elixir Collector, Mirror, Musketeer, Mega Minion, Skeletons, Ice Spirit, Zap"));
            r.Add(new Deck("GiantLog", "Giant, Log, Princess, Prince, Mega Minion, Skeletons, Ice Spirit, Zap"));
            r.Add(new Deck("GiantLumber", "Giant, Lumberjack, Ice Wizard, Mega Minion, Minions, Log, Zap, Lightning"));
            r.Add(new Deck("IceLava", "Lava Hound, Ice Wizard, Mega Minion, Guards, Fireball, Ice Spirit, Zap, Elixir Collector"));
            r.Add(new Deck("LavaLightning", "Lava Hound, Lightning, Mega Minion, Minions, Arrows, Ice Spirit, Miner, Tombstone"));
            r.Add(new Deck("InfernoLava", "Lava Hound, Inferno Dragon, Mega Minion, Miner, Tombstone, Poison, Zap, Elixir Collector"));
            r.Add(new Deck("LavaMiner", "Lava Hound, Miner, Mega Minion, Mini Pekka, Ice Spirit, Skeletons, Zap, Poison"));
            r.Add(new Deck("HoundLumber", "Lava Hound, Lumberjack, Tombstone, Elixir Collector, Minions, Mega Minion, Poison, Zap"));
            r.Add(new Deck("SparkyBarrel", "Sparky, Goblin Barrel, Giant, Zap, Mini Pekka, Ice Spirit, Ice Wizard, Fire Spirit"));
            r.Add(new Deck("OPSparky", "Sparky, Miner, Giant, Witch, Mini Pekka, Ice Spirit, Zap, Elixir Collector"));
            r.Add(new Deck("MegaSparky", "Sparky, Giant, Mega Minion, Musketeer, Miner, Ice Spirit, Zap, Elixir Collector"));
            r.Add(new Deck("MinerFurnace2", "Miner, Furnace, Mega Minion, Ice Spirit, Skeletons, Log, Zap, Inferno Tower"));
            r.Add(new Deck("MinerFurnace3", "Miner, Furnace, Skeleton Army, Lightning, Musketeer, Mega Minion, Ice Spirit, Log"));

            //!MinerLightning !LogMiner !LogMiner2 !LogMiner3 !MinerBowler !InfernoMiner !MirrorMiner !MinerDP !IceMiner !MinerRocket
            //!InfernoGolem !GolemPoison !GolemBowler !MegaGolem !LumberGolem !Golem3M
            //!LumberMusk !Pekka3Musk !Mirror3M !PDPL3M !Pekka3M !PekkaDP !BowlerBeatdown !BowlerPrince !BowlerSiege !MortarBowler !Mortar !xbow
            //!SkarmyBait !InfernoSkarmy !SkellyBait !InfernoBait !ValkPrince !DPMega !MegaRage !MegaBeatdown !MegaLumber !MegaRG 
            //!RoyalCheese !RGBarrel !LumberLoon !LoonFreeze !Payfecta

            r.Add(new Deck("MinerLightning", "Miner, Lightning, Furnace, Inferno Tower, Knight, Goblins, Zap, Ice Spirit"));
            r.Add(new Deck("LogMiner", "Log, Miner, Princess, Mega Minion, Fireball, Skeletons, Ice Spirit, Inferno Tower"));
            r.Add(new Deck("LogMiner2", "Log, Miner, Princess, Ice Spirit, Mini Pekka, Goblins, Inferno Tower, Zap"));
            r.Add(new Deck("LogMiner3", "Log, Miner, Fireball, Inferno Tower, Mega Minion, Guards, Ice Spirit, Elixir Collector"));
            r.Add(new Deck("MinerBowler", "Miner, Bowler, Guards, Mega Minion, Ice Spirit, Zap, Fireball, Inferno Tower"));
            r.Add(new Deck("InfernoMiner", "Inferno Dragon, Miner, Musketeer, Guards, Ice Spirit, Zap, Fireball, Inferno Tower"));
            r.Add(new Deck("MirrorMiner", "Mirror, Miner, Bowler, Ice Spirit, Fireball, Zap, Elixir Collector, Inferno Tower"));
            r.Add(new Deck("IceMiner", "Ice Golem, Miner, Goblins, Goblin Barrel, Ice Spirit, Inferno Tower, Fireball, Zap"));
            r.Add(new Deck("MinerRocket", "Miner, Rocket, Mega Minion, Skeleton Army, Ice Spirit, Princess, Zap, Inferno Tower"));
            r.Add(new Deck("InfernoGolem", "Inferno Dragon, Golem, Mega Minion, Ice Spirit, Skeletons, Zap, Log, Elixir Collector"));
            r.Add(new Deck("GolemBowler", "Golem, Bowler, Musketeer, Mega Minion, Ice Spirit, Zap, Poison, Elixir Collector"));
            r.Add(new Deck("MegaGolem", "Golem, Mega Minion, Bowler, Prince, Poison, Zap, Elixir Collector, Ice Spirit"));
            r.Add(new Deck("LumberGolem", "Golem, Lumberjack, Musketeer, Mega Minion, Ice Spirit, Poison, Zap, Elixir Collector"));
            r.Add(new Deck("Golem3M", "Golem, Three Musketeers, Bomber, Barbarians, Goblins, Arrows, Ice Spirit, Elixir Collector"));
            r.Add(new Deck("LumberMusk", "Lumberjack, Three Musketeers, Miner, Valkyrie, Barbarians, Ice Spirit, Elixir Collector, Zap"));
            r.Add(new Deck("Pekka3Musk", "Pekka, Three Musketeers, Rage, Knight, Arrows, Elixir Collector, Ice Spirit, Fire Spirits"));
            r.Add(new Deck("Mirror3M", "Mirror, Three Musketeers, Miner, Minion Horde, Ice Golem, Ice Spirit, Zap, Elixir Collector"));
            r.Add(new Deck("Pekka3M", "Pekka, Three Musketeers, Miner, Ice Golem, Minions, Ice Spirit, Arrows, Elixir Collector"));
            r.Add(new Deck("PekkaDP", "Pekka, Prince, Dark Prince, Mega Minion, Princess, Freeze, Arrows, Elixir Collector"));
            r.Add(new Deck("BowlerBeatdown", "Bowler, Giant, Poison, Zap, Elixir Collector, Musketeer, Mega Minion, Ice Spirit"));
            r.Add(new Deck("BowlerPrince", "Bowler, Prince, Giant, Mega Minion, Ice Spirit, Elixir Collector, Poison, Zap"));
            r.Add(new Deck("BowlerSiege", "Bowler, Rocket, Log, Zap, Ice Wizard, Guards, Inferno Tower, Elixir Collector"));
            r.Add(new Deck("MortarBowler", "Mortar, Bowler, Elixir Collector, Inferno Tower, Ice Spirit, Skeletons, Zap, Lightning"));
            r.Add(new Deck("XBow", "X-Bow, Inferno Tower, Mega Minion, Guards, Ice Spirit, Fire Spirit, Fireball, Log"));

            //!SkarmyBait !InfernoSkarmy !SkellyBait !InfernoBait !ValkPrince !DPMega !MegaRage !MegaBeatdown !MegaLumber !MegaRG 
            //!RoyalCheese !RGBarrel !LumberLoon !LoonFreeze !Payfecta

            r.Add(new Deck("InfernoSkarmy", "Lava Hound, Inferno Dragon, Mega Minion, Miner, Skeleton Army, Minion Horde, Ice Spirit, Arrows"));
            r.Add(new Deck("SkellyBait", "Giant Skeleton, Skeleton Army, Miner, Princess, Goblin Barrel, Minion Horde, Ice Spirit, Zap"));
            r.Add(new Deck("InfernoBait", "Inferno Dragon, Miner, The Log, Goblin Barrel, Minion Horde, Cannon, Ice Spirit, Zap"));
            r.Add(new Deck("MegaRage", "Giant, Mega Minion, Rage, Witch, Ice Spirit, Zap, Tombstone, Elixir Collector"));
            r.Add(new Deck("MegaBeatdown", "Giant, Mega Minion, Bowler, Prince, Ice Spirit, Poison, Zap, Elixir Collector"));
            r.Add(new Deck("MegaLumber", "Giant, Lumberjack, Mega Minion, Bowler, Ice Spirit, Poison, Zap, Elixir Collector"));
            r.Add(new Deck("LumberLoon", "Lumberjack, Balloon, Giant Skeleton, Elixir Collector, Minions, Minion Horde, Arrows, Freeze"));
            r.Add(new Deck("LoonFreeze", "Balloon, Freeze, Ice Spirit, Dark Prince, Mini Pekka, Arrows, Elixir Collector, Minions"));
            r.Add(new Deck("Payfecta", "Miner, Ice Wizard, Princess, Mini Pekka, Zap, Inferno Tower, Goblins, Fire Spirits"));

            return r;
        }
    }
}
