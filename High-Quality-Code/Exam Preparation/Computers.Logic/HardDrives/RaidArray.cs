﻿namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaidArray : HardDrive
    {
        private List<SingleHardDrive> hardDrives;
        private int hardDrivesInRaid;

        public RaidArray(List<SingleHardDrive> hardDrives)
        {
            this.hardDrives = hardDrives;
        }

        public override int Capacity
        {
            get
            {
                if (!this.hardDrives.Any())
                {
                    return 0;
                }

                return this.hardDrives.First().Capacity;
            }
        }

        public override void SaveData(int address, string newData)
        {
            foreach (var hardDrive in this.hardDrives)
            {
                hardDrive.SaveData(address, newData);
            }
        }

        public override string LoadData(int address)
        {
            if (!this.hardDrives.Any())
            {
                throw new OutOfMemoryException("No hard drive in the RAID array!");
            }

            return this.hardDrives.First().LoadData(address);
        }
    }
}