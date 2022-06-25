﻿using dllOOOP.Models;
using dllOOP.DAL.Interfaces;
using dllOOP.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace dllOOP.DAL
{
    public class FileRepository : IRepo
    {
        private readonly string DIR = AppDomain.CurrentDomain.BaseDirectory;
        private string SETTINGS_FILE_NAME = @"\settings.txt";
        private string TEAM_FILE_NAME = @"\favorite.xml";
        private string PLAYERS_FILE_NAME = @"\players.xml";
        private string SETTINGS_PATH;
        private string TEAM_PATH;
        private string PLAYER_PATH;
        private string[] SETTINGS = new string[3];

        public FileRepository()
        {
            if (!Directory.Exists(DIR))
            {
                Directory.CreateDirectory(DIR);
            }
            if (!File.Exists(DIR + SETTINGS_FILE_NAME))
            {
                File.Create(DIR + SETTINGS_FILE_NAME);
            }
            if (!File.Exists(DIR + TEAM_FILE_NAME))
            {
                File.Create(DIR + TEAM_FILE_NAME);
            }
            if (!File.Exists(DIR + PLAYERS_FILE_NAME))
            {
                File.Create(DIR + PLAYERS_FILE_NAME);
            }
            SETTINGS_PATH = DIR + SETTINGS_FILE_NAME;
            TEAM_PATH = DIR + TEAM_FILE_NAME;
            PLAYER_PATH = DIR + PLAYERS_FILE_NAME;
        }

        public List<Player> GetFavoritePlayers()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Player>));
            try
            {
                using (StreamReader reader = new StreamReader(PLAYER_PATH))
                {
                    List<Player> team = (List<Player>)serializer.Deserialize(reader);
                    return team;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public NationalTeam GetFavoriteTeam()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NationalTeam));
            try
            {
                using (StreamReader reader = new StreamReader(TEAM_PATH))
                {
                    NationalTeam team = (NationalTeam)serializer.Deserialize(reader);
                    return team;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public string GetLanguage()
        {
            string[] lines = File.ReadAllLines(SETTINGS_PATH);
            return lines[0];
        }

        public Control GetPicture(string filepath)
        {
            PictureBox pb = new PictureBox();

            Image imgThumbnail = Image.FromFile(filepath);
            pb.Image = imgThumbnail;
            pb.Size = new Size(185,185);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            return pb;
        }



        public Sex GetSexSetting()
        {
            string[] lines = File.ReadAllLines(SETTINGS_PATH);
            return (lines[1] == "MEN") ? Sex.MEN : Sex.WOMEN;
        }

        public void SaveFavoritePlayers(List<Player> players)
        {
            using (StreamWriter xmlSW = new StreamWriter(PLAYER_PATH))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Player>));
                {
                    serializer.Serialize(xmlSW, players);
                }
            }
        }

        public void SetFavoriteTeam(NationalTeam team)
        {
            using (StreamWriter xmlSW = new StreamWriter(TEAM_PATH))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(NationalTeam));
                serializer.Serialize(xmlSW, team);
            }

        }

        public void SetLanguage(string lang)
        {
            SETTINGS[0] = lang;
            string[] lines = File.ReadAllLines(SETTINGS_PATH);
            if (lines.Count() > 1) SETTINGS[1] = lines[1];
            File.WriteAllLines(SETTINGS_PATH, SETTINGS);
        }

        public void SetSexSetting(Sex sex)
        {
            SETTINGS[1] = sex.ToString();
            string[] lines = File.ReadAllLines(SETTINGS_PATH);
            if (lines.Count() > 1) SETTINGS[0] = lines[0];
            File.WriteAllLines(SETTINGS_PATH, SETTINGS);
        }

    

    }
}
