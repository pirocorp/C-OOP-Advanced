﻿////using System;
////using System.Collections.Generic;
////using System.Text;

////public class DraftManager
////{
////    private string mode;
////    private double totalStoredEnergy;
////    private double totalMinedOre;
////    private Dictionary<string, Harvester> harvestersById;
////    private Dictionary<string, IProvider> providersById;

////    public DraftManager()
////    {
////        this.mode = "Full";
////        this.totalMinedOre = 0;
////        this.totalStoredEnergy = 0;
////        this.harvestersById = new Dictionary<string, Harvester>();
////        this.providersById = new Dictionary<string, IProvider>();
////    }

////    public string RegisterHarvester(List<string> arguments)
////    {
////        var type = arguments[0];
////        var id = arguments[1];
////        var oreOutput = double.Parse(arguments[2]);
////        var energyRequirement = double.Parse(arguments[3]);
////        var sonicFactor = 0;
////        if (arguments.Count == 5)
////        {
////            sonicFactor = int.Parse(arguments[4]);
////        }

////        try
////        {
////            var harvester = HarvesterFactory.GenerateHarvester(arguments);
////            this.harvestersById.Add(id, harvester);
////        }
////        catch (ArgumentException e)
////        {
////            return e.Message;
////        }

////        return $"Successfully registered {type} Harvester - {id}";
////    }

////    public string RegisterProvider(List<string> arguments)
////    {
////        var type = arguments[0];
////        var id = arguments[1];
////        var energyOutput = int.Parse(arguments[2]);

////        try
////        {
////            var fac = new ProviderFactory();
////            var provider = fac.GenerateProvider(arguments);
////            this.providersById.Add(id, provider);
////        }
////        catch (ArgumentException e)
////        {
////            return e.Message;
////        }

////        return $"Successfully registered {type} Provider - {id}";
////    }

////    public string Day()
////    {
////        //calculate provided power for the day
////        double producedPower = 0;
////        foreach (var provider in this.providersById)
////        {
////            producedPower += provider.Value.EnergyOutput;
////        }

////        //add to the total energy
////        this.totalStoredEnergy += producedPower;

////        //calculate needed energy


////        return sb.ToString().Trim();
////    }

////    public string Mode(List<string> arguments)
////    {
////        var mode = arguments[0];
////        this.mode = mode;

////        return $"Successfully changed working mode to {mode} Mode";
////    }

////    public string Check(List<string> arguments)
////    {
////        var id = arguments[0];
////        var sb = new StringBuilder();
////        if (this.providersById.ContainsKey(id))
////        {
////            sb.AppendLine(providersById[id].ToString());
////        }
////        if (this.harvestersById.ContainsKey(id))
////        {
////            sb.AppendLine(harvestersById[id].ToString());
////        }
////        if (string.IsNullOrWhiteSpace(sb.ToString()))
////        {
////            sb.AppendLine($"No element found with id - {id}");
////        }

////        return sb.ToString().Trim();
////    }

//using System.Text;

//public string ShutDown()
//{

//}

////}
