﻿namespace RecyclingStation.Models
{
    using Interfaces;
    using Interfaces.Models;

    public class ProcessingData : IProcessingData
    {
        public ProcessingData(double energyBalance, double capitalBalance)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = capitalBalance;
        }

        public double EnergyBalance { get; private set; }

        public double CapitalBalance { get; private set; }
    }
}