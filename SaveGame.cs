using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheForest.Utils;
using TheForest.Save;
using System.IO;

namespace Backpacker
{
    class SaveGame
    {
        


        static string GetDataPath()
        {
            if (GameSetup.IsMultiplayer)
            {
                if (GameSetup.IsMpClient)
                {
                    return "Mods/Backpacker/Client/" + PlayerSpawn.GetClientSaveFileName();
                }
                else if (GameSetup.IsMpServer)
                {
                    return "Mods/Backpacker/Server/" + GameSetup.Slot.ToString();
                }
                return "Mods/Backpacker/Multiplayer/" + GameSetup.Slot.ToString();
            }
            return "Mods/Backpacker/Single/" + GameSetup.Slot.ToString();
        }
        /// <summary>
        /// 让返回值不小于0
        /// </summary>
        /// <param name="judge"></param>
        /// <returns></returns>
        public static int Judge(int judge)
        {
            if (judge < 0)
            {
                judge = 0;
            }

            return judge;
        }


        public static void Save()
        {
            if (GameSetup.Slot.ToString() == "0")
            {

                if (!GameSetup.IsMpClient)
                {
                    return;
                }

            }
            string filepath = GetDataPath();
            if (!Directory.Exists(filepath))
            { 
                Directory.CreateDirectory(filepath); 
            }
            filepath += "/Backpacker.save";
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

            

            using (BinaryWriter writer = new BinaryWriter(new FileStream(filepath,FileMode.Create)))
            {

                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(109) - 10));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(83) - 50));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(307) - 30));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(56) - 5));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(43) - 10));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(178) - 15));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(94) - 4));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(262) - 5));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(57) - 20));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(53) - 10));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(175) - 5));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(71) - 9));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(49) - 5));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(68) - 5));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(212) - 5));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(100) - 5));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(213) - 5));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(29) - 5));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(99) - 10));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(97) - 10));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(98) - 10));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(67) - 10));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(114) - 30));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(112) - 30));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(113) - 30));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(211) - 30));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(127) - 3));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(35) - 3));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(76) - 3));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(301) - 10));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(204) - 10));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(37) - 7));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(41) - 4));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(144) - 4));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(123) - 4));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(89) - 15));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(31) - 5));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(54) - 4));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(92) - 10));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(129) - 10));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(126) - 10));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(292) - 10));
                
                writer.Write(Judge(LocalPlayer.Inventory.AmountOf(293) - 10));
                
                writer.Write(Backpacker.language);

                

                writer.Close();
                File.SetAttributes(filepath, FileAttributes.Normal);

            }

            
        }


        public static Backpacker LoadedData()
        {
            string filepath = GetDataPath();

            Backpacker back = new Backpacker();
            
            if (Directory.Exists(filepath))
            {
                filepath += "/Backpacker.save";

                if (File.Exists(filepath))
                {
                    if (!GameSetup.IsNewGame)
                    {
                        
                        BinaryReader reader = new BinaryReader(new FileStream(filepath, FileMode.Open));

                        back.shuDashui.amount = reader.ReadInt32();
                        
                        back.jiang.amount = reader.ReadInt32();

                        back.nuJiang.amount = reader.ReadInt32();

                        back.yiDuanCanMao.amount= reader.ReadInt32();

                        back.zhaoMingDang.amount= reader.ReadInt32();

                        back.guTou.amount= reader.ReadInt32();

                        back.kuLouTou.amount= reader.ReadInt32();

                        back.rangLiao.amount= reader.ReadInt32();

                        back.muGun.amount= reader.ReadInt32();

                        back.shiTou.amount= reader.ReadInt32();

                        back.zaYao.amount= reader.ReadInt32();

                        back.rangShaoPing.amount= reader.ReadInt32();

                        back.yaoPing.amount= reader.ReadInt32();

                        back.chaoYao.amount= reader.ReadInt32();

                        back.chaoYaoJia.amount= reader.ReadInt32();

                        back.jingLi.amount= reader.ReadInt32();

                        back.jingLiJia.amount= reader.ReadInt32();

                        back.dingShiZhaDang.amount= reader.ReadInt32();

                        back.luHui.amount= reader.ReadInt32();

                        back.jingJuHua.amount= reader.ReadInt32();

                        back.juJu.amount= reader.ReadInt32();

                        back.wangSouJu.amount= reader.ReadInt32();

                        back.lanMei.amount= reader.ReadInt32();

                        back.shuanShengMei.amount= reader.ReadInt32();

                        back.xuGuo.amount= reader.ReadInt32();

                        back.heiMei.amount= reader.ReadInt32();

                        back.yu.amount= reader.ReadInt32();

                        back.xiYi.amount= reader.ReadInt32();

                        back.tuZhi.amount= reader.ReadInt32();

                        back.guaiWuJia.amount= reader.ReadInt32();

                        back.guJia.amount= reader.ReadInt32();

                        back.jiu.amount= reader.ReadInt32();

                        back.shouBiao.amount= reader.ReadInt32();

                        back.yangQiPing.amount= reader.ReadInt32();

                        back.puTonShiWu.amount= reader.ReadInt32();

                        back.qiaoKeLi.amount= reader.ReadInt32();

                        back.dianLuBang.amount= reader.ReadInt32();

                        back.shengZhi.amount= reader.ReadInt32();

                        back.xiYiPi.amount= reader.ReadInt32();

                        back.tuPi.amount= reader.ReadInt32();

                        back.luPi.amount= reader.ReadInt32();

                        back.yeZhuPi.amount= reader.ReadInt32();

                        back.huangXiongPi.amount= reader.ReadInt32();

                        Backpacker.language = reader.ReadString();


                        reader.Close();


                    }
                }
            }


            return back;
        }




    }
}
