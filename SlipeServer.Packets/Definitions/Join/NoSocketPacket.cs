﻿using SlipeServer.Packets;
using SlipeServer.Packets.Builder;
using SlipeServer.Packets.Enums;
using System;

namespace MTAServerWrapper.Packets.Outgoing.Connection
{
    public class NoSocketPacket : Packet
    {
        public override PacketId PacketId => PacketId.PACKET_ID_PLAYER_NO_SOCKET;
        public override PacketReliability Reliability => PacketReliability.ReliableSequenced;
        public override PacketPriority Priority => PacketPriority.High;

        public NoSocketPacket()
        {
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override void Read(byte[] bytes)
        {

        }
    }
}
