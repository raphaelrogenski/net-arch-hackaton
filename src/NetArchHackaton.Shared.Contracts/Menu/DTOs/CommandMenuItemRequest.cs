﻿namespace NetArchHackaton.Shared.Contracts.Menu.DTOs
{
    public class CommandMenuItemRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
    }
}
