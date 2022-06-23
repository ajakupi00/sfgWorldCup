﻿using dllOOOP.Models;
using dllOOP.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllOOP.DAL
{
    public interface ISfg
    {
        //LISTA SVIH REPKI
        //LISTA SVIH IGRAČA ZA REPKU
        //LISTA UTAKMICA ZA ODABRANU REPKU

        Task<RestResponse<NationalTeam>> GetNationalTeams();
        List<Player> GetPlayers(NationalTeam team);
        List<Match> GetMatches(NationalTeam team);

    }
}
