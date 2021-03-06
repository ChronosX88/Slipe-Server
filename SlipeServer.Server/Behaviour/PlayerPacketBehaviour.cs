﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using SlipeServer.Server.Elements;
using SlipeServer.Server.Elements.Events;
using SlipeServer.Server.PacketHandling.Factories;
using SlipeServer.Server.Repositories;

namespace SlipeServer.Server.Behaviour
{
    /// <summary>
    /// Behaviour responsible for handling player events and sending corresponding packets
    /// </summary>
    public class PlayerPacketBehaviour
    {
        private readonly MtaServer server;

        public PlayerPacketBehaviour(MtaServer server)
        {
            this.server = server;
            server.PlayerJoined += OnPlayerJoin;
        }

        private void OnPlayerJoin(Player player)
        {
            player.Spawned += RelayPlayerSpawn;
            player.WantedLevelChanged += WantedLevelChanged;
            player.Wasted += RelayPlayerWasted;
            player.NameChanged += RelayedNameChanged;
        }

        private void RelayPlayerSpawn(object sender, PlayerSpawnedEventArgs args)
        {
            var packet = PlayerPacketFactory.CreateSpawnPacket(args.Source);
            this.server.BroadcastPacket(packet);
        }

        private void WantedLevelChanged(object sender, ElementChangedEventArgs<Player, byte> args)
        {
            var packet = PlayerPacketFactory.CreateSetWantedLevelPacket(args.NewValue);
            args.Source.Client.SendPacket(packet);
        }

        private void RelayPlayerWasted(object? sender, PlayerWastedEventArgs e)
        {
            var packet = PlayerPacketFactory.CreateWastedPacket(
                e.Source, e.Killer, e.WeaponType, e.BodyPart, false, e.AnimationGroup, e.AnimationId
            );
            this.server.BroadcastPacket(packet);
        }

        private void RelayedNameChanged(object sender, ElementChangedEventArgs<string> args)
        {
            if (!args.IsSync)
            {
                var packet = PlayerPacketFactory.CreateNicknameChangePacket((Player)args.Source);
                this.server.BroadcastPacket(packet);
            }
        }
    }
}
