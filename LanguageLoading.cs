using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;
using ModAPI.Attributes;
using LitJson;
using System.Text.RegularExpressions;

namespace Backpacker
{
    public class LanguageLoading
    {
        
        //public static LanguageLoading Instance;
        public string Path = "Mods/Backpacker/Languages";
        public Dictionary<string, Language> LanguageLib = new Dictionary<string, Language>();
        //public bool OverridMode;//覆盖加载模式
        public string DefaultLanguage;
        public ArrayList al = new ArrayList();//动态数组，我用来记录语言种类数量，达到添加外置语言时能渲染出外置语言切换按钮

        /// <summary>
        /// 如果没有本地语言文件，先加载内部语言，然后创建语言json
        /// </summary>
        //public void CreateLanguage()
        //{
        //    if (!Directory.Exists(Path))
        //    {
        //        Directory.CreateDirectory(Path);

        //    }
        //    if (!File.Exists(Path + "/简体中文.json") || !File.Exists(Path + "/English.json"))
        //    {
        //        DefaultChinese ch = new DefaultChinese();
        //        DefaultEnglish en = new DefaultEnglish();
        //        string json = JsonMapper.ToJson(ch, false);
        //        string json1 = JsonMapper.ToJson(en, false);
        //        Language ch1 = JsonMapper.ToObject<Language>(json);
        //        Language en1 = JsonMapper.ToObject<Language>(json1);
        //        LanguageLib.Add(ch1.LanguageType, ch1);
        //        LanguageLib.Add(en1.LanguageType, en1);
        //        GenerateLanguage();
        //    }
        //}

        /// <summary>
        /// 创建语言文件
        /// </summary>
        public void GenerateLanguage()
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);

            }
            if (!File.Exists(Path + "/简体中文.json") && !File.Exists(Path + "/English.json"))
            {
                DefaultChinese DC = new DefaultChinese();
                DefaultEnglish DE = new DefaultEnglish();
                FileStream file = File.Create(Path + "/简体中文.json");
                FileStream file1 = File.Create(Path + "/English.json");
                string json = Regex.Unescape(JsonMapper.ToJson(DC, true));
                string json1 = Regex.Unescape(JsonMapper.ToJson(DE, true));
                file.Close();
                file1.Close();
                StreamWriter writer = new StreamWriter(Path + "/简体中文.json", false);
                StreamWriter writer1 = new StreamWriter(Path + "/English.json", false);
                writer.WriteLine(json);
                writer1.WriteLine(json1);
                writer.Close();
                writer1.Close();
            }
            else
            {
                if (File.Exists(Path + "/简体中文.json"))
                {

                    DefaultEnglish de = new DefaultEnglish();
                    FileStream f1 = File.Create(Path + "/English.json");
                    string js1 = Regex.Unescape(JsonMapper.ToJson(de, true));
                    f1.Close();
                    StreamWriter w1 = new StreamWriter(Path + "/English.json", false);
                    w1.WriteLine(js1);
                    w1.Close();
                    
                }
                if(File.Exists(Path + "/English.json"))
                {
                    DefaultChinese dc = new DefaultChinese();
                    FileStream f = File.Create(Path + "/简体中文.json");
                    string js = Regex.Unescape(JsonMapper.ToJson(dc, true));
                    f.Close();
                    f.Close();
                    StreamWriter w = new StreamWriter(Path + "/简体中文.json", false);
                    w.WriteLine(js);
                    w.Close();
                    
                }
                
            }
        }
        /// <summary>
        /// 用于更改json文档内容变更的方法
        /// </summary>
        public void RewriteJson()
        {
            foreach (var item in Directory.GetFiles(Path))
            {
                FileStream file = new FileStream(item, FileMode.Open);
                StreamReader reader = new StreamReader(file);
                string js = reader.ReadToEnd();
                Language lan = JsonMapper.ToObject<Language>(js);
                if (lan.Lib.ContainsKey("Version"))
                {
                    if (lan.LanguageType == "简体中文")
                    {
                        file.Close();
                        File.Delete(Path + "/" + lan.LanguageType + ".json");
                    }
                    if (lan.LanguageType == "English")
                    {
                        file.Close();
                        File.Delete(Path + "/" + lan.LanguageType + ".json");
                    }

                }
                file.Close();//如果不关闭，文件会一直被占用，导致其他类无法调用加载并访问到语言文件

            }
        }

        /// <summary>
        /// 获取字典字段
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetLanguage(string index)
        {
            return LanguageLib[DefaultLanguage].Lib[index];
        }

        /// <summary>
        /// 获取字体大小
        /// </summary>
        /// <returns></returns>
        public int GetfontSize()
        {
            return LanguageLib[DefaultLanguage].fontSize;
        }

        /// <summary>
        /// 加载语言包，
        /// </summary>
        public void LoadLanguage()
        {
            
            foreach (var item in Directory.GetFiles(Path))
            {
                FileStream file = new FileStream(item, FileMode.Open);
                StreamReader reader = new StreamReader(file);
                string js = reader.ReadToEnd();
                Language lan = JsonMapper.ToObject<Language>(js);
                if (!LanguageLib.ContainsKey(lan.LanguageType))
                {
                    al.Add(lan.LanguageType);
                    LanguageLib.Add(lan.LanguageType, lan);
                }
                file.Close();//如果不关闭，文件会一直被占用，导致其他类无法调用加载并访问到语言文件
            }
        }


    }
}
