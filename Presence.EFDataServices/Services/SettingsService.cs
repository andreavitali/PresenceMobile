using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presence.EFDataServices.Models;
using Presence.Entities.Interfaces;
using Presence.Entities.Models;

namespace Presence.EFDataServices
{
    public enum SettingsType
    {
        System = 0,
        Special = 1,
        Cart = 2,
        Report = 3,
        Pay = 4,
        Global = 5
    }

    public enum ExtensionFeatures
    {
        AnagraphicHistory = 6,
        CostCenters = 5,
        Visitors = 21,
    }

    public class SettingsService : ISettingsService
    {
        private Dictionary<SettingsType, IniFile> _appTypeIniFile = null;

        public SettingsService(string iniFilesPath)
        {
            // Init _appTypeIniFile
            _appTypeIniFile = new Dictionary<SettingsType, IniFile>();
            _appTypeIniFile.Add(SettingsType.Cart, new IniFile(iniFilesPath + "Cart.INI"));
            _appTypeIniFile.Add(SettingsType.Global, new IniFile(iniFilesPath + "Global.INI"));
        }

        public byte[] MajorAnomalies
        {
            get 
            {
                var strValue = _appTypeIniFile[SettingsType.Cart].IniReadValue("Impostazioni", "AnomalieGravi");
                try 
	            {	        
		            return strValue.Split(',').Select(s => byte.Parse(s)).ToArray();
	            }
	            catch (Exception)
	            {
                    return Enumerable.Empty<byte>().ToArray();
	            }
            }
        }

        public bool HistorySupport
        {
            get
            {
                var strValue = _appTypeIniFile[SettingsType.Global].IniReadValue("Configuration", "Modularity");
                return IsModularityFeatureEnabled(strValue, ExtensionFeatures.AnagraphicHistory);
            }
        }

        private bool IsModularityFeatureEnabled(string modularity, ExtensionFeatures feature)
        {
            if (string.IsNullOrEmpty(modularity)) return false;
            modularity = modularity.Substring(2, modularity.Length - 3); // remove &H at start anmd & at end
            var bitArray = new BitArray(BitConverter.GetBytes(Int32.Parse(modularity, System.Globalization.NumberStyles.HexNumber)));
            return bitArray[(int)feature - 1];
        }
    }
}
