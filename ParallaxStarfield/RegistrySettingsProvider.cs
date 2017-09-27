using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ParallaxStarfield
{
    class RegistrySettingsProvider : SettingsProvider
    {
        public override string ApplicationName { get; set; }

        public string ApplicationVendorName { get; set; }

        public override string Name => GetType().Name;

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            if (ApplicationName == null || ApplicationVendorName == null) throw new ArgumentNullException("ApplicationName or ApplicationVendorName were null.");
            var values = new SettingsPropertyValueCollection();
            using (var hkcu = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))
            {
                using (var settingsKey = hkcu.CreateSubKey(string.Format("Software\\{0}\\{1}", ApplicationVendorName, ApplicationName)))
                {
                    foreach (SettingsProperty setting in collection)
                    {
                        SettingsPropertyValue value = new SettingsPropertyValue(setting);
                        value.IsDirty = false;
                        value.SerializedValue = settingsKey.GetValue(setting.Name);
                        values.Add(value);
                    }
                }
            }
            return values;
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            if (ApplicationName == null || ApplicationVendorName == null) throw new ArgumentNullException("ApplicationName or ApplicationVendorName were null.");
            using (var hkcu = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))
            {
                using (var settingsKey = hkcu.CreateSubKey(string.Format("Software\\{0}\\{1}", ApplicationVendorName, ApplicationName)))
                {
                    foreach (SettingsPropertyValue setting in collection)
                    {
                        settingsKey.SetValue(setting.Name, setting.SerializedValue);
                    }
                }
            }
        }
    }
}
