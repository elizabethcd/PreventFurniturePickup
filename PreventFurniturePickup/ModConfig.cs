using System;
namespace PreventFurniturePickup
{
    public class ModConfig
    {
        // Add an option for each furniture type
        public bool CanPickUpBed { get; set; }
        public bool CanPickUpChair { get; set; }
        public bool CanPickUpTable { get; set; }
        public bool CanPickUpDresser { get; set; }
        public bool CanPickUpDecoration { get; set; }
        public bool CanPickUpTV { get; set; }
        public bool CanPickUpLamp { get; set; }
        public bool CanPickUpRug { get; set; }
        public bool CanPickUpWindow { get; set; }
        public bool CanPickUpFireplace { get; set; }
        public bool CanPickUpTorch { get; set; }
        public bool CanPickUpSconce { get; set; }
        public bool CanPickUpFishTank { get; set; }

        public ModConfig()
        {
            // By default, allow all furniture types to be picked up
            this.CanPickUpBed = true;
            this.CanPickUpChair = true;
            this.CanPickUpTable = true;
            this.CanPickUpDresser = true;
            this.CanPickUpDecoration = true;
            this.CanPickUpTV = true;
            this.CanPickUpLamp = true;
            this.CanPickUpRug = true;
            this.CanPickUpWindow = true;
            this.CanPickUpFireplace = true;
            this.CanPickUpTorch = true;
            this.CanPickUpSconce = true;
            this.CanPickUpFishTank = true;
        }
    }
}
