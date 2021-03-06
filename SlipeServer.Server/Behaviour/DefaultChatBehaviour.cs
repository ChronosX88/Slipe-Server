﻿using System;
using System.Drawing;
using Microsoft.Extensions.Logging;
using SlipeServer.Packets.Definitions.Commands;
using SlipeServer.Server.Elements;
using SlipeServer.Server.Services;

namespace SlipeServer.Server.Behaviour
{
    /// <summary>
    /// Behaviour responsible for sending chat echo packets to mimic default MTA main chat
    /// </summary>
    public class DefaultChatBehaviour
    {
        public DefaultChatBehaviour(MtaServer server, ChatBox chatBox, ILogger? logger)
        {
            server.PlayerJoined += (player) =>
            {
                player.OnCommand += (sender, arguments) =>
                {
                    if(arguments.Command == "say")
                    {
                        string message = $"{player.Name}: {string.Join(' ', arguments.Arguments)}";
                        chatBox.Output(message, Color.White, true, player);
                        logger?.LogInformation(message);
                    }
                };
            };
        }
    }
}
