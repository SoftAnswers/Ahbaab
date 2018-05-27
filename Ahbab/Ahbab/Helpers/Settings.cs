// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Asawer
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string SettingsKey = "settings_key";
		private static readonly string SettingsDefault = string.Empty;

		#endregion


		public static string GeneralSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SettingsKey, value);
			}
		}

        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault(Constants.Settings.UsernamePreferenceName, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(Constants.Settings.UsernamePreferenceName, value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault(Constants.Settings.PasswordPreferenceName, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(Constants.Settings.PasswordPreferenceName, value);
            }
        }

        public static bool DoSettingsContainKey(string key)
        {
            return AppSettings.Contains(key);
        }

        public static void RemoveKey(string key)
        {
            AppSettings.Remove(key);
        }
    }
}