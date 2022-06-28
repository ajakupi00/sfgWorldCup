﻿using dllOOP.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace OOP_WPF
{
    /// <summary>
    /// Interaction logic for PlayersFormation.xaml
    /// </summary>
    public partial class PlayersFormation : Window
    {
        public Match Match { get; set; }

        public PlayersFormation(Match match)
        {
            this.Match = match;
            InitializeComponent();
            HomeTeam();
            AwayTeam();
        }

        private void AwayTeam()
        {
            List<Player> starters = Match.AwayTeamStatistics.StartingEleven;
            string tactics = Match.AwayTeamStatistics.Tactics;
            awayFormation.Content = tactics;
            DivideField(rightHalf, tactics, starters);
        }

        private void HomeTeam()
        {
            List<Player> starters = Match.HomeTeamStatistics.StartingEleven;
            string tactics = Match.HomeTeamStatistics.Tactics;
            homeFormation.Content = tactics;
            DivideField(leftHalf, tactics, starters);
        }

        private void DivideField(Grid half, string tactics, List<Player> starters)
        {
            string[] tactic = tactics.Split('-');
            int formation = tactic.Length;

            for (int i = 0; i < formation + 1; i++) // + GOALIE
            {
                half.ColumnDefinitions.Add(new ColumnDefinition());
            }
            int maxPlayerPerColumn = int.Parse(tactic[0]);
            for (int i = 1; i < formation; i++)
            {
                int temp = int.Parse(tactic[i]);
                if (maxPlayerPerColumn < temp)
                    maxPlayerPerColumn = temp;

            }

            for (int i = 0; i < maxPlayerPerColumn; i++)
            {
                half.RowDefinitions.Add(new RowDefinition());
            }

            AddPlayerControls(half, starters, maxPlayerPerColumn, tactic);
        }

        private void AddPlayerControls(Grid half, List<Player> starters, int maxplayerspercolumn, string[] tactic)
        {
            List<Player> defenders = starters.FindAll(p => p.Position == Position.Defender);
            List<Player> midfielders = starters.FindAll(p => p.Position == Position.Midfield);
            List<Player> attackers = starters.FindAll(p => p.Position == Position.Forward);


            UserControls.Player goalie = new UserControls.Player();
            Player player = starters.Find(p => p.Position == Position.Goalie);
            AddGoalie(half, maxplayerspercolumn, goalie, player);

            int ndef = int.Parse(tactic[0]);
            int nToRemove = 0;
            int membersOffDef = 0;
            //  DEFENDERS
            for (int i = 0; i < defenders.Count; i++)
            {
                UserControls.Player pl = new UserControls.Player();
                if (i < ndef)
                {
                    pl.PlayerName = defenders[i].Name;
                    pl.ShirtNUmber = defenders[i].ShirtNumber.ToString();
                    pl.InitFields();
                    pl.VerticalAlignment = VerticalAlignment.Center;
                    pl.HorizontalAlignment = HorizontalAlignment.Center;
                    pl.SetValue(Grid.RowSpanProperty, maxplayerspercolumn / ndef);
                    pl.SetValue(Grid.ColumnProperty, 1);
                    pl.SetValue(Grid.RowProperty, i);
                    half.Children.Add(pl);
                    nToRemove++;
                    membersOffDef++;
                }
            }
            defenders.RemoveRange(0, nToRemove);
            nToRemove = 0;
            if(membersOffDef < ndef)
            {
                int exisitingDef = membersOffDef;
                for (int i = 0; i < midfielders.Count; i++)
                {
                    if(membersOffDef < ndef)
                    {
                        UserControls.Player pl = new UserControls.Player();
                        pl.PlayerName = midfielders[i].Name;
                        pl.ShirtNUmber = midfielders[i].ShirtNumber.ToString();
                        pl.InitFields();
                        pl.VerticalAlignment = VerticalAlignment.Center;
                        pl.HorizontalAlignment = HorizontalAlignment.Center;
                        pl.SetValue(Grid.RowSpanProperty, maxplayerspercolumn / ndef);
                        pl.SetValue(Grid.ColumnProperty, 1);
                        pl.SetValue(Grid.RowProperty, i + exisitingDef);
                        half.Children.Add(pl);
                        nToRemove++;
                        membersOffDef++;
                    }
                }
                midfielders.RemoveRange(0, nToRemove);
                nToRemove = 0;
            }


            // FIRST MIDFIELD
            int nfMid = int.Parse(tactic[1]);
            // CHECK LEFT DEFENDER
            int membersOffMid = 0;
            if (defenders.Count > 0)
            {
                for (int i = 0; i < defenders.Count; i++)
                {
                    if (i < nfMid)
                    {
                        UserControls.Player pl = new UserControls.Player();
                        pl.PlayerName = defenders[i].Name;
                        pl.ShirtNUmber = defenders[i].ShirtNumber.ToString();
                        pl.InitFields();
                        pl.VerticalAlignment = VerticalAlignment.Center;
                        pl.HorizontalAlignment = HorizontalAlignment.Center;
                        pl.SetValue(Grid.RowSpanProperty, maxplayerspercolumn / nfMid);
                        pl.SetValue(Grid.ColumnProperty, 2);
                        pl.SetValue(Grid.RowProperty, i);
                        half.Children.Add(pl);
                        membersOffMid++;
                    }
                }
            }
            // ADD MIDFIELDERS
            if(membersOffMid < nfMid)
            {
                int defInMid = membersOffMid;
                for (int i = 0; i < midfielders.Count; i++)
                {
                    if (membersOffMid < nfMid)
                    {

                        UserControls.Player pl = new UserControls.Player();
                        pl.PlayerName = midfielders[i].Name;
                        pl.ShirtNUmber = midfielders[i].ShirtNumber.ToString();
                        pl.InitFields();
                        pl.VerticalAlignment = VerticalAlignment.Center;
                        pl.HorizontalAlignment = HorizontalAlignment.Center;
                        pl.SetValue(Grid.RowSpanProperty, maxplayerspercolumn / nfMid);
                        pl.SetValue(Grid.ColumnProperty, 2);
                        pl.SetValue(Grid.RowProperty, i + defInMid);
                        half.Children.Add(pl);
                        membersOffMid++;
                        nToRemove++;
                    }
                }
            }
            midfielders.RemoveRange(0, nToRemove);
            nToRemove = 0;
            // CHECK IF SPACE LEFT FOR ATTACKERS
            // ADD ATTACKERS
            if(membersOffMid < nfMid)
            {
                for (int i = 0; i < attackers.Count; i++)
                {
                    if (membersOffMid < nfMid)
                    {
                        UserControls.Player pl = new UserControls.Player();
                        pl.PlayerName = attackers[i].Name;
                        pl.ShirtNUmber = attackers[i].ShirtNumber.ToString();
                        pl.InitFields();
                        pl.VerticalAlignment = VerticalAlignment.Center;
                        pl.HorizontalAlignment = HorizontalAlignment.Center;
                        pl.SetValue(Grid.RowSpanProperty, maxplayerspercolumn / nfMid);
                        pl.SetValue(Grid.ColumnProperty, 2);
                        pl.SetValue(Grid.RowProperty, i + membersOffMid);
                        half.Children.Add(pl);
                        membersOffMid++;
                        nToRemove++;
                    }
                }
            }
            if(nToRemove != 0)
            {
                attackers.RemoveRange(0, nToRemove);
            }
            nToRemove = 0;


            // SECOND MIDFIELD
                // CHECK IF EXISTS SECOND MIDFIELD
                // ADD REMAINING MIDFIELDERS
                // CHECK IF SPACE FOR ATTACKERS
                // ADD ATTACKERS

            if(tactic.Length > 3)
            {
                int nsMid = int.Parse(tactic[2]);
                int membersOffsMid = 0;
                for (int i = 0; i < midfielders.Count; i++)
                {
                    if(i < nsMid)
                    {
                        UserControls.Player pl = new UserControls.Player();
                        pl.PlayerName = midfielders[i].Name;
                        pl.ShirtNUmber = midfielders[i].ShirtNumber.ToString();
                        pl.InitFields();
                        pl.VerticalAlignment = VerticalAlignment.Center;
                        pl.HorizontalAlignment = HorizontalAlignment.Center;
                        pl.SetValue(Grid.RowSpanProperty, maxplayerspercolumn / nsMid);
                        pl.SetValue(Grid.ColumnProperty, 3);
                        pl.SetValue(Grid.RowProperty, i);
                        half.Children.Add(pl);
                        nToRemove++;
                        membersOffsMid++;
                    }
                }
                midfielders.RemoveRange(0, nToRemove);
                nToRemove = 0;
                if(membersOffsMid < nsMid)
                {
                    for (int i = 0; i < attackers.Count; i++)
                    {
                        int existingMemebers = membersOffsMid;
                        if(membersOffsMid < nsMid)
                        {
                            UserControls.Player pl = new UserControls.Player();
                            pl.PlayerName = attackers[i].Name;
                            pl.ShirtNUmber = attackers[i].ShirtNumber.ToString();
                            pl.InitFields();
                            pl.VerticalAlignment = VerticalAlignment.Center;
                            pl.HorizontalAlignment = HorizontalAlignment.Center;
                            pl.SetValue(Grid.RowSpanProperty, maxplayerspercolumn / nsMid);
                            pl.SetValue(Grid.ColumnProperty, 3);
                            pl.SetValue(Grid.RowProperty, i + existingMemebers);
                            half.Children.Add(pl);
                            nToRemove++;
                            membersOffsMid++;
                        }
                    }
                    attackers.RemoveRange(0, nToRemove);
                    nToRemove = 0;
                }
            }


            //  ATTACKERS
            // CHECK  REMAINING MIDFIELDERS
            // CHECK IF SPACE FOR ATTACKERS
            // ADD ATTACKERS

            int length = tactic.Length;
            int nAtt = int.Parse(tactic[length - 1]);
            int membersOfAttack = 0;
            if(midfielders.Count > 0)
            {
                for (int i = 0; i < midfielders.Count; i++)
                {
                    if (i < nAtt)
                    {
                        UserControls.Player pl = new UserControls.Player();
                        pl.PlayerName = midfielders[i].Name;
                        pl.ShirtNUmber = midfielders[i].ShirtNumber.ToString();
                        pl.InitFields();
                        pl.VerticalAlignment = VerticalAlignment.Center;
                        pl.HorizontalAlignment = HorizontalAlignment.Center;
                        pl.SetValue(Grid.RowSpanProperty, maxplayerspercolumn / nAtt);
                        pl.SetValue(Grid.ColumnProperty, length);
                        pl.SetValue(Grid.RowProperty, i);
                        half.Children.Add(pl);
                        nToRemove++;
                        membersOfAttack++;
                    }
                }
                midfielders.RemoveRange(0, nToRemove);
                nToRemove = 0;
            }
            if(membersOfAttack < nAtt)
            {
                for (int i = 0; i < attackers.Count; i++)
                {
                    int existing = membersOfAttack;
                    if(membersOfAttack < nAtt)
                    {

                        UserControls.Player pl = new UserControls.Player();
                        pl.PlayerName = attackers[i].Name;
                        pl.ShirtNUmber = attackers[i].ShirtNumber.ToString();
                        pl.InitFields();
                        pl.VerticalAlignment = VerticalAlignment.Center;
                        pl.HorizontalAlignment = HorizontalAlignment.Center;
                        pl.SetValue(Grid.RowSpanProperty, maxplayerspercolumn / nAtt);
                        pl.SetValue(Grid.ColumnProperty, length);
                        pl.SetValue(Grid.RowProperty, i + existing);
                        half.Children.Add(pl);
                        nToRemove++;
                        membersOfAttack++;
                    }
                }
            }










        }


        private static void AddGoalie(Grid half, int maxplayerspercolumn, UserControls.Player goalie, Player player)
        {
            goalie.PlayerName = player.Name;
            goalie.ShirtNUmber = player.ShirtNumber.ToString();
            goalie.InitFields();
            goalie.VerticalAlignment = VerticalAlignment.Center;
            goalie.HorizontalAlignment = HorizontalAlignment.Center;
            goalie.SetValue(Grid.RowSpanProperty, maxplayerspercolumn);
            goalie.SetValue(Grid.ColumnProperty, 0);
            half.Children.Add(goalie);
        }



    }
}
