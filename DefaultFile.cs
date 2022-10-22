using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backpacker
{
    [Serializable]
    public class DefaultChinese
    {
        public string LanguageType = "简体中文";
        public string Author = "云汪家";
        public string Version = "1.0";
        public int fontSize = 12;
        public DefaultChinese() { }
        public Dictionary<string, string> Lib = new Dictionary<string, string> ()
        {

            {"AimingAid","ON/OFF--瞄准辅助"},
            {"Day", "当前游戏天数："},
            {"HP","血量："},
            {"Katana","武士刀：" },
            {"ModernBow","现代弓："},
            {"CrossBow","十字弩："},
            {"FlareGun","信号枪："},
            {"Club","大头棒："},
            {"Chainsaw","油锯："},
            {"ModernAxe","现代斧："},
            {"ClimbingAxe","登山镐："},
            {"Pistol","燧发枪："},
            {"RustyAxe","生锈斧："},
            {"Machrtr","弯刀："},
            {"Keycard","普通门卡：" },
            {"Camcorder","摄像机：" },
            {"Pouch","收纳袋：" },
            {"CassettePlayer","录音机："},
            {"TennisRacket","网球拍："},
            {"Pedometer","计步器："},
            {"Compass","指南针："},
            {"Redreather","潜水器："},
            {"Pot","锅：" },
            {"CaveMap","洞穴地图：" },
            {"Shell","龟壳："},
            {"RepairTool", "修理工具："},
            {"Waterskin","水袋：" },
            {"Time" ,"时间状态："},
            {"MP","耐力：" },
            {"Soda", "苏打水容量" },
            {"Arrows/Bolt", "箭/弩箭容量" },
            {"WeakSpear", "易断长矛容量" },
            {"Flare", "照明弹容量" },
            {"Bone/Skull","骨头/骷髅头容量" },
            {"FuelCan", "燃料容量" },
            {"Atick", "木棍容量" },
            {"Rock", "石头容量" },
            {"Dynamite", "炸药容量" },
            {"Molotov", "燃烧瓶容量" },
            {"Meds/Health", "药品/草药容量" },
            {"Explosive","定时炸弹容量" },
            {"AloeVera", "草药植物容量" },
            {"AllBerries", "所有浆果容量" },
            {"Fish/Rabbit", "鱼/蜥蜴/兔子容量" },
            {"CaeepyArmor", "怪物甲容量" },
            {"BoneArmor", "骨甲容量" },
            {"Booze/Wristwatch", "酒/手表容量" },
            {"AirCanister", "氧气瓶容量" },
            {"Ordinary", "普通食物容量" },
            {"Snack", "巧克力容量" },
            {"Circuit", "电路板容量" },
            {"Ropr", "绳子容量" },
            {"ALLanimal", "所有动物皮容量" },
            {"Arrows", "箭：" },
            {"Flsh", "鱼：" },
            {"Lizard", "蜥蜴：" },
            {"Rabbit", "兔子：" },
            {"Meat", "普通食物：" },
            {"Note", "注：对于箭、木棍、石头和易断长矛，在解锁容量之前，您需要获得相应的袋子。" },
            {"Own", "<color=green>拥有</color>"},
            {"NotOwned" ,"<color=red>未拥有</color>"},
            {"night","晚上" },
            {"daytime", "白天"},
            {"ON","<color=green>ON</color>"},
            {"OFF","<color=red>OFF</color>" }
        };

    }


    [Serializable]
    public class DefaultEnglish
    {
        public string LanguageType = "English";
        public string Author = "云汪家";
        public string Version = "1.0";
        public int fontSize = 12;
        public DefaultEnglish() { }
        public Dictionary<string, string> Lib = new Dictionary<string, string>()
        {

            {"AimingAid","ON/OFF-Aiming Aid"},
            {"Day", "Current game days:"},
            {"HP","HP:"},
            {"Katana","KATANA:" },
            {"ModernBow","MODERN BOW:"},
            {"CrossBow","CROSSBOW:"},
            {"FlareGun","FLARE GUN:"},
            {"Club","CLUB:"},
            {"Chainsaw","CHAINSAW:"},
            {"ModernAxe","MODERN AXE:"},
            {"ClimbingAxe","CLIMBING AXE:"},
            {"Pistol","FLINTLOCK PISTOL:"},
            {"RustyAxe","RUSTY AAXE:"},
            {"Machrtr","MACHRTR:"},
            {"Keycard","KEYCARD:" },

            {"Camcorder","CAMCORDER:" },
            {"Pouch","POUCH:" },
            {"CassettePlayer","CASSETTE PLAYER:"},
            {"TennisRacket","TENNIS RACKET:"},
            {"Pedometer","PEDOMETER:"},
            {"Compass","COMPASS:"},
            {"Redreather","REDREATHER:"},
            {"Pot","OLD POT:" },
            {"CaveMap","CAVE MAP:" },
            {"Shell","TURTLE SHELL:"},
            {"RepairTool", "REPAIR TOOL:"},
            {"Waterskin","WATERSKIN:" },
            {"Time" ,"Time status:"},
            {"MP","MP:" },
            {"Soda", "SODA capacity" },
            {"Arrows/Bolt", "ARROWS/BOLT capacity" },
            {"WeakSpear", "WEAK SPEAR capacity" },
            {"Flare", "FLARE capacity" },
            {"Bone/Skull","BONE/SKULL capacity" },
            {"FuelCan", "FUEL CAN capacity" },
            {"Atick", "ATICK capacity" },
            {"Rock", "ROCK capacity" },
            {"Dynamite", "DYNAMITE capacity" },
            {"Molotov", "MOLOTOV capacity" },
            {"Meds/Health", "MEDS/HEALTH MIX capacity" },
            {"Explosive","EXPLOSIVE capacity" },
            {"AloeVera", "ALOE VERA etc capacity" },
            {"AllBerries", "ALL BERRIES capacity" },
            {"Fish/Rabbit", "FISH/RABBIT etc capacity" },
            {"CaeepyArmor", "CAEEPY ARMOR capacity" },
            {"BoneArmor", "BONE ARMOR capacity" },
            {"Booze/Wristwatch", "BOOZE/WRISTWATCH capacity" },
            {"AirCanister", "AIR CANISTER capacity" },
            {"Ordinary", "MEAT capacity" },
            {"Snack", "SNACK capacity" },
            {"Circuit", "CIRCUIT BOARD capacity" },
            {"Ropr", "ROPR capacity" },
            {"ALLanimal", "ALL animal skins capacity" },
            {"Arrows", "ARROWS:" },
            {"Flsh", "FLSH:" },
            {"Lizard", "LIZARD:" },
            {"Rabbit", "RABBIT:" },
            {"Meat", "MEAT:" },
            {"Note", "Note: for arrows/ sticks /rock and weak spear you need to obtain the corresponding bag before unlocking the capacity." },
            {"Own", "<color=green>Own</color>"},
            {"NotOwned" ,"<color=red>Not owned</color>"},
            {"night","night" },
            {"daytime", "daytime"},
            {"ON","<color=green>ON</color>"},
            {"OFF","<color=red>OFF</color>" }
        };

    }
}
