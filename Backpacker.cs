using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModAPI.Attributes;
using TheForest.Utils;
using TheForest.Items;
using UnityEngine;
using TheForest.Utils.Settings;
using TheForest.Save;
using TheForest.Items.Inventory;





namespace Backpacker
{
    public class Backpacker : MonoBehaviour
    {
        [ExecuteOnGameStart]
        private static void AddMeToScene()
        {
            new GameObject("__Backpacker__").AddComponent<Backpacker>();
        }
        //---------------------------------------------------------------------------变量声明
        protected GUIStyle background;
        protected GUIStyle labelStyle;
        protected GUIStyle LTfontSize;
        public static Texture2D BackGround;
        public LanguageLoading lang = new LanguageLoading();

        private bool ShouldEquipLeftHandAfter;
        private bool ShouldEquipRightHandAfter;
        public bool aim;
        public bool chongSheng;
        public bool load;
        private bool visible;
        protected bool Initialized;

        public int aimI;
        public int duoRen;
        public int itmeId;
        public float ButtonY;



        public string shiJiang;
        public static string language;
        public string fuZhu;

        
        

        public Goods shuDashui;
        public Goods jiang;
        public Goods nuJiang;
        public Goods yiDuanCanMao;
        public Goods zhaoMingDang;
        public Goods guTou;
        public Goods kuLouTou;
        public Goods rangLiao;
        public Goods muGun;
        public Goods shiTou;
        public Goods zaYao;
        public Goods rangShaoPing;

        public Goods yaoPing;
        public Goods chaoYao;
        public Goods chaoYaoJia;
        public Goods jingLi;
        public Goods jingLiJia;

        public Goods dingShiZhaDang;

        public Goods luHui;
        public Goods jingJuHua;
        public Goods juJu;
        public Goods wangSouJu;

        public Goods lanMei;
        public Goods shuanShengMei;
        public Goods xuGuo;
        public Goods heiMei;

        public Goods yu;
        public Goods xiYi;
        public Goods tuZhi;

        public Goods guaiWuJia;
        public Goods guJia;

        public Goods jiu;
        public Goods shouBiao;

        public Goods yangQiPing;
        public Goods puTonShiWu;
        public Goods qiaoKeLi;
        public Goods dianLuBang;
        public Goods shengZhi;

        public Goods xiYiPi;
        public Goods tuPi;
        public Goods luPi;
        public Goods yeZhuPi;
        public Goods huangXiongPi;

        
        

        //--------------------------------------------------------------------------结构
        public struct Goods
        {
            
            public int amount;
            public bool bl;
            public string txt;
            public string txt_1;

        };


        //--------------------------------------------------------------------------初始化
        void Awake()
        {
            lang.RewriteJson();
            lang.GenerateLanguage();
            lang.LoadLanguage();
            
        }


        void Start()
        {


            Backpacker back = SaveGame.LoadedData();
            shuDashui.amount = back.shuDashui.amount;
            jiang.amount = back.jiang.amount;
            nuJiang.amount = back.nuJiang.amount;
            yiDuanCanMao.amount = back.yiDuanCanMao.amount;
            zhaoMingDang.amount = back.zhaoMingDang.amount;
            guTou.amount = back.guTou.amount;
            kuLouTou.amount = back.kuLouTou.amount;
            rangLiao.amount = back.rangLiao.amount;
            muGun.amount = back.muGun.amount;
            shiTou.amount = back.shiTou.amount;
            zaYao.amount = back.zaYao.amount;
            rangShaoPing.amount = back.rangShaoPing.amount;
            yaoPing.amount = back.yaoPing.amount;
            chaoYao.amount = back.chaoYao.amount;
            chaoYaoJia.amount = back.chaoYaoJia.amount;
            jingLi.amount = back.jingLi.amount;
            jingLiJia.amount = back.jingLiJia.amount;
            dingShiZhaDang.amount = back.dingShiZhaDang.amount;
            luHui.amount = back.luHui.amount;
            jingJuHua.amount = back.jingJuHua.amount;
            juJu.amount = back.juJu.amount;
            wangSouJu.amount = back.wangSouJu.amount;
            lanMei.amount = back.lanMei.amount;
            shuanShengMei.amount = back.shuanShengMei.amount;
            xuGuo.amount = back.xuGuo.amount;
            heiMei.amount = back.heiMei.amount;
            yu.amount = back.yu.amount;
            xiYi.amount = back.xiYi.amount;
            tuZhi.amount = back.tuZhi.amount;
            guaiWuJia.amount = back.guaiWuJia.amount;
            guJia.amount = back.guJia.amount;
            jiu.amount = back.jiu.amount;
            shouBiao.amount = back.shouBiao.amount;
            yangQiPing.amount = back.yangQiPing.amount;
            puTonShiWu.amount = back.puTonShiWu.amount;
            qiaoKeLi.amount = back.qiaoKeLi.amount;
            dianLuBang.amount = back.dianLuBang.amount;
            shengZhi.amount = back.shengZhi.amount;
            xiYiPi.amount = back.xiYiPi.amount;
            tuPi.amount = back.tuPi.amount;
            luPi.amount = back.luPi.amount;
            yeZhuPi.amount = back.yeZhuPi.amount;
            huangXiongPi.amount = back.huangXiongPi.amount;

            
            BackGround = ModAPI.Resources.GetTexture("Backpacker.PNG");
            
            Invoke("CapacityCheck", 3);
            
            DefaultRead();
            

        }

