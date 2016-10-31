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

            r.Add(new Deck("HogCycle", "Hog Rider, Princess, Mini Pekka, Ice Spirit, Skeletons, Zap, Fireball, Elixir Collector"));
            r.Add(new Deck("Payfecta", "Miner, Ice Wizard, Princess, Mini Pekka, Zap, Inferno Tower, Goblins, Fire Spirits"));

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


            //Arena8:  !HogTrifecta !HogLightning !HogCycle !HogCycle2 !HogInferno !HogRocket !HogFreeze !HogFreeze2 !HogFreeze3 !HogMiner !HogMiner2 !IceHog !HogLog !HogBowler 
            //!GiantLightning !GiantMega !InfernoGiant !InfernoGiant2 !LumberGiant !Giant3M !GiantBarrel !GiantMirror !GiantLog !GiantLumber !GiantPoison
            //!LavaHound !IceLava !LavaLightning !InfernoLava !LavaLoon !BabyLava !LavaMiner !HoundLumber
            //!SparkyBarrel !OPSparky !MegaSparky !SparkyBait
            //!MinerFurnace !MinerFurnace2 !MinerFurnace3 !MinerPrincess !MinerLightning !LogMiner !LogMiner2 !LogMiner3 !MinerBowler !InfernoMiner !MirrorMiner !MinerDP !IceMiner !MinerRocket
            //!InfernoGolem !GolemPoison !GolemBowler !MegaGolem !LumberGolem !Golem3M
            //!LumberMusk !Pekka3Musk !Mirror3M !PDPL3M !Pekka3M !PekkaDP
            //!BowlerBeatdown !BowlerPrince !BowlerSiege !MortarBowler !Mortar !xbow
            //!SkarmyBait !InfernoSkarmy !SkellyBait !InfernoBait !ValkPrince !DPMega !MegaRage !MegaBeatdown !MegaLumber !MegaRG !RoyalCheese !RGBarrel !LumberLoon !LoonFreeze !Payfecta


            //Arena9: !HogTrifecta !HogLightning !HogCycle !HogCycle2 !HogInferno !HogRocket !HogFreeze !HogFreeze2 !HogFreeze3 !HogMiner !HogMiner2 !IceHog !HogLog !HogBowler 
            //!GiantLightning !GiantMega !InfernoGiant !InfernoGiant2 !LumberGiant !Giant3M !GiantBarrel !GiantMirror !GiantLog !GiantLumber !GiantPoison
            //!LavaHound !IceLava !LavaLightning !InfernoLava !LavaLoon !BabyLava !LavaMiner !HoundLumber
            //!SparkyBarrel !OPSparky !MegaSparky !SparkyBait
            //!MinerFurnace !MinerFurnace2 !MinerFurnace3 !MinerPrincess !MinerLightning !LogMiner !LogMiner2 !LogMiner3 !MinerBowler !InfernoMiner !MirrorMiner !MinerDP !IceMiner !MinerRocket
            //!InfernoGolem !GolemPoison !GolemBowler !MegaGolem !LumberGolem !Golem3M
            //!LumberMusk !Pekka3Musk !Mirror3M !PDPL3M !Pekka3M !PekkaDP
            //!BowlerBeatdown !BowlerPrince !BowlerSiege !MortarBowler !Mortar !xbow
            //!SkarmyBait !InfernoSkarmy !SkellyBait !InfernoBait !ValkPrince !DPMega !MegaRage !MegaBeatdown !MegaLumber !MegaRG !RoyalCheese !RGBarrel !LumberLoon !LoonFreeze !Payfecta





            return r;
        }
    }
}
