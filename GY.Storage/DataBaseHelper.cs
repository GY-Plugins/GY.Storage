using System;
using System.Collections.Generic;
using LiteDB;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using static GY.Storage.Storage;

namespace GY.Storage
{
    
    public static class DataBaseHelper
    {
        public static void SetState(CSteamID player, byte[] state)
        {
            using (var db = new LiteDatabase(@"GY.DataBase/Storage.db"))
            {
                var collection = db.GetCollection<PlayerItems>("storages");
                var callerMember = collection.FindOne(p => p.Owner == player.m_SteamID);
                callerMember.Owner = player.m_SteamID;
                callerMember.State = state;
                collection.Update(callerMember);
            }
        }
        public static PlayerItems GetState(CSteamID player)
        {
            using (var db = new LiteDatabase(@"GY.DataBase/Storage.db"))
            {
                var collection = db.GetCollection<PlayerItems>("storages");
                var callerMember = collection.FindOne(p => p.Owner == player.m_SteamID);
                if (callerMember != null) return callerMember;
                
                collection.Insert(new PlayerItems
                {
                    Owner = player.m_SteamID, State = new byte[]{ 0 }
                });
                
                var newInfo = collection.FindOne(p => p.Owner == player.m_SteamID);
                return newInfo;
            }
        }
    }
    
    public class PlayerItems
    {
        public ulong Owner { get; set; }
        public byte[] State { get; set; }
        public Guid Id { get; set; }
    }
    
}