        //--------------------------------------------------------------------------判断
        private void Update()
        {
            // if clicked button
            if (ModAPI.Input.GetButtonDown("Menu"))
            {
                // show cursor
                if (visible)
                {
                    LocalPlayer.FpCharacter.UnLockView();
                    RestoreEquipement();//恢复之前手上装备
                }
                else
                {
                    LocalPlayer.FpCharacter.LockView(true);

                    //完美的隐藏武器和恢复
                    ShouldEquipLeftHandAfter = !LocalPlayer.Inventory.IsLeftHandEmpty();
                    ShouldEquipRightHandAfter = !LocalPlayer.Inventory.IsRightHandEmpty();

                    if (!LocalPlayer.Inventory.IsRightHandEmpty())
                    {
                        if (!LocalPlayer.Inventory.RightHand.IsHeldOnly)
                        {
                            LocalPlayer.Inventory.MemorizeItem(Item.EquipmentSlot.RightHand);
                        }
                        LocalPlayer.Inventory.StashEquipedWeapon(false);
                    }
                    if (!LocalPlayer.Inventory.IsLeftHandEmpty())
                    {
                        LocalPlayer.Inventory.MemorizeItem(Item.EquipmentSlot.LeftHand);
                        LocalPlayer.Inventory.StashLeftHand();
                    }

                    //LocalPlayer.Inventory.StashEquipedWeapon(false);//隐藏装备武器
                }
                // toggle menu
                visible = !visible;
            }

            if (!this.Initialized)
            {
                this.Initialize();
            }


            CapacityCheck();
            RecoverData();

            //拿取--箭
            if (LocalPlayer.Inventory.AmountOf(83) > 52)
            {
                jiang.amount += LocalPlayer.Inventory.AmountOf(83) - 52;
                LocalPlayer.Inventory.RemoveItem(83, (LocalPlayer.Inventory.AmountOf(83) - 52));
                
            }
            //消耗
            if (LocalPlayer.Inventory.AmountOf(83) == 51)
            {
                if (jiang.amount > 0)
                {
                    jiang.amount--;
                    itmeId = 83;
                    Invoke("Jian", 3);
                }

            }

            //鱼
            if(LocalPlayer.Inventory.AmountOf(127) > 3)
            {
                yu.amount += LocalPlayer.Inventory.AmountOf(127) - 3;
                LocalPlayer.Inventory.RemoveItem(127, (LocalPlayer.Inventory.AmountOf(127) - 3));
            }
            if (LocalPlayer.Inventory.AmountOf(127) == 2)
            {
                if (yu.amount > 0)
                {
                    yu.amount--;
                    itmeId = 127;
                    Invoke("Jian", 2);
                }

            }
            //蜥蜴
            if (LocalPlayer.Inventory.AmountOf(35) > 3)
            {
                xiYi.amount += LocalPlayer.Inventory.AmountOf(35) - 3;
                LocalPlayer.Inventory.RemoveItem(35, (LocalPlayer.Inventory.AmountOf(35) - 3));
            }
            if (LocalPlayer.Inventory.AmountOf(35) == 2)
            {
                if (xiYi.amount > 0)
                {
                    xiYi.amount--;
                    itmeId = 35;
                    Invoke("Jian", 2);
                }

            }
            //兔子
            if (LocalPlayer.Inventory.AmountOf(76) > 3)
            {
                tuZhi.amount += LocalPlayer.Inventory.AmountOf(76) - 3;
                LocalPlayer.Inventory.RemoveItem(76, (LocalPlayer.Inventory.AmountOf(76) - 3));
            }
            if (LocalPlayer.Inventory.AmountOf(76) == 2)
            {
                if (tuZhi.amount > 0)
                {
                    tuZhi.amount--;
                    itmeId = 76;
                    Invoke("Jian", 2);
                }

            }
            //普通食物
            if (LocalPlayer.Inventory.AmountOf(123) > 4)
            {
                puTonShiWu.amount += LocalPlayer.Inventory.AmountOf(123) - 4;
                LocalPlayer.Inventory.RemoveItem(123, (LocalPlayer.Inventory.AmountOf(123) - 4));
            }
            if (LocalPlayer.Inventory.AmountOf(123) == 3)
            {
                if (puTonShiWu.amount > 0)
                {
                    puTonShiWu.amount--;
                    itmeId = 123;
                    Invoke("Jian", 2);
                }

            }
            //TheForest.Utils.LocalPlayer.Inventory.CurrentView = TheForest.Items.Inventory.PlayerInventory.PlayerViews.Death;
            //if ((int)LocalPlayer.Inventory.CurrentView == 7)
            //{
            //    //死亡视图
            //}


            //LocalPlayer.Stats.Dead;//死亡状态，倒下时变化

            if (PlayerRespawnMP.Instance.enabled)//重生按钮出现，比死亡状态变化慢一点，重生后同时为falsh
            {
                
                    if (UnityEngine.Input.GetKeyDown(KeyCode.E))
                    {
                        //chongSheng = true;

                        Invoke("ChonSheng", 10);

                    }
                
            }

            
            //保存数据
            
            if(UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                LocalPlayer.Inventory.AddItem(83, jiang.amount);
                LocalPlayer.Inventory.AddItem(127, yu.amount);
                LocalPlayer.Inventory.AddItem(35, xiYi.amount);
                LocalPlayer.Inventory.AddItem(76, tuZhi.amount);
                LocalPlayer.Inventory.AddItem(123, puTonShiWu.amount);
                language = lang.DefaultLanguage;
                SaveGame.Save();
                LocalPlayer.Inventory.RemoveItem(83, jiang.amount);
                LocalPlayer.Inventory.RemoveItem(127, yu.amount);
                LocalPlayer.Inventory.RemoveItem(35, xiYi.amount);
                LocalPlayer.Inventory.RemoveItem(76, tuZhi.amount);
                LocalPlayer.Inventory.RemoveItem(123, puTonShiWu.amount);
            }

            if(Clock.Dark)
            {
                shiJiang = lang.GetLanguage("night");
            }
            else
            {
                shiJiang = lang.GetLanguage("daytime");
            }

            
        }

        

        
        //-------------------------------------------------------------------------------渲染
        private void OnGUI()
        {

            

            if (aim)
            {
                //Screen.height;//屏幕数据，只能在方法中访问
                //GUI.Box(new Rect(Screen.width / 2 - 5, Screen.height / 2 - 5, 10f, 5f), "+");
                float num = 5f;
                float num2 = 5f;
                float x = (float)Screen.width / 2f - num / 2f;
                float y = (float)Screen.height / 2f - num2 / 2f;
                GUI.Box(new Rect(x, y, num, num2), "", background);
            }

            

            if (visible)
            {
                // use ModAPI Skin
                GUI.skin = ModAPI.Interface.Skin;

                // apply label style if not existing
                if (this.labelStyle == null)
                {
                    this.labelStyle = new GUIStyle(GUI.skin.label);
                    this.labelStyle.fontSize = 10;//字号
                }
                if(LTfontSize == null)
                {
                    LTfontSize = new GUIStyle(GUI.skin.label);
                    LTfontSize.fontSize = lang.GetfontSize();
                }
                
                GUI.Box(new Rect(10f, 10f, 720f, 800f), "",GUI.skin.window);
                
                GUI.DrawTexture(new Rect(10f, 10f, 720f, 800f), BackGround);

                //按钮
                //if (GUI.Button(new Rect(30f, 100f, 80f, 20f), "更改日期"))
                //{
                //    Clock.Day = Int32.Parse(day); // 游戏内的天数

                //}
                //lang.GetLanguage("AimingAid")
                if (GUI.Button(new Rect(30f, 100f, 150f, 20f), lang.GetLanguage("AimingAid")))
                {
                    aimI++;
                    if (aimI == 1)
                    {
                        aim = true;
                    }
                    else
                    {
                        aim = false;
                        aimI = 0;
                    }


                }
                LanguageButton();


                // Label
                GUI.Label(new Rect(30f, 15f, 200f, 20f), "背包客1.3.1", LTfontSize);

                // Text-input
                //day = GUI.TextField(new Rect(30f, 50f, 200f, 30f), day, GUI.skin.textField);

                GUI.Label(new Rect(30f, 130f, 200f, 20f), lang.GetLanguage("Day") + Clock.Day.ToString(), LTfontSize);

                GUI.Label(new Rect(30f, 155f, 200f, 20f), lang.GetLanguage("HP") + LocalPlayer.Stats.Health.ToString(), LTfontSize);
                GUI.Label(new Rect(30f, 180f, 200f, 20f), lang.GetLanguage("Katana") + IsOwned(180), LTfontSize);//
                GUI.Label(new Rect(30f, 205f, 200f, 20f), lang.GetLanguage("ModernBow") + IsOwned(279), LTfontSize);//
                GUI.Label(new Rect(30f, 230f, 200f, 20f), lang.GetLanguage("CrossBow") + IsOwned(306), LTfontSize);//
                GUI.Label(new Rect(30f, 255f, 200f, 20f), lang.GetLanguage("FlareGun") + IsOwned(44), LTfontSize);//
                GUI.Label(new Rect(30f, 280f, 200f, 20f), lang.GetLanguage("Club") + IsOwned(96), LTfontSize);//
                GUI.Label(new Rect(30f, 305f, 200f, 20f), lang.GetLanguage("Chainsaw") + IsOwned(261), LTfontSize);//
                GUI.Label(new Rect(30f, 330f, 200f, 20f), lang.GetLanguage("ModernAxe") + IsOwned(88), LTfontSize);//
                GUI.Label(new Rect(30f, 355f, 200f, 20f), lang.GetLanguage("ClimbingAxe") + IsOwned(138), LTfontSize);//
                GUI.Label(new Rect(30f, 380f, 200f, 20f), lang.GetLanguage("Pistol") + IsOwned(230), LTfontSize);//
                GUI.Label(new Rect(30f, 405f, 200f, 20f), lang.GetLanguage("RustyAxe") + IsOwned(86), LTfontSize);//
                GUI.Label(new Rect(30f, 430f, 200f, 20f), lang.GetLanguage("Machrtr") + IsOwned(265), LTfontSize);//
                GUI.Label(new Rect(30f, 455f, 200f, 20f), lang.GetLanguage("Keycard") + IsOwned(210), LTfontSize);//
                GUI.Label(new Rect(30f, 480f, 200f, 20f), lang.GetLanguage("Camcorder") + IsOwned(267), LTfontSize);//
                GUI.Label(new Rect(30f, 505f, 200f, 20f), lang.GetLanguage("Pouch") + IsOwned(130), LTfontSize);
                GUI.Label(new Rect(30f, 530f, 200f, 20f), lang.GetLanguage("CassettePlayer") + IsOwned(61), LTfontSize);
                GUI.Label(new Rect(30f, 555f, 200f, 20f), lang.GetLanguage("TennisRacket") + IsOwned(184), LTfontSize);
                GUI.Label(new Rect(30f, 580f, 200f, 20f), lang.GetLanguage("Pedometer") + IsOwned(63), LTfontSize);
                GUI.Label(new Rect(30f, 605f, 200f, 20f), lang.GetLanguage("Compass") + IsOwned(173), LTfontSize);
                GUI.Label(new Rect(30f, 630f, 200f, 20f), lang.GetLanguage("Redreather") + IsOwned(143), LTfontSize);
                GUI.Label(new Rect(30f, 655f, 200f, 20f), lang.GetLanguage("Pot") + IsOwned(142), LTfontSize);
                GUI.Label(new Rect(30f, 680f, 200f, 20f), lang.GetLanguage("CaveMap") + IsOwned(196), LTfontSize);
                GUI.Label(new Rect(30f, 705f, 200f, 20f), lang.GetLanguage("Shell") + IsOwned(141), LTfontSize);
                GUI.Label(new Rect(30f, 730f, 200f, 20f), lang.GetLanguage("RepairTool") + IsOwned(257), LTfontSize);
                GUI.Label(new Rect(30f, 755f, 200f, 20f), lang.GetLanguage("Waterskin") + IsOwned(145), LTfontSize);
                GUI.Label(new Rect(20f, 780f, 680f, 20f), lang.GetLanguage("Note"), labelStyle);

                //第二列
                GUI.Label(new Rect(220f, 130f, 300f, 20f), lang.GetLanguage("Time") + shiJiang, LTfontSize);

                GUI.Label(new Rect(220f, 155f, 300f, 20f), lang.GetLanguage("MP") + LocalPlayer.Stats.Stamina.ToString(), LTfontSize);
                GUI.Label(new Rect(220f, 180f, 300f, 20f), lang.GetLanguage("Soda") + "+500：" + IsONoff(109), LTfontSize);
                GUI.Label(new Rect(220f, 205f, 300f, 20f), lang.GetLanguage("Arrows/Bolt") + "+500：" + IsONoff(83), LTfontSize);
                GUI.Label(new Rect(220f, 230f, 300f, 20f), lang.GetLanguage("WeakSpear") + "+500：" + IsONoff(56), LTfontSize);
                GUI.Label(new Rect(220f, 255f, 300f, 20f), lang.GetLanguage("Flare") + "+500：" + IsONoff(43), LTfontSize);
                GUI.Label(new Rect(220f, 280f, 300f, 20f), lang.GetLanguage("Bone/Skull") + "+500：" + IsONoff(178), LTfontSize);
                GUI.Label(new Rect(220f, 305f, 300f, 20f), lang.GetLanguage("FuelCan") + "+500：" + IsONoff(262), LTfontSize);
                GUI.Label(new Rect(220f, 330f, 300f, 20f), lang.GetLanguage("Atick") + "+500：" + IsONoff(57), LTfontSize);
                GUI.Label(new Rect(220f, 355f, 300f, 20f), lang.GetLanguage("Rock") + "+500：" + IsONoff(53), LTfontSize);
                GUI.Label(new Rect(220f, 380f, 300f, 20f), lang.GetLanguage("Dynamite") + "+500：" + IsONoff(175), LTfontSize);
                GUI.Label(new Rect(220f, 405f, 300f, 20f), lang.GetLanguage("Molotov") + "+500：" + IsONoff(71), LTfontSize);
                GUI.Label(new Rect(220f, 430f, 300f, 20f), lang.GetLanguage("Meds/Health") + "+500：" + IsONoff(49), LTfontSize);
                GUI.Label(new Rect(220f, 455f, 300f, 20f), lang.GetLanguage("Explosive") + "+500：" + IsONoff(29), LTfontSize);
                GUI.Label(new Rect(220f, 480f, 300f, 20f), lang.GetLanguage("AloeVera") + "+500：" + IsONoff(99), LTfontSize);
                GUI.Label(new Rect(220f, 505f, 300f, 20f), lang.GetLanguage("AllBerries") + "+500：" + IsONoff(114), LTfontSize);
                GUI.Label(new Rect(220f, 530f, 300f, 20f), lang.GetLanguage("Fish/Rabbit") + "+500：" + IsONoff(127), LTfontSize);
                GUI.Label(new Rect(220f, 555f, 300f, 20f), lang.GetLanguage("CaeepyArmor") + "+500：" + IsONoff(301), LTfontSize);
                GUI.Label(new Rect(220f, 580f, 300f, 20f), lang.GetLanguage("BoneArmor") + "+500：" + IsONoff(204), LTfontSize);
                GUI.Label(new Rect(220f, 605f, 300f, 20f), lang.GetLanguage("Booze/Wristwatch") + "+500：" + IsONoff(37), LTfontSize);
                GUI.Label(new Rect(220f, 630f, 300f, 20f), lang.GetLanguage("AirCanister") + "+500：" + IsONoff(144), LTfontSize);
                GUI.Label(new Rect(220f, 655f, 300f, 20f), lang.GetLanguage("Meat") + "+500：" + IsONoff(123), LTfontSize);
                GUI.Label(new Rect(220f, 680f, 300f, 20f), lang.GetLanguage("Snack") + "+500：" + IsONoff(89), LTfontSize);
                GUI.Label(new Rect(220f, 705f, 300f, 20f), lang.GetLanguage("Circuit") + "+500：" + IsONoff(31), LTfontSize);
                GUI.Label(new Rect(220f, 730f, 300f, 20f), lang.GetLanguage("Ropr") + "+500：" + IsONoff(54), LTfontSize);
                GUI.Label(new Rect(220f, 755f, 300f, 20f), lang.GetLanguage("ALLanimal") + "+500：" + IsONoff(92), LTfontSize);
                //GUI.Label(new Rect(210f, 780f, 200f, 20f), "游戏是否结束：" + LocalPlayer.IsInEndgame.ToString());

                //第三列 特殊
                GUI.Label(new Rect(450f, 205f,100f, 20f), lang.GetLanguage("Arrows") + jiang.amount.ToString(), LTfontSize);
                GUI.Label(new Rect(450f, 530f, 100f, 20f), lang.GetLanguage("Flsh") + yu.amount.ToString(), LTfontSize);
                GUI.Label(new Rect(520f, 530f, 100f, 20f), lang.GetLanguage("Lizard") + xiYi.amount.ToString(), LTfontSize);
                GUI.Label(new Rect(600f, 530f, 100f, 20f), lang.GetLanguage("Rabbit") + tuZhi.amount.ToString(), LTfontSize);
                GUI.Label(new Rect(450f, 655f, 100f, 20f), lang.GetLanguage("Meat") + puTonShiWu.amount.ToString(), LTfontSize);

                




            }
        }

