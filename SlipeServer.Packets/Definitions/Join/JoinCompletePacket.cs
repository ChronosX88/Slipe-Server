﻿using SlipeServer.Packets;
using SlipeServer.Packets.Builder;
using SlipeServer.Packets.Enums;
using System;

namespace MTAServerWrapper.Packets.Outgoing.Connection
{
    public class JoinCompletePacket : Packet
    {
        public override PacketId PacketId => PacketId.PACKET_ID_SERVER_JOIN_COMPLETE;
        public override PacketReliability Reliability => PacketReliability.ReliableSequenced;
        public override PacketPriority Priority => PacketPriority.High;

        public string WelcomeMessage { get; }
        public string Version { get; }

        public JoinCompletePacket(string welcomeMessage, string version)
        {
            WelcomeMessage = welcomeMessage;
            Version = version;
        }

        public override byte[] Write()
        {
            var builder = new PacketBuilder();

            builder.Write(WelcomeMessage.Substring(0, Math.Min(128, WelcomeMessage.Length)));
            builder.Write(Version);

            return builder.Build();
        }

        public override void Read(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}
