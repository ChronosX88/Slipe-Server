﻿using System;
using System.Numerics;

namespace SlipeServer.Server.Elements
{
    public class DummyElement: Element
    {
        public override ElementType ElementType => ElementType.Dummy;

        public string ElementTypeName { get; set; } = "dummy";

        public new DummyElement AssociateWith(MtaServer server)
        {
            return server.AssociateElement(this);
        }
    }
}