        //-------------------------------------------------------------------------------独立方法
        /// <summary>
        /// 恢复之前手上装备
        /// </summary>
        private void RestoreEquipement()
        {
            if (this.ShouldEquipLeftHandAfter)
            {
                LocalPlayer.Inventory.EquipPreviousUtility(false);
            }
            if (this.ShouldEquipRightHandAfter)
            {
                LocalPlayer.Inventory.EquipPreviousWeaponDelayed();
            }
        }

        /// <summary>
        /// 更改物品容量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        void IncreaseMaxAmount(int id, int amount)
        {
            
            LocalPlayer.Inventory.AddMaxAmountBonus(id, amount);//更改物品容量方法
            //LocalPlayer.Inventory.FixMaxAmountBonuses();//固定最大数量
            // AmountOf(int itemId, bool allowFallback = true);//获取物品数量，返回int
        }

        /// <summary>
        /// 辅助瞄准
        /// </summary>
        private void Initialize()
        {
            this.Initialized = true;
            Texture2D texture2D = new Texture2D(1, 1);
            texture2D.SetPixel(0, 0, new Color(255f, 0f, 0f, 1f));
            texture2D.Apply();
            this.background = new GUIStyle();
            this.background.normal.background = texture2D;
        }

        //数据重置
        public void DataReset()
        {
            shuDashui.amount = 0;
            jiang.amount = 0;
            nuJiang.amount = 0;
            yiDuanCanMao.amount = 0;
            zhaoMingDang.amount = 0;
            guTou.amount = 0;
            kuLouTou.amount = 0;
            rangLiao.amount = 0;
            muGun.amount = 0;
            shiTou.amount = 0;
            zaYao.amount = 0;
            rangShaoPing.amount = 0;
            yaoPing.amount = 0;
            chaoYao.amount = 0;
            chaoYaoJia.amount = 0;
            jingLi.amount = 0;
            jingLiJia.amount = 0;
            dingShiZhaDang.amount = 0;
            luHui.amount = 0;
            jingJuHua.amount = 0;
            juJu.amount = 0;
            wangSouJu.amount = 0;
            lanMei.amount = 0;
            shuanShengMei.amount = 0;
            xuGuo.amount = 0;
            heiMei.amount = 0;
            yu.amount = 0;
            xiYi.amount = 0;
            tuZhi.amount = 0;
            guaiWuJia.amount = 0;
            guJia.amount = 0;
            jiu.amount = 0;
            shouBiao.amount = 0;
            yangQiPing.amount = 0;
            puTonShiWu.amount = 0;
            qiaoKeLi.amount = 0;
            dianLuBang.amount = 0;
            shengZhi.amount = 0;
            xiYiPi.amount = 0;
            tuPi.amount = 0;
            luPi.amount = 0;
            yeZhuPi.amount = 0;
            huangXiongPi.amount = 0;
        }

