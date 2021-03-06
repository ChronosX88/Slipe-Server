﻿using SlipeServer.Packets.Builder;
using SlipeServer.Packets.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SlipeServer.Packets.Definitions.Commands
{
    public class ChatEchoPacket : Packet
    {
        public override PacketId PacketId => PacketId.PACKET_ID_CHAT_ECHO;
        public override PacketReliability Reliability => PacketReliability.ReliableSequenced;
        public override PacketPriority Priority => PacketPriority.Low;

        public uint SourceId { get; set; }
        public string Message { get; set; }
        public Color Color { get; set; }
        public bool IsColorCoded { get; set; }

        public ChatEchoPacket()
        {

        }

        public ChatEchoPacket(uint sourceId, string message, Color color, bool isColorCoded = false)
        {
            SourceId = sourceId;
            Message = message;
            Color = color;
            IsColorCoded = isColorCoded;
        }

        public override void Read(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public override byte[] Write()
        {
            var builder = new PacketBuilder();

            builder.Write(this.Color);
            builder.Write(this.IsColorCoded);
            builder.WriteElementId(this.SourceId);
            builder.WriteStringWithoutLength(this.Message);

            return builder.Build();
        }
    }
}