        /// <summary>
        /// 是否拥有
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public string IsOwned(int itemId)
        {
            if (IsOwnedstring(itemId))
            {
                return lang.GetLanguage("Own");
            }
            else
            {
                return lang.GetLanguage("NotOwned");

            }
        }
        /// <summary>
        /// 判断是否拥有物品
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>bool</returns>
        public bool IsOwnedstring(int itemId)
        {
            if (LocalPlayer.Inventory.HasOwned(itemId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 语言按钮加载
        /// </summary>
        public void LanguageButton()
        {
            ButtonY = 100f;
            foreach (string all in lang.al)
            {
                if (GUI.Button(new Rect(730f, ButtonY, 150f, 30f), all))
                {
                    lang.DefaultLanguage = all;
                    LTfontSize.fontSize = lang.GetfontSize();
                }
                ButtonY += 30f;
            }
        }
        /// <summary>
        /// 默认语言读取
        /// </summary>
        public void DefaultRead()
        {
            foreach (string all in lang.al)
            {
                if (language == all)
                {
                    lang.DefaultLanguage = all;
                    return;
                }
            }
            lang.DefaultLanguage = "简体中文";
        }

        public void Jian()
        {
            LocalPlayer.Inventory.AddItem(itmeId, 1);
        }
        /// <summary>
        /// 判断容量是否关闭
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public string IsONoff(int itemId)
        {
            if(LocalPlayer.Inventory.GetMaxAmountOf(itemId) >= 500)
            {
                return lang.GetLanguage("ON");
            }
            else
            {
                return lang.GetLanguage("OFF");
            }
        }

        //重生后容量恢复，防止拿到背包后物品无法叠加问题
        public void ChonSheng()
        {


            if (shuDashui.bl)
            {
                IncreaseMaxAmount(109, 500);//苏打水
                //shuDashui.bl = false;
            }

            //-------83箭需独立出
            if (nuJiang.bl)
            {
                IncreaseMaxAmount(83, 500);
                IncreaseMaxAmount(307, 500);
                //nuJiang.bl = false;
            }

            //------
            if (yiDuanCanMao.bl)
            {
                IncreaseMaxAmount(56, 500);
               //yiDuanCanMao.bl = false;
            }

            //------
            if (zhaoMingDang.bl)
            {

                IncreaseMaxAmount(43, 500);
                //zhaoMingDang.bl = false;
            }

            //------
            if (guTou.bl)
            {

                IncreaseMaxAmount(178, 500);
                IncreaseMaxAmount(94, 500);
                //guTou.bl = false;
            }

            //------
            if (rangLiao.bl)
            {

                IncreaseMaxAmount(262, 500);
                //rangLiao.bl = false;
            }

            //------
            if (muGun.bl)
            {

                IncreaseMaxAmount(57, 500);
                //muGun.bl = false;
            }

            //------
            if (shiTou.bl)
            {

                IncreaseMaxAmount(53, 500);
                //shiTou.bl = false;
            }

            //------
            if (zaYao.bl)
            {

                IncreaseMaxAmount(175, 500);
                //zaYao.bl = false;
            }

            //------
            if (rangShaoPing.bl)
            {

                IncreaseMaxAmount(71, 500);
                //rangShaoPing.bl = false;
            }

            //------
            if (yaoPing.bl)
            {

                IncreaseMaxAmount(49, 500);
                IncreaseMaxAmount(68, 500);
                IncreaseMaxAmount(212, 500);
                IncreaseMaxAmount(100, 500);
                IncreaseMaxAmount(213, 500);
                //yaoPing.bl = false;
            }

            //------
            if (dingShiZhaDang.bl)
            {

                IncreaseMaxAmount(29, 500);
                //dingShiZhaDang.bl = false;
            }

            //------
            if (luHui.bl)
            {

                IncreaseMaxAmount(99, 500);
                IncreaseMaxAmount(97, 500);
                IncreaseMaxAmount(98, 500);
                IncreaseMaxAmount(67, 500);
                //luHui.bl = false;
            }

            //------
            if (lanMei.bl)
            {

                IncreaseMaxAmount(114, 500);
                IncreaseMaxAmount(112, 500);
                IncreaseMaxAmount(113, 500);
                IncreaseMaxAmount(211, 500);
                //lanMei.bl = false;
            }

            //------
            if (yu.bl)
            {

                IncreaseMaxAmount(127, 500);
                IncreaseMaxAmount(35, 500);
                IncreaseMaxAmount(76, 500);
                //yu.bl = false;
            }

            //------
            if (guaiWuJia.bl)
            {

                IncreaseMaxAmount(301, 500);
                //guaiWuJia.bl = false;
            }

            //------
            if (guJia.bl)
            {

                IncreaseMaxAmount(204, 500);
                //guJia.bl = false;
            }

            //------
            if (jiu.bl)
            {

                IncreaseMaxAmount(37, 500);
                IncreaseMaxAmount(41, 500);
                //jiu.bl = false;
            }

            //------
            if (yangQiPing.bl)
            {

                IncreaseMaxAmount(144, 500);
                //yangQiPing.bl = false;
            }

            //------
            if (puTonShiWu.bl)
            {

                IncreaseMaxAmount(123, 500);
                //puTonShiWu.bl = false;
            }

            //------
            if (qiaoKeLi.bl)
            {

                IncreaseMaxAmount(89, 500);
                //qiaoKeLi.bl = false;
            }

            //------
            if (dianLuBang.bl)
            {

                IncreaseMaxAmount(31, 500);
                //dianLuBang.bl = false;
            }

            //------
            if (shengZhi.bl)
            {

                IncreaseMaxAmount(54, 500);
                //shengZhi.bl = false;
            }

            //------
            if (xiYiPi.bl)
            {

                IncreaseMaxAmount(92, 500);
                IncreaseMaxAmount(129, 500);
                IncreaseMaxAmount(126, 500);
                IncreaseMaxAmount(292, 500);
                IncreaseMaxAmount(293, 500);
                //xiYiPi.bl = false;
            }

        }

        //容量关闭，暂时已不需要，因为重启游戏后容量本身就会被重置
        public void NOCapacityCheck()
        {
            if (!IsOwnedstring(180) && LocalPlayer.Inventory.GetMaxAmountOf(109) == 510)
            {

                IncreaseMaxAmount(109, -500);//苏打水

            }
            if (!IsOwnedstring(279) && LocalPlayer.Inventory.GetMaxAmountOf(83) >= 530)
            {

                //IncreaseMaxAmount(83, -500);
                IncreaseMaxAmount(307, -500);

            }
            if (!IsOwnedstring(306) && LocalPlayer.Inventory.GetMaxAmountOf(56) == 506)
            {

                IncreaseMaxAmount(56, -500);

            }
            if (!IsOwnedstring(44) && LocalPlayer.Inventory.GetMaxAmountOf(43) == 510)
            {

                IncreaseMaxAmount(43, -500);

            }
            if (!IsOwnedstring(96) && LocalPlayer.Inventory.GetMaxAmountOf(178) == 515)
            {

                IncreaseMaxAmount(178, -500);
                IncreaseMaxAmount(94, -500);

            }
            if (!IsOwnedstring(261) && LocalPlayer.Inventory.GetMaxAmountOf(262) == 505)
            {

                IncreaseMaxAmount(262, -500);

            }
            if (!IsOwnedstring(88) && LocalPlayer.Inventory.GetMaxAmountOf(57) == 510)
            {

                IncreaseMaxAmount(57, -500);

            }
            if (!IsOwnedstring(138) && LocalPlayer.Inventory.GetMaxAmountOf(53) >= 505)
            {

                IncreaseMaxAmount(53, -500);

            }
            if (!IsOwnedstring(230) && LocalPlayer.Inventory.GetMaxAmountOf(175) == 505)
            {

                IncreaseMaxAmount(175, -500);

            }
            if (!IsOwnedstring(86) && LocalPlayer.Inventory.GetMaxAmountOf(71) == 509)
            {

                IncreaseMaxAmount(71, -500);

            }
            if (!IsOwnedstring(265) && LocalPlayer.Inventory.GetMaxAmountOf(49) == 505)
            {

                IncreaseMaxAmount(49, -500);
                IncreaseMaxAmount(68, -500);
                IncreaseMaxAmount(212, -500);
                IncreaseMaxAmount(100, -500);
                IncreaseMaxAmount(213, -500);
            }
            if (!IsOwnedstring(210) && LocalPlayer.Inventory.GetMaxAmountOf(29) == 505)
            {

                IncreaseMaxAmount(29, -500);


            }
            if (!IsOwnedstring(267) && LocalPlayer.Inventory.GetMaxAmountOf(99) == 510)
            {

                IncreaseMaxAmount(99, -500);
                IncreaseMaxAmount(97, -500);
                IncreaseMaxAmount(98, -500);
                IncreaseMaxAmount(67, -500);

            }
            if (!IsOwnedstring(130) && LocalPlayer.Inventory.GetMaxAmountOf(114) == 530)
            {

                IncreaseMaxAmount(114, -500);
                IncreaseMaxAmount(112, -500);
                IncreaseMaxAmount(113, -500);
                IncreaseMaxAmount(211, -500);

            }
            if (!IsOwnedstring(61) && LocalPlayer.Inventory.GetMaxAmountOf(35) == 503)
            {

                IncreaseMaxAmount(127, -500);
                IncreaseMaxAmount(35, -500);
                IncreaseMaxAmount(76, -500);

            }
            if (!IsOwnedstring(184) && LocalPlayer.Inventory.GetMaxAmountOf(301) == 510)
            {

                IncreaseMaxAmount(301, -500);

            }
            if (!IsOwnedstring(63) && LocalPlayer.Inventory.GetMaxAmountOf(204) == 510)
            {

                IncreaseMaxAmount(204, -500);

            }
            if (!IsOwnedstring(173) && LocalPlayer.Inventory.GetMaxAmountOf(37) == 507)
            {

                IncreaseMaxAmount(37, -500);
                IncreaseMaxAmount(41, -500);
            }
            if (!IsOwnedstring(143) && LocalPlayer.Inventory.GetMaxAmountOf(144) == 504)
            {

                IncreaseMaxAmount(144, -500);

            }
            if (!IsOwnedstring(142) && LocalPlayer.Inventory.GetMaxAmountOf(123) == 504)
            {

                IncreaseMaxAmount(123, -500);

            }
            if (!IsOwnedstring(196) && LocalPlayer.Inventory.GetMaxAmountOf(89) == 515)
            {

                IncreaseMaxAmount(89, -500);

            }
            if (!IsOwnedstring(141) && LocalPlayer.Inventory.GetMaxAmountOf(31) == 505)
            {

                IncreaseMaxAmount(31, -500);

            }
            if (!IsOwnedstring(257) && LocalPlayer.Inventory.GetMaxAmountOf(54) == 504)
            {

                IncreaseMaxAmount(54, -500);

            }
            if (!IsOwnedstring(145) && LocalPlayer.Inventory.GetMaxAmountOf(92) == 510)
            {

                IncreaseMaxAmount(92, -500);
                IncreaseMaxAmount(129, -500);
                IncreaseMaxAmount(126, -500);
                IncreaseMaxAmount(292, -500);
                IncreaseMaxAmount(293, -500);
            }


        }


        /// <summary>
        /// 容量开启
        /// </summary>
        public void CapacityCheck()
        {
            

            if (IsOwnedstring(180) && LocalPlayer.Inventory.GetMaxAmountOf(109) == 10)
            {
                
                IncreaseMaxAmount(109, 500);//苏打水
                shuDashui.bl = true;

            }
            
            //-------83箭需独立出
            if (IsOwnedstring(279) && LocalPlayer.Inventory.GetMaxAmountOf(83) == 50 )
            {

                IncreaseMaxAmount(83, 500);//箭
                IncreaseMaxAmount(307, 500);//弩箭
                nuJiang.bl = true;

            }
            
            //------
            if (IsOwnedstring(306) &&  LocalPlayer.Inventory.GetMaxAmountOf(56) == 6)
            {

                IncreaseMaxAmount(56, 500);
                yiDuanCanMao.bl = true;

            }
            
            //------
            if (IsOwnedstring(44) && LocalPlayer.Inventory.GetMaxAmountOf(43) == 10)
            {

                IncreaseMaxAmount(43, 500);
                zhaoMingDang.bl = true;

            }
            
            //------
            if (IsOwnedstring(96) && LocalPlayer.Inventory.GetMaxAmountOf(178) == 15)
            {

                IncreaseMaxAmount(178, 500);
                IncreaseMaxAmount(94, 500);
                guTou.bl = true;

            }
            
            //------
            if (IsOwnedstring(261) && LocalPlayer.Inventory.GetMaxAmountOf(262) == 5)
            {

                IncreaseMaxAmount(262, 500);
                rangLiao.bl = true;
            }
            
            //------
            if (IsOwnedstring(88) && LocalPlayer.Inventory.GetMaxAmountOf(57) == 20)
            {

                IncreaseMaxAmount(57, 500);
                muGun.bl = true;
            }
            
            //------
            if (IsOwnedstring(138) && LocalPlayer.Inventory.GetMaxAmountOf(53) == 10)
            {

                IncreaseMaxAmount(53, 500);
                shiTou.bl = true;
            }
            
            //------
            if (IsOwnedstring(230) && LocalPlayer.Inventory.GetMaxAmountOf(175) == 5)
            {

                IncreaseMaxAmount(175, 500);
                zaYao.bl = true;
            }
            
            //------
            if (IsOwnedstring(86) && LocalPlayer.Inventory.GetMaxAmountOf(71) == 9)
            {

                IncreaseMaxAmount(71, 500);
                rangShaoPing.bl = true;
            }
            
            //------
            if (IsOwnedstring(265) && LocalPlayer.Inventory.GetMaxAmountOf(49) == 5)
            {

                IncreaseMaxAmount(49, 500);
                IncreaseMaxAmount(68, 500);
                IncreaseMaxAmount(212, 500);
                IncreaseMaxAmount(100, 500);
                IncreaseMaxAmount(213, 500);
                yaoPing.bl = true;
            }
            
            //------
            if (IsOwnedstring(210) && LocalPlayer.Inventory.GetMaxAmountOf(29) == 5)
            {

                IncreaseMaxAmount(29, 500);
                dingShiZhaDang.bl = true;

            }
            
            //------
            if (IsOwnedstring(267) && LocalPlayer.Inventory.GetMaxAmountOf(99) == 10)
            {

                IncreaseMaxAmount(99, 500);
                IncreaseMaxAmount(97, 500);
                IncreaseMaxAmount(98, 500);
                IncreaseMaxAmount(67, 500);
                luHui.bl = true;
            }
            
            //------
            if (IsOwnedstring(130) && LocalPlayer.Inventory.GetMaxAmountOf(114) == 30)
            {

                IncreaseMaxAmount(114, 500);
                IncreaseMaxAmount(112, 500);
                IncreaseMaxAmount(113, 500);
                IncreaseMaxAmount(211, 500);
                lanMei.bl = true;
            }
            
            //------
            if (IsOwnedstring(61) && LocalPlayer.Inventory.GetMaxAmountOf(35) == 3)
            {

                IncreaseMaxAmount(127, 500);
                IncreaseMaxAmount(35, 500);
                IncreaseMaxAmount(76, 500);
                yu.bl = true;
            }
            
            //------
            if (IsOwnedstring(184) && LocalPlayer.Inventory.GetMaxAmountOf(301) == 10)
            {

                IncreaseMaxAmount(301, 500);
                guaiWuJia.bl = true;
            }
            
            //------
            if (IsOwnedstring(63) && LocalPlayer.Inventory.GetMaxAmountOf(204) == 10)
            {

                IncreaseMaxAmount(204, 500);
                guJia.bl = true;
            }
            
            //------
            if (IsOwnedstring(173) && LocalPlayer.Inventory.GetMaxAmountOf(37) == 7)
            {

                IncreaseMaxAmount(37, 500);
                IncreaseMaxAmount(41, 500);
                jiu.bl = true;
            }
            
            //------
            if (IsOwnedstring(143) && LocalPlayer.Inventory.GetMaxAmountOf(144) == 4)
            {

                IncreaseMaxAmount(144, 500);
                yangQiPing.bl = true;
            }
            
            //------
            if (IsOwnedstring(142) && LocalPlayer.Inventory.GetMaxAmountOf(123) == 4)
            {

                IncreaseMaxAmount(123, 500);
                puTonShiWu.bl = true;
            }
            
            //------
            if (IsOwnedstring(196) && LocalPlayer.Inventory.GetMaxAmountOf(89) == 15)
            {

                IncreaseMaxAmount(89, 500);
                qiaoKeLi.bl = true;

            }

            //------
            if (IsOwnedstring(141) && LocalPlayer.Inventory.GetMaxAmountOf(31) == 5)
            {

                IncreaseMaxAmount(31, 500);
                dianLuBang.bl = true;
            }
            
            //------
            if (IsOwnedstring(257) && LocalPlayer.Inventory.GetMaxAmountOf(54) == 4)
            {

                IncreaseMaxAmount(54, 500);
                shengZhi.bl = true;
            }
            
            //------
            if (IsOwnedstring(145) && LocalPlayer.Inventory.GetMaxAmountOf(92) == 10)
            {

                IncreaseMaxAmount(92, 500);
                IncreaseMaxAmount(129, 500);
                IncreaseMaxAmount(126, 500);
                IncreaseMaxAmount(292, 500);
                IncreaseMaxAmount(293, 500);
                xiYiPi.bl = true;
            }

            load = true;

        }

        /// <summary>
        /// 游戏开始的数据恢复
        /// </summary>
        public void RecoverData()
        {
            if (load)
            {

                if ( LocalPlayer.Inventory.AmountOf(109) == 10)
                {

                    LocalPlayer.Inventory.AddItem(109, shuDashui.amount);
                    
                }
                if (LocalPlayer.Inventory.AmountOf(83) == 50 && jiang.amount > 0)
                {
                    if(jiang.amount < 3)
                    {
                        LocalPlayer.Inventory.AddItem(83, jiang.amount);
                        jiang.amount = 0;
                    }
                    else
                    {
                        LocalPlayer.Inventory.AddItem(83, 2);
                        jiang.amount -= 2;

                    }

                }

                if (LocalPlayer.Inventory.AmountOf(307) == 30)
                {

                    LocalPlayer.Inventory.AddItem(307, nuJiang.amount);

                }

                if (LocalPlayer.Inventory.AmountOf(56) == 6)
                {

                    LocalPlayer.Inventory.AddItem(56, yiDuanCanMao.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(43) == 10)
                {

                    LocalPlayer.Inventory.AddItem(43, zhaoMingDang.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(178) == 15)
                {

                    LocalPlayer.Inventory.AddItem(178, guTou.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(94) == 4)
                {

                    LocalPlayer.Inventory.AddItem(94, kuLouTou.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(262) == 5)
                {

                    LocalPlayer.Inventory.AddItem(262, rangLiao.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(57) == 20)
                {

                    LocalPlayer.Inventory.AddItem(57, muGun.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(53) == 10)
                {

                    LocalPlayer.Inventory.AddItem(53, shiTou.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(175) == 5)
                {

                    LocalPlayer.Inventory.AddItem(175, zaYao.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(71) == 9)
                {

                    LocalPlayer.Inventory.AddItem(71, rangShaoPing.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(49) == 5)
                {

                    LocalPlayer.Inventory.AddItem(49, yaoPing.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(68) == 5)
                {

                    LocalPlayer.Inventory.AddItem(68, chaoYao.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(212) == 5)
                {

                    LocalPlayer.Inventory.AddItem(212, chaoYaoJia.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(100) == 5)
                {

                    LocalPlayer.Inventory.AddItem(100, jingLi.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(213) == 5)
                {

                    LocalPlayer.Inventory.AddItem(213, jingLiJia.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(29) == 5)
                {

                    LocalPlayer.Inventory.AddItem(29, dingShiZhaDang.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(99) == 10)
                {

                    LocalPlayer.Inventory.AddItem(99, luHui.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(97) == 10)
                {

                    LocalPlayer.Inventory.AddItem(97, jingJuHua.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(98) == 10)
                {

                    LocalPlayer.Inventory.AddItem(98, juJu.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(67) == 10)
                {

                    LocalPlayer.Inventory.AddItem(67, wangSouJu.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(114) == 30)
                {

                    LocalPlayer.Inventory.AddItem(114, lanMei.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(112) == 30)
                {

                    LocalPlayer.Inventory.AddItem(112, shuanShengMei.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(113) == 30)
                {

                    LocalPlayer.Inventory.AddItem(113, xuGuo.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(211) == 30)
                {

                    LocalPlayer.Inventory.AddItem(211, heiMei.amount);

                }
                //if (LocalPlayer.Inventory.AmountOf(127) == 3 && yu.amount > 0)
                //{

                //    LocalPlayer.Inventory.AddItem(127, yu.amount);

                //}
                //if (LocalPlayer.Inventory.AmountOf(35) == 3)
                //{

                //    LocalPlayer.Inventory.AddItem(35, xiYi.amount);

                //}
                //if (LocalPlayer.Inventory.AmountOf(76) == 3)
                //{

                //    LocalPlayer.Inventory.AddItem(76, tuZhi.amount);

                //}
                if (LocalPlayer.Inventory.AmountOf(301) == 10)
                {

                    LocalPlayer.Inventory.AddItem(301, guaiWuJia.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(204) == 10)
                {

                    LocalPlayer.Inventory.AddItem(204, guJia.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(37) == 7)
                {

                    LocalPlayer.Inventory.AddItem(37, jiu.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(41) == 4)
                {

                    LocalPlayer.Inventory.AddItem(41, shouBiao.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(144) == 4)
                {

                    LocalPlayer.Inventory.AddItem(144, yangQiPing.amount);

                }
                //if (LocalPlayer.Inventory.AmountOf(123) == 4)
                //{

                //    LocalPlayer.Inventory.AddItem(123, puTonShiWu.amount);

                //}
                if (LocalPlayer.Inventory.AmountOf(89) == 15)
                {

                    LocalPlayer.Inventory.AddItem(89, qiaoKeLi.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(31) == 5)
                {

                    LocalPlayer.Inventory.AddItem(31, dianLuBang.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(54) == 4)
                {

                    LocalPlayer.Inventory.AddItem(54, shengZhi.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(92) == 10)
                {

                    LocalPlayer.Inventory.AddItem(92, xiYiPi.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(129) == 10)
                {

                    LocalPlayer.Inventory.AddItem(129, tuPi.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(126) == 10)
                {

                    LocalPlayer.Inventory.AddItem(126, luPi.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(292) == 10)
                {

                    LocalPlayer.Inventory.AddItem(292, yeZhuPi.amount);

                }
                if (LocalPlayer.Inventory.AmountOf(293) == 10)
                {

                    LocalPlayer.Inventory.AddItem(293, huangXiongPi.amount);

                }

                load = false;

            }



        }


    }
}